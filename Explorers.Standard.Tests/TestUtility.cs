using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Explorers.Standard.Tests
{
    [TestClass]
    public class TestUtility
    {
        public static void ThrowsException<T>(Action action, string expectedMessage) where T : Exception
        {
            try
            {
                action.Invoke();
                Assert.Fail("Exception of type {0} should be thrown", typeof(T));
            }
            catch (T e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
            }
        }
        
    }
}
