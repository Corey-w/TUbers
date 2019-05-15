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
        private readonly Weekday lWeekDay = Weekday.wednesday;

        [TestMethod]
        public void TestLoadandSave()
        {
            Calendar lCalendar = new Calendar();
            lCalendar.AddBooking(lTutorName, lStudentName, lPrice, lWeekDay);
            string lFileName = "database.txt";
            lCalendar.SaveDays(lFileName);
            Calendar lNewCalendar = new Calendar();
            lNewCalendar.LoadDays("database.txt");

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
