using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;
using WowDotNetAPI.Models;

namespace Explorers.Standard.Tests
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
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);            
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
