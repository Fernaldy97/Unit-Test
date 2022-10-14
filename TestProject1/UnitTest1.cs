using Microsoft.VisualStudio.TestTools.UnitTesting;

//Interface
public interface IDateTimeProvider
{
    DateTime GetNow();
}

//Implementation with real DateTime.Now
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetNow() => DateTime.Now;
}

//DI-Container registration
services.AddScoped<IDateTimeProvider, DateTimeProvider>();

//App logic 
public class User
{
    public User(IDateTimeProvider dateTimeProvider)
    { 
        CreatedAt = dateTimeProvider.GetNow();
    }

    public DateTime CreatedAt { get; }
}

//FixedDateTimeProvider implementation for unit tests
public class FixedDateTimeProvider : IDateTimeProvider
{
    private DateTime _fixedDateTime;

    public FixedDateTimeProvider(DateTime fixedDateTime)
        => _fixedDateTime = fixedDateTime;

    public DateTime GetNow() => _fixedDateTime;
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
            User user = new User(new FixedDateTimeProvider(new DateTime(2021, 07, 20)));

            Assert.Equal(new DateTime(2021, 07, 20), user.CreatedAt);
        }

    }
}