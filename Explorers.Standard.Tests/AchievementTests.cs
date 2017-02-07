using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;

namespace Explorers.Standard.Tests
{
    [TestClass]
    public class AchievementTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Achievements_List()
        {
            var achievements = _explorer.GetAchievements();
            Assert.IsTrue(achievements != null && achievements.Any());
        }

        [TestMethod]
        public void Get_Achievement_Details()
        {
            var achievement = _explorer.GetAchievement(2144);
            Assert.IsNotNull(achievement);
        }

        [TestMethod]
        public void Get_Guild_Achievements_List()
        {
            var achievements = _explorer.GetGuildAchievements();
            Assert.IsTrue(achievements != null && achievements.Any());
        }
    }
}
