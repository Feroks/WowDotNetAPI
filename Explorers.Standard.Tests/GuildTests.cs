using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI;
using WowDotNetAPI.Models;

namespace Explorers.Standard.Tests
{
    [TestClass]
    public class GuildTests
    {
        private static WowExplorer _explorer;
        private static Guild _guild;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
            _guild = _explorer.GetGuild("korgath", "immortality", GuildOptions.GetEverything);
        }

        [TestMethod]
        public void Get_Simple_Guild_Immortality_From_Korgath()
        {
            Assert.IsTrue(_guild.Realm.Equals("korgath", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, _guild.Side);
            Assert.IsTrue(_guild.Members.Any());
        }

        [TestMethod]
        public void Get_Valid_Night_Elf_Member_From_Immortality_Guild()
        {
            var guildMember = _guild.Members.FirstOrDefault(m => m.Character.Name.Equals("fleas", StringComparison.OrdinalIgnoreCase));

            Assert.IsTrue(guildMember.Character.Name.Equals("fleas", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(110, guildMember.Character.Level);
            Assert.AreEqual(CharacterClass.DRUID, guildMember.Character.Class);
            Assert.AreEqual(CharacterRace.NIGHT_ELF, guildMember.Character.Race);
            Assert.AreEqual(CharacterGender.MALE, guildMember.Character.Gender);
        }

        [TestMethod]
        public void Get_Valid_Member_From_Another_Guild()
        {
            var guild = _explorer.GetGuild("laughing skull", "deus vox", GuildOptions.GetMembers | GuildOptions.GetAchievements);


            Assert.IsNotNull(guild.Members);
            Assert.IsNotNull(guild.AchievementPoints);

            Assert.IsTrue(guild.Name.Equals("deus vox", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(guild.Realm.Equals("laughing skull", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(guild.Members.Any());

            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Valid_Member_From_Horde_Guild()
        {
            var guild = _explorer.GetGuild("skullcrusher", "rage", GuildOptions.GetMembers);

            Assert.IsNotNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Name.Equals("rage", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.OrdinalIgnoreCase));

            Assert.IsTrue(guild.Members.Any());

            Assert.IsTrue(guild.Side == UnitSide.HORDE);
        }

        [TestMethod]
        public void Get_Guild_With_Only_Achievements()
        {
            var guild = _explorer.GetGuild("skullcrusher", "immortality", GuildOptions.GetAchievements);

            Assert.IsNull(guild.Members);
            Assert.IsNotNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Only_Members()
        {
            var guild = _explorer.GetGuild("skullcrusher", "immortality", GuildOptions.GetMembers);

            Assert.IsNotNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Only_No_Options()
        {
            var guild = _explorer.GetGuild("skullcrusher", "immortality", GuildOptions.None);

            Assert.IsNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Base_Method_Call()
        {
            var guild = _explorer.GetGuild("skullcrusher", "immortality");

            Assert.IsNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Connected_Realms() {
            var explorer = new WowExplorer(Region.EU, Locale.en_GB, ApiKey);
            var guild = explorer.GetGuild("darksorrow", "mentality", GuildOptions.GetMembers);
            //var guildMembers = guild2.Members.Where(x => x.Character.Name.Equals("Danishpala", StringComparison.CurrentCultureIgnoreCase)).ToList();
            var guildMaster = guild.Members.OrderBy(x => x.Rank).First().Character;

            Assert.AreEqual("Doomtráin", guildMaster.Name);
            // TODO: check connected realm
            //Assert.AreEqual(1, guildMembers.Count(x => !x.Character.Realm.Equals(x.Character.GuildRealm)));
        }
    }
}
