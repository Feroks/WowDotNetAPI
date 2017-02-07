using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;

namespace Explorers.Standard.Tests
{
    [TestClass]
    public class RecipeTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Recipe_Data()
        {
            var recipe = _explorer.GetRecipeData(33994);
            Assert.IsNotNull(recipe);
        }
    }
}
