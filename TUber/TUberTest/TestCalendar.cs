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

        private readonly string lTutorName2 = "Ron Glass";
        private readonly Subject lSubject1 = Subject.English;
        private readonly Subject lSubject2 = Subject.Math;

        [TestMethod]
        public void TestLoadandSaveTutor()
        {
            Calendar lCalendar = new Calendar();
            Tutor lTutor = new Tutor(lTutorName, lPrice);

            lTutor.Price = lPrice;
            lTutor.AddSubject(lSubject1);
            lTutor.AddSubject(lSubject2);
            lCalendar.AddTutor(lTutor);

            lCalendar.SaveTutors(Globals.TUTOR_FILE_NAME);
            lCalendar.LoadTutors(Globals.TUTOR_FILE_NAME);

            Assert.AreEqual(lTutor.UserName, lCalendar.GetTutor(lTutorName).UserName);
        }

        [TestMethod]
        public void TestMultipleLoadandSaveTutor()
        {
            Calendar lCalendar = new Calendar();

            //create a new tutor with different values
            Tutor lTutor2 = new Tutor(lTutorName2,lPrice);

            lTutor2.Price = lPrice + 100;
            //as of this iteration repeated subjects are not expected to be caught
            lTutor2.AddSubject(lSubject2);
            lTutor2.AddSubject(lSubject2);
            lTutor2.AddSubject(lSubject2);
            lTutor2.AddSubject(lSubject2);
            lTutor2.AddSubject(lSubject2);
            lTutor2.AddSubject(lSubject2);
            lCalendar.AddTutor(lTutor2);

            //we reload to check it has added another tutor
            lCalendar.LoadTutors(Globals.TUTOR_FILE_NAME);
            lCalendar.SaveTutors(Globals.TUTOR_FILE_NAME);
            lCalendar.LoadTutors(Globals.TUTOR_FILE_NAME);

            Assert.AreEqual(lTutor2.UserName, lCalendar.GetTutor(lTutorName2).UserName);

        }

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
