﻿using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class ChallengesTests
    {
        private static WowExplorer _explorer;
        private static Challenges _challenges;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);            
        }

        [TestMethod]
        public void Get_Challenges_From_Skullcrusher()
        {
            _challenges = _explorer.GetChallenges("skullcrusher");
            Assert.IsTrue(_challenges.Challenge.Any());            
            Assert.AreEqual("Auchindoun", _challenges.Challenge.First().Map.Name);
        }
    }
}
