using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUber;

namespace TUberTest
{
    [TestClass]
    public class CalendarTest
    {
        private readonly string lTutorName = "atutor";
        private readonly string lStudentName = "astudent";
        private readonly int lPrice = 55;
        private readonly Weekday lWeekDay = Weekday.Wednesday;

        [TestMethod]
        public void TestLoadandSave()
        {
            Calendar lCalendar = new Calendar();
            lCalendar.AddBooking(lTutorName, lStudentName, lPrice, lWeekDay);
            lCalendar.SaveDays(Globals.TEST_FILE_NAME);
            Calendar lNewCalendar = new Calendar();
            lNewCalendar.LoadDays(Globals.TEST_FILE_NAME);

            Booking lBookingOld = lCalendar.GetBookings(lTutorName, lWeekDay, true);
            Booking lBookingNew = lNewCalendar.GetBookings(lTutorName, lWeekDay, true);

            Assert.AreEqual(lBookingOld.StudentName, lBookingNew.StudentName);
        }

        [TestMethod]
        public void TestAddBookingandGetBooking()
        {
            Calendar lCalendar = new Calendar();
            lCalendar.AddBooking(lTutorName, lStudentName, lPrice, lWeekDay);

            Assert.AreEqual((lCalendar.GetBookings(lTutorName, lWeekDay, true)).TutorName, lTutorName);
        }

        [TestMethod]
        public void TestCheck()
        {
            Calendar lCalendar = new Calendar();
            lCalendar.AddBooking(lTutorName, lStudentName, lPrice, lWeekDay);

            Assert.IsFalse(lCalendar.Check(lTutorName, lWeekDay));
        }
    }
}
