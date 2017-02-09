using System.Linq;
using Explorers.Standard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class MountTests
    {
        private static IExplorer _explorer;
        private static readonly string ApiKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _explorer = new WowExplorer(Region.Us, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public void Get_Mount_List()
        {
            var mounts = _explorer.Misc.GetMounts();
            Assert.IsTrue(mounts.Any());
        }
    }
}
