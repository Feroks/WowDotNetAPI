using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.Auction;
using WowDotNetAPI.Models.HelperModels;

namespace WowDotNetAPI.Repositories
{
    public interface IAuctionRepository
    {
        event EventHandler<NewAuctionDataEventArgs> OnAuctionDataUpdate;

        IEnumerable<RealmRegionPair> MonitoredAuctionDataRealms { get; }

        TimeSpan GetAuctionDataAge(string realm);
        Task<TimeSpan> GetAuctionDataAgeAsync(string realm);

        TimeSpan GetAuctionDataAge(Region region, string realm);
        Task<TimeSpan> GetAuctionDataAgeAsync(Region region, string realm);

        Auctions GetAuctions(string realm);
        Task<Auctions> GetAuctionsAsync(string realm);

        void StartMonitoringAuctionData(Region region, string realm, TimeSpan timeSpan);

        void StopMonitoringAuctionData(Region region, string realm);
        void StopMonitoringAuctionDataAll();
    }
}
