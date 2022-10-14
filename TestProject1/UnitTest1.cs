using Microsoft.VisualStudio.TestTools.UnitTesting;

//DateTimeProvider implementation
public class DateTimeProvider
{
    private readonly DateTime? _dateTime = null;

    public DateTimeProvider(DateTime fixedDateTime)
        => _dateTime = fixedDateTime;

    public DateTime Now => _dateTime ?? DateTime.Now;
}

//DI-Container registration
services.AddScoped<DateTimeProvider>();

//DateTimeProvider usage in app logic
public class User
{
    public User(DateTimeProvider dateTimeProvider)
    {
        CreatedAt = dateTimeProvider.Now;
    }

    public DateTime CreatedAt { get; }
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