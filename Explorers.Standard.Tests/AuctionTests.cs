using System;
using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AuctionTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Auction_Data()
        {
            Auctions auctions = _explorer.GetAuctions("skullcrusher");
            Assert.IsTrue(auctions.CurrentAuctions.Any());
            Assert.IsTrue(auctions.Realm.Any());
        }

        [TestMethod]
        public void Get_Auction_DataAge()
        {
            var age = _explorer.GetAuctionDataAge("skullcrusher");
            Assert.IsTrue(age.CompareTo(new TimeSpan(0)) == 1);
        }
    }
}