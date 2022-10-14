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
        
        public interface ITimeProvider {
        DateTime Now { get; }
    }

    public class SystemTimeProvider : ITimeProvider {
        public virtual DateTime Now { get { return DateTime.Now; } }
    }

    public class MockTimeProvider : ITimeProvider {
        public virtual DateTime Now { get; set; }
    }

    public class ServiceThatDependsOnTime {
        protected virtual ITimeProvider { get; set; }
        public ServiceThatDependsOnTime(ITimeProvider timeProvider) {
            TimeProvider = timeProvider;
        }
        public virtual void DoSomeTimeDependentOperation() {
            var now = TimeProvider.Now;
            //use 'now' in some complex processing.
        }
    }


        [TestMethod]
        public void TestMethod2()
        {
            var time = new MockTimeProvider();
            time.Now = DateTime.Now.AddDays(-500);
            var service = new ServiceThatDependsOnTime(time);
            service.DoSomeTimeDependentOperation();
            //check that the service did it right.
        }

    }
}