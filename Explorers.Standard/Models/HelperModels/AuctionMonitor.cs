using System.Threading;
using WowDotNetAPI.Models.BattleNetApi.Auction;

namespace WowDotNetAPI.Models.HelperModels
{
    internal class AuctionMonitor
    {
        internal AuctionMonitor(Timer timer, RealmRegionPair realmRegionPair)
        {
            Timer = timer;
            RealmRegionPair = realmRegionPair;
            AuctionFiles = new AuctionFiles();
        }

        internal AuctionMonitor(Timer timer, RealmRegionPair realmRegionPair, AuctionFiles auctionFiles) : this(timer, realmRegionPair)
        {
            AuctionFiles = auctionFiles;
        }

        internal RealmRegionPair RealmRegionPair { get; private set; }
        internal Timer Timer { get; private set; }
        internal AuctionFiles AuctionFiles { get; set; }
    }
}
