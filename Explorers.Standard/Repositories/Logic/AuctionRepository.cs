using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Extensions;
using WowDotNetAPI.Models.BattleNetApi.Auction;
using WowDotNetAPI.Models.HelperModels;

namespace WowDotNetAPI.Repositories.Logic
{
    public class AuctionRepository :BaseRepository, IAuctionRepository
    {
        private readonly ConcurrentDictionary<string, AuctionMonitor> _auctionDataMonitorDictionary;

        public AuctionRepository(IExplorer explorer) : base(explorer)
        {
            _auctionDataMonitorDictionary = new ConcurrentDictionary<string, AuctionMonitor>();
        }

        public IEnumerable<RealmRegionPair> MonitoredAuctionDataRealms => _auctionDataMonitorDictionary.Select(x => x.Value.RealmRegionPair).ToList();

        public event EventHandler<NewAuctionDataEventArgs> OnAuctionDataUpdate;

        public TimeSpan GetAuctionDataAge(string realm)
        {
            return GetAuctionDataAgeAsync(realm).GetAwaiter().GetResult();
        }

        public async Task<TimeSpan> GetAuctionDataAgeAsync(string realm)
        {
            var snapShot = await GetAuctionFilesAsync(Region, realm);
            return DateTime.Now - TimeSpan.FromMilliseconds(snapShot?.Files.OrderBy(x => x.LastModified).FirstOrDefault()?.LastModified ?? 0).UnixToDateTime().ToLocalTime();
        }

        public TimeSpan GetAuctionDataAge(Region region, string realm)
        {
            return GetAuctionDataAgeAsync(region, realm).GetAwaiter().GetResult();
        }

        public async Task<TimeSpan> GetAuctionDataAgeAsync(Region region, string realm)
        {
            var snapShot = await GetAuctionFilesAsync(region, realm);
            return DateTime.Now - TimeSpan.FromMilliseconds(snapShot?.Files.OrderBy(x => x.LastModified).FirstOrDefault()?.LastModified ?? 0).UnixToDateTime().ToLocalTime();
        }

        /// <summary>
        /// Gets a list of all current auctions on the given realm and connected realms
        /// </summary>
        /// <param name="realm">The name of the realm to base the search on</param>
        /// <returns>Auctions object for the given realm.</returns>
        public Auctions GetAuctions(string realm)
        {
            return GetAuctionsAsync(realm).GetAwaiter().GetResult();
        }

        public async Task<Auctions> GetAuctionsAsync(string realm)
        {
            var auctionFiles = await GetAuctionFilesAsync(Region, realm);

            if (auctionFiles == null) return null;
            var url = "";
            foreach (var auctionFile in auctionFiles.Files)
            {
                url = auctionFile.Url;
            }

            return await GetDataAsync<Auctions>(url);
        }

        private async Task<AuctionFiles> GetAuctionFilesAsync(Region region, string realm)
        {
            return await GetDataAsync<AuctionFiles>($@"{region.GetHost()}/wow/auction/data/{realm.ToLower().Replace(' ', '-')}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="realm"></param>
        /// <param name="timeSpan">Min value is 500ms</param>
        public void StartMonitoringAuctionData(Region region, string realm, TimeSpan timeSpan)
        {
            const int minTimeSpanMilliSeconds = 500;
            if (timeSpan.TotalMilliseconds < minTimeSpanMilliSeconds)
                timeSpan = TimeSpan.FromMilliseconds(minTimeSpanMilliSeconds);

            var realmRegionPair = new RealmRegionPair(region, realm);
            _auctionDataMonitorDictionary.TryGetValue(realmRegionPair.UniquId, out AuctionMonitor auctionMonitor);
            if (auctionMonitor == null)
            {
                var timer = new Timer(CheckAuctionData, realmRegionPair, TimeSpan.Zero, timeSpan);
                auctionMonitor = new AuctionMonitor(timer, realmRegionPair);

                _auctionDataMonitorDictionary.TryAdd(realmRegionPair.UniquId, auctionMonitor);
                //TODO: inform user
            }
        }

        public void StopMonitoringAuctionData(Region region, string realm)
        {
            var key = new RealmRegionPair(region, realm);
            _auctionDataMonitorDictionary.TryRemove(key.UniquId, out AuctionMonitor auctionMonitor);
            auctionMonitor?.Timer?.Change(Timeout.Infinite, Timeout.Infinite);
            auctionMonitor?.Timer?.Dispose();
        }

        public void StopMonitoringAuctionDataAll()
        {
            _auctionDataMonitorDictionary.Select(x => x.Value).ToList().ForEach(x => StopMonitoringAuctionData(x.RealmRegionPair.Region, x.RealmRegionPair.Realm));
        }

        private void CheckAuctionData(object state)
        {
            var realmRegionPair = state as RealmRegionPair;
            if (realmRegionPair == null) return;

            // TODO async?
            var newFiles = GetAuctionFilesAsync(realmRegionPair.Region, realmRegionPair.Realm).GetAwaiter().GetResult();
            var newestFile = newFiles.Files.OrderBy(x => x.LastModified).FirstOrDefault()?.LastModified;

            var success = _auctionDataMonitorDictionary.TryGetValue(realmRegionPair.UniquId, out AuctionMonitor auctionMonitor);

            if (!success || newestFile == null || newestFile == auctionMonitor.AuctionFiles.Files.OrderBy(x => x.LastModified).FirstOrDefault()?.LastModified)
                return;

            // Update value
            var newValue = new AuctionMonitor(auctionMonitor.Timer, realmRegionPair, newFiles);
            _auctionDataMonitorDictionary.TryUpdate(realmRegionPair.UniquId, newValue, auctionMonitor);

            //Raise Event
            OnAuctionDataUpdate?.Invoke(this, new NewAuctionDataEventArgs(realmRegionPair, TimeSpan.FromMilliseconds((double)newestFile).UnixToDateTime().ToLocalTime()));
        }
    }
}
