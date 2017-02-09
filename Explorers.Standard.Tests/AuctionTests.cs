using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.Auction;
using WowDotNetAPI.Models.HelperModels;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AuctionTests
    {
        private static IExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        private readonly List<NewAuctionDataEventArgs> _onNewDataEventList = new List<NewAuctionDataEventArgs>();

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Auction_Data()
        {
            Auctions auctions = _explorer.Auction.GetAuctions("skullcrusher");
            Assert.IsTrue(auctions.CurrentAuctions.Any());
            Assert.IsTrue(auctions.Realm.Any());
        }

        [TestMethod]
        public void Get_Auction_DataAge()
        {
            var age = _explorer.Auction.GetAuctionDataAge("skullcrusher");
            Assert.IsTrue(age.CompareTo(new TimeSpan(0)) == 1);
        }

        [TestMethod]
        public void Auction_Data_Monitoring_Start_And_Stop()
        {
            const Region region = Region.Us;
            const string realm = "Agamaggan";

            _explorer.Auction.StartMonitoringAuctionData(region, realm, TimeSpan.FromSeconds(60));
            Assert.IsTrue(_explorer.Auction.MonitoredAuctionDataRealms.Count() == 1);

            _explorer.Auction.StopMonitoringAuctionData(region, realm);
            Assert.IsTrue(!_explorer.Auction.MonitoredAuctionDataRealms.Any());
        }

        [TestMethod]
        public void Auction_Data_Monitoring_Start_And_Stop_All()
        {
            _explorer.Auction.StartMonitoringAuctionData(Region.Us, "Agamaggan", TimeSpan.FromSeconds(60));
            _explorer.Auction.StartMonitoringAuctionData(Region.Us, "Illidan", TimeSpan.FromSeconds(60));
            _explorer.Auction.StartMonitoringAuctionData(Region.Us, "Sargeras", TimeSpan.FromSeconds(60));
            
            Assert.IsTrue(_explorer.Auction.MonitoredAuctionDataRealms.Count() == 3);
            Assert.IsTrue(_explorer.Auction.MonitoredAuctionDataRealms.Count(x => x.Region == Region.Us && x.Realm == "Illidan") == 1);

            _explorer.Auction.StopMonitoringAuctionDataAll();
            Assert.IsTrue(!_explorer.Auction.MonitoredAuctionDataRealms.Any());
        }

        [TestMethod]
        public void Auction_Data_Monitoring_On_New_Data()
        {
            const Region region = Region.Us;
            const string realm = "Agamaggan";

            _explorer.Auction.OnAuctionDataUpdate += _explorer_OnAuctionDataUpdate;
            _explorer.Auction.StartMonitoringAuctionData(region, realm, TimeSpan.FromSeconds(60));

            Thread.Sleep(TimeSpan.FromSeconds(10));

            Assert.IsTrue(_onNewDataEventList.Any());
            Assert.IsTrue(_onNewDataEventList.First().DateTime < DateTime.Now);
        }

        private void _explorer_OnAuctionDataUpdate(object sender, NewAuctionDataEventArgs e)
        {
            _onNewDataEventList.Add(e);
        }
    }
}