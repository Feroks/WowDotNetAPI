using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;

namespace Explorers.Standard.Tests
{
    [TestClass]
    internal class SpellTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Spell_Data()
        {
            var spell = _explorer.GetSpellData(8056);
            Assert.IsNotNull(spell);
        }
    }
}
