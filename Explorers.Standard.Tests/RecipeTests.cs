using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class RecipeTests
    {
        private static IExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Recipe_Data()
        {
            var recipe = _explorer.Misc.GetRecipeData(33994);
            Assert.IsNotNull(recipe);
        }
    }
}
