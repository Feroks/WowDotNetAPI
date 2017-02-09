using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class DataTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_BattleGroups_Test()
        {
            var battleGroups = _explorer.GetBattlegroupsData().ToList();

            Assert.AreEqual(9, battleGroups.Count); 
            Assert.IsTrue(battleGroups.Any(r => r.Name == "Rampage"));
        }

        [TestMethod]
        public void Get_Character_Races_Data()
        {
            var races = _explorer.GetCharacterRaces().ToList();

            Assert.AreEqual(15, races.Count);
            Assert.IsTrue(races.Any(r => r.Name == "Human" || r.Name == "Night Elf"));
        }

        [TestMethod]
        public void Get_Character_Achievements_Data()
        {
            var characterAchievements = _explorer.GetAchievements().ToList();

            Assert.AreEqual(15, characterAchievements.Count);
            var achievementList = characterAchievements.First(a => a.Id == 92);
            var gotMyMindOnMyMoneyAchievement = achievementList.Achievements.First(a => a.Id == 1181);
            Assert.AreEqual("Loot 25,000 gold", gotMyMindOnMyMoneyAchievement.Criteria.ElementAt(0).Description);
        }

        [TestMethod]
        public void Get_Character_Classes_Data()
        {
            var classes = _explorer.GetCharacterClasses().ToList();

            Assert.IsTrue(classes.Count == 12);
            Assert.IsTrue(classes.Any(r => r.Name == "Warrior" || r.Name == "Death Knight" || r.Name == "Demon Hunter"));
        }

        [TestMethod]
        public void Get_Guild_Achievements_Data()
        {
            var guildAchievementsList = _explorer.GetGuildAchievements();
            Assert.AreEqual(7, guildAchievementsList.Count());
        }

        [TestMethod]
        public void Get_Guild_Rewards_Data()
        {
            var rewards = _explorer.GetGuildRewards().ToList();
            Assert.AreEqual(64, rewards.Count);
            Assert.IsTrue(rewards.Any(r => r.Achievement != null));
        }

        [TestMethod]
        public void Get_Guild_Perks_Data()
        {
            var perks = _explorer.GetGuildPerks().ToList();
            Assert.AreEqual(5, perks.Count);
            Assert.IsTrue(perks.Any(r => r.Spell != null));
        }

        [TestMethod]
        public void Get_Realms_From_Json_String()
        {
            var realms1 = _explorer.GetRealms();
            var realms2 = JsonUtility.FromJsonString<RealmsData>(TestStrings.TestRealms).Realms;
            var realms3 = realms1.Intersect(realms2);
            Assert.AreEqual(0, realms3.Count());

        }

        [TestMethod]
        public void Get_Item_Classes()
        {
            var itemClasses = _explorer.GetItemClasses();
            Assert.AreEqual(16, itemClasses.Count());

        }
    }
}
