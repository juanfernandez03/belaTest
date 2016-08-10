using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bela.Helpers;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodCheckSize()
        {
            //
            LogHelpers.CheckSize();
        }
        [TestMethod]
        public void TestMethodCheckSizw()
        {
            string msg = "Error msg";
            LogHelpers.WriteLog(msg,Enumerations.LevelAudit.Error);
            
        }

    }
}
