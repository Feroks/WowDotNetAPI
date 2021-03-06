﻿using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AchievementTests
    {
        private static IExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Achievements_List()
        {
            var achievements = _explorer.Achievment.GetAchievements();
            Assert.IsTrue(achievements != null && achievements.Any());
        }

        [TestMethod]
        public void Get_Achievement_Details()
        {
            var achievement = _explorer.Achievment.GetAchievement(2144);
            Assert.IsNotNull(achievement);
        }

        [TestMethod]
        public void Get_Guild_Achievements_List()
        {
            var achievements = _explorer.Achievment.GetGuildAchievements();
            Assert.IsTrue(achievements != null && achievements.Any());
        }
    }
}
