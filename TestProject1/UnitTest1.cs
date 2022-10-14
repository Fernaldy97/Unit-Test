using Microsoft.VisualStudio.TestTools.UnitTesting;
//DateTimeProvider implementation
public static class DateTimeProvider
{
    private static Func<DateTime> _dateTimeNowFunc = () => DateTime.Now;
    public static DateTime Now => _dateTimeNowFunc();

    public static void Set(Func<DateTime> dateTimeNowFunc)
    {
        _dateTimeNowFunc = dateTimeNowFunc;
    }
}

//DateTimeProvider usage in app logic
public class User
{
    public DateTime CreatedAt { get; } = DateTimeProvider.Now;
}

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
           DateTimeProvider.Set(() => new DateTime(2021, 07, 20));
           var user = new User();
           Assert.Equal(new DateTime(2021, 07, 20), user.CreatedAt);
        }

    }
}