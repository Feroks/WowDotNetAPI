using System;
using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models;
using WowDotNetAPI.Models.BattleNetApi.Realm;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class RealmTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void GetAll_US_Realms_Returns_All_Realms()
        {
            var realmList = _explorer.GetRealms();
            Assert.IsTrue(realmList.Any());
        }

        [TestMethod]
        public void Get_Valid_US_Realm_Returns_Unique_Realm()
        {
            var realm = _explorer.GetRealms().FirstOrDefault(r => r.Name.Equals("skullcrusher", StringComparison.OrdinalIgnoreCase));
            Assert.IsNotNull(realm);
            Assert.IsTrue(realm.Name == "Skullcrusher");
            Assert.IsTrue(realm.Type == RealmType.PVP);
            Assert.IsTrue(realm.Slug == "skullcrusher");
        }

        [TestMethod]
        public void Get_All_Realms_By_Type_Returns_Pvp_Realms()
        {
            var realms = _explorer.GetRealms().Where(r => r.Type == RealmType.PVP).ToList();
            var allCollectedRealmsArePvp = realms.Any() && realms.All(r => r.Type == RealmType.PVP);
            Assert.IsTrue(allCollectedRealmsArePvp);
        }

        [TestMethod]
        public void Get_All_Realms_By_Status_Returns_Realms_That_Are_Up()
        {
            var realmList = _explorer.GetRealms().Where(r => r.Status).ToList();
            //All servers being down is likely(maintenance) and will cause test to fail
            var allCollectedRealmsAreUp = realmList.Any() && realmList.All(r => r.Status);
            Assert.IsTrue(allCollectedRealmsAreUp);
        }

        [TestMethod]
        public void Get_All_Realms_By_Queue_Returns_Realms_That_Do_Not_Have_Queues()
        {
            var realmList = _explorer.GetRealms().Where(r => r.Queue == false).ToList();
            //All servers getting queues is unlikely but possible and will cause test to fail
            var allCollectedRealmsHaveQueues = realmList.Any() && realmList.All(r => r.Queue == false);
            Assert.IsTrue(allCollectedRealmsHaveQueues);
        }

        [TestMethod]
        public void Get_All_Realms_By_Population_Returns_Realms_That_Have_Low_Population()
        {
            var realmList = _explorer.GetRealms().Where(r => r.Population == "low").ToList();
            var allCollectedRealmsHaveLowPopulation = realmList.Any() && realmList.All(r => r.Population == "low");
            Assert.IsTrue(allCollectedRealmsHaveLowPopulation);
        }
    }
}
