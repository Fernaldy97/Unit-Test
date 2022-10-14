using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calendar
{
    public class EventChecker
    {
        private IDateTimeProvider _dateTimeProvider;

        public EventChecker(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public bool CanScheduleEvent()
        {
            return _dateTimeProvider.GetCurrentTime().DayOfWeek == DayOfWeek.Saturday
                || _dateTimeProvider.GetCurrentTime().DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public interface IDateTimeProvider
    {
        DateTime GetCurrentTime();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }

    class FakeDateTimeProvider : IDateTimeProvider
    {
        private DateTime _time;

        public FakeDateTimeProvider(DateTime time)
        {
            _time = time;
        }

        public DateTime GetCurrentTime()
        {
            return _time;
        }
    }
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
            var eventChecker = new Calendar.EventChecker(new Calendar.FakeDateTimeProvider(new DateTime(2021, 4, 4)));

            var result = eventChecker.CanScheduleEvent();

            Assert.IsTrue(result);
        }

    }
}