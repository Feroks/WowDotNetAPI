using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Auction
{
    public class AuctionFiles
    {
        public AuctionFiles()
        {
            Files = new AuctionFile[0];
        }

        public IEnumerable<AuctionFile> Files { get; set; }
    }
}
