using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class PetTests
    {
        private static IExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Pet_List()
        {
            var pets = _explorer.Pet.GetPets();
            Assert.IsTrue(pets.Any());
        }

        [TestMethod]
        public void Get_Pet_Ability_Details()
        {
            var ability = _explorer.Pet.GetPetAbilityDetails(640);
            Assert.IsNotNull(ability);
        }

        [TestMethod]
        public void Get_Pet_Species()
        {
            var species = _explorer.Pet.GetPetSpeciesDetails(258);
            Assert.IsNotNull(species);
        }

        [TestMethod]
        public void Get_Pet_Stats()
        {
            var stats = _explorer.Pet.GetPetStats(258, 25, 5, 4);
            Assert.IsNotNull(stats);
        }

        [TestMethod]
        public void Get_Pet_Types()
        {
            var types = _explorer.Pet.GetPetTypes();
            Assert.IsTrue(types.Any());
        }
    }
}
