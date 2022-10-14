using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Program.addNumbers(2, 3), 5);
        }
        [TestMethod]
        public void TestMethod2()
        {
            SystemTime.Now = () => new DateTime(2000,1,1);
            repository.ResetFailures(failedMsgs); 
            SystemTime.Now = () => new DateTime(2000,1,2);
            var msgs = repository.GetAllReadyMessages(); 
            Assert.AreEqual(2, msgs.Length);
        }

    }
}