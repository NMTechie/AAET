using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CAAAETInfraStructure.Logging;
using CAAAETCommon.CustomException;

namespace CAAAETInfraStructure.UnitTests
{
    [TestClass]    
    public class LogHelperUnitTest
    {
        [TestMethod]
        [TestCategory("UnitTestLogHelper")]
        [Priority(3)]
        public void WriteInfo()
        {
            string information = "TESTING INFORMATION WRITTING";
            Assert.AreEqual(LogHelper.GetLogger().WriteInfo(information), true);
        }

        [TestMethod]
        [TestCategory("UnitTestLogHelper")]
        [Priority(3)]
        public void WriteWarning()
        {
            string information = "TESTING WARNING WRITTING";
            Assert.AreEqual(LogHelper.GetLogger().WriteInfo(information), true);
        }

        [TestMethod]
        [TestCategory("UnitTestLogHelper")]
        [Priority(3)]
        public void WriteException()
        {
            Exception ex = new Exception("TESTING Exception WRITTING");
            Assert.AreEqual(LogHelper.GetLogger().WriteException(ex), true);
        }

        [TestMethod]
        [TestCategory("UnitTestLogHelper")]
        [Priority(3)]
        public void WriteBusinessException()
        {
            CAAAETException ex = new CAAAETException("TESTING BUSINESS EXCEPTION WRITTING");
            Guid errorId;
            if (!Guid.TryParse(LogHelper.GetLogger().WriteBusinessException(ex),out errorId))
            {
                Assert.Fail("Return errorid is not a GUID. The exception has not been logged");
            }      
        }
    }
}
