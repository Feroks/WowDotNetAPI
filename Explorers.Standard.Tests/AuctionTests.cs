using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;
using WowDotNetAPI.Models;

namespace Explorers.Standard.Tests
{
    [TestClass]
    public class AuctionTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Auction_Data()
        {
            Auctions auctions = _explorer.GetAuctions("skullcrusher");
            Assert.IsTrue(auctions.CurrentAuctions.Any());
        }
    }
}