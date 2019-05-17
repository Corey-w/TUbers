using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUber;

namespace TUberTest
{
    [TestClass]
    public class DayTest
    {
        private readonly string lTutorName = "atutor";
        private readonly string lStudentName = "astudent";
        private readonly int lPrice = 55;

        [TestMethod]
        public void TestAddandGet()
        {


            Booking lBooking = new Booking(lTutorName, lStudentName, lPrice);

            Day lMonday = new Day();

            lMonday.AddBookings(lBooking);

            Assert.AreEqual(lMonday.getBooking(lStudentName, false), lBooking);
            Assert.AreEqual(lMonday.getBooking(lTutorName, true), lBooking);
        }

        [TestMethod]
        public void TestCheckBooking()
        {
            Booking lBooking = new Booking(lTutorName, lStudentName, lPrice);
            Day lMonday = new Day();

            lMonday.AddBookings(lBooking);

            Assert.IsTrue(lMonday.CheckBookings("anothertutor"));
            Assert.IsFalse(lMonday.CheckBookings(lTutorName));
        }
    }
}
