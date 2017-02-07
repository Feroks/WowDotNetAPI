using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class QuestTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Quest_Data()
        {
            var questData = _explorer.GetQuestData(13146);
            Assert.IsNotNull(questData);
        }
    }
}
