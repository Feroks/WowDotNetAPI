﻿using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class ItemTests
    {
        private static IExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Sample_Item_38268()
        {
            var sampleItem = _explorer.Item.GetItem(38268);

            Assert.AreEqual("Spare Hand", sampleItem.Name);
            Assert.AreEqual("Give to a Friend", sampleItem.Description);
            Assert.AreEqual("inv_gauntlets_09", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(0, sampleItem.ItemBind);
            Assert.AreEqual("WORLD_DROP", sampleItem.ItemSource.SourceType);
            Assert.AreEqual(1, sampleItem.WeaponInfo.Damage.MaxDamage);
        }

        [TestMethod]
        public void Get_Sample_Item_39564()
        {
            var sampleItem = _explorer.Item.GetItem(39564);

            Assert.AreEqual(@"Heroes' Bonescythe Legplates", sampleItem.Name);
            Assert.AreEqual("", sampleItem.Description);
            Assert.AreEqual("inv_pants_mail_15", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(1, sampleItem.ItemBind);
            Assert.AreEqual("VENDOR", sampleItem.ItemSource.SourceType);

            Assert.AreEqual(null, sampleItem.WeaponInfo);

            Assert.AreEqual(4, sampleItem.AllowableClasses.First());
            Assert.AreEqual(16, sampleItem.BonusStats.ElementAt(2).Amount);

            Assert.AreEqual("PRISMATIC", sampleItem.SocketInfo.Sockets.First().Type);
        }

        [TestMethod]
        public void Get_Sample_Item_17182()
        {
            var sampleItem = _explorer.Item.GetItem(17182);

            Assert.AreEqual("Sulfuras, Hand of Ragnaros", sampleItem.Name);
            Assert.AreEqual("", sampleItem.Description);
            Assert.AreEqual("inv_hammer_unique_sulfuras", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(1, sampleItem.ItemBind);

            Assert.AreEqual("CREATED_BY_SPELL", sampleItem.ItemSource.SourceType);

            Assert.AreEqual(3.7, sampleItem.WeaponInfo.WeaponSpeed);

            Assert.AreEqual(8, sampleItem.BonusStats.ElementAt(1).Amount);
            Assert.AreEqual("2 sec cast", sampleItem.ItemSpells.First().Spell.CastTime);
        }

        [TestMethod]
        public void Get_Sample_Gem_52210()
        {
            var sampleItem = _explorer.Item.GetItem(52210);

            Assert.AreEqual("+8 Parry and +4 Stamina", sampleItem.GemInfo.Bonus.Name);
            Assert.AreEqual("PURPLE", sampleItem.GemInfo.Type.Color);
            Assert.AreEqual(sampleItem.Id, sampleItem.GemInfo.Bonus.SourceItemId);
            Assert.AreEqual(0, sampleItem.GemInfo.Bonus.RequiredSkillRank);
            Assert.AreEqual(0, sampleItem.GemInfo.Bonus.MinLevel);
            Assert.AreEqual(290, sampleItem.GemInfo.Bonus.ItemLevel);
        }
    }
}
