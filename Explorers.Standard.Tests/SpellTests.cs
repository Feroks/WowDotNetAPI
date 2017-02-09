using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    internal class SpellTests
    {
        private static IExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Spell_Data()
        {
            var spell = _explorer.Misc.GetSpellData(8056);
            Assert.IsNotNull(spell);
        }
    }
}
