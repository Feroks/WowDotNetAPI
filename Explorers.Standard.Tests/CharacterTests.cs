using System;
using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class CharacterTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;
        private const Region WowRegion = Region.Us;
        private const Locale WowLocale = Locale.en_US;
        private const string CharacterName = "briandek";
        private const string Realm = "korgath";
        private const int Level = 110;
        private const CharacterClass CClass = CharacterClass.Warrior;
        private const CharacterRace CRace = CharacterRace.Human;
        private const CharacterGender CGender = CharacterGender.Male;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(WowRegion, WowLocale, ApiKey);
        }

        [TestMethod]
        public void Get_Simple_Character()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithGuild()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetGuild);

            Assert.IsNotNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithStats()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetStats);

            Assert.IsNull(briandek.Guild);
            Assert.IsNotNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithTalents()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetTalents);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNotNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithItems()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetItems);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNotNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
			Assert.IsNull(briandek.Items.Tabard);
        }

		[TestMethod]
		public void Get_Simple_Character_WithItems_Tabard() {
			string characterNameWithTabard = "Taichibi";
			var briandek = _explorer.GetCharacter(Realm, characterNameWithTabard, CharacterOptions.GetItems);
			Assert.IsNotNull(briandek.Items);
			Assert.IsTrue(briandek.Name.Equals(characterNameWithTabard, StringComparison.OrdinalIgnoreCase));
			Assert.IsNotNull(briandek.Items.Tabard);
		}

		[TestMethod]
        public void Get_Simple_Character_WithReputations()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetReputation);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNotNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithTitles()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetTitles);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNotNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithProfessions()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetProfessions);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNotNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithAppearance()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetAppearance);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNotNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithPetSlots()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetPetSlots);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNotNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
            Assert.IsTrue(briandek.PetSlots.Any());
        }

        [TestMethod]
        public void Get_Simple_Character_WithMounts()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetMounts);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNotNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
            Assert.IsTrue(briandek.Mounts.NumCollected > 1);
            Assert.IsTrue(briandek.Mounts.NumNotCollected > 1);
        }

        [TestMethod]
        public void Get_Simple_Character_WithAchievements()
        {

            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetAchievements);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNotNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_WithProgression()
        {

            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetProgression);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNotNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Complex_Character()
        {
            var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetEverything);

            Assert.IsNotNull(briandek.Guild);
            Assert.IsNotNull(briandek.Stats);
            Assert.IsNotNull(briandek.Talents);
            Assert.IsNotNull(briandek.Items);
            Assert.IsNotNull(briandek.Reputation);
            Assert.IsNotNull(briandek.Titles);
            Assert.IsNotNull(briandek.Professions);
            Assert.IsNotNull(briandek.Appearance);
            Assert.IsNotNull(briandek.PetSlots);
            Assert.IsNotNull(briandek.Mounts);
            Assert.IsNotNull(briandek.Pets);
            Assert.IsNotNull(briandek.Achievements);
            Assert.IsNotNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(Level, briandek.Level);
            Assert.AreEqual(CClass, briandek.Class);
            Assert.AreEqual(CRace, briandek.Race);
            Assert.AreEqual(CGender, briandek.Gender);
        }

		[TestMethod]
		public void Get_Artifact_Weapon() {
			var briandek = _explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetEverything);

			Assert.IsNotNull(briandek.Items);
			Assert.IsTrue(briandek.Items.MainHand.ArtifactId > 0);
			Assert.IsTrue(briandek.Items.MainHand.Relics.Any());
		}
	}
}
