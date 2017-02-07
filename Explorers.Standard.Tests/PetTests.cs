using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;

namespace Explorers.Standard.Tests
{
    [TestClass]
    public class PetTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Pet_List()
        {
            var pets = _explorer.GetPets();
            Assert.IsTrue(pets.Any());
        }

        [TestMethod]
        public void Get_Pet_Ability_Details()
        {
            var ability = _explorer.GetPetAbilityDetails(640);
            Assert.IsNotNull(ability);
        }

        [TestMethod]
        public void Get_Pet_Species()
        {
            var species = _explorer.GetPetSpeciesDetails(258);
            Assert.IsNotNull(species);
        }

        [TestMethod]
        public void Get_Pet_Stats()
        {
            var stats = _explorer.GetPetStats(258, 25, 5, 4);
            Assert.IsNotNull(stats);
        }

        [TestMethod]
        public void Get_Pet_Types()
        {
            var types = _explorer.GetPetTypes();
            Assert.IsTrue(types.Any());
        }
    }
}
