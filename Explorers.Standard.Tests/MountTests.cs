﻿using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class MountTests
    {
        private static WowExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Mount_List()
        {
            var mounts = _explorer.GetMounts();
            Assert.IsTrue(mounts.Any());
        }
    }
}
