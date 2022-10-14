using Microsoft.VisualStudio.TestTools.UnitTesting;

public interface ISystemClock
{
    DateTime Now { get; }
}

public class SystemClock : ISystemClock
{
    public DateTime Now
        => DateTime.Now;
}

public class CreditCardValidator : AbstractValidator<CreditCard>
{
    public CreditCardValidator(ISystemClock systemClock)
    {
        var now = systemClock.Now;
        // Beep, beep, boop
        // Rest of the code here...
    }
}

public class FixedDateClock : ISystemClock
{
    private readonly DateTime _when;

    public FixedDateClock(DateTime when)
    {
        _when = when;
    }

    public DateTime Now
        => _when;
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
            var when = new DateTime(2021, 01, 01);
            var clock = new FixedDateClock(when);
        // This time we're passing a fake clock implementation
            var validator = new CreditCardValidator(clock);
        //                                      ^^^^^

            var request = new CreditCardBuilder()
                        .WithExpirationYear(when.AddYears(-1).Year)
                        .Build();
            var result = validator.TestValidate(request);

            result.ShouldHaveAnyValidationError();
        }

    }
}