using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;

namespace Explorers.Standard.Tests
{
    [TestClass]
    public class QuestTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Quest_Data()
        {
            var questData = _explorer.GetQuestData(13146);
            Assert.IsNotNull(questData);
        }
    }
}
