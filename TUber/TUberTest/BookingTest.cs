using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUber;

namespace TUberTest
{
    [TestClass]
    public class BookingTest
    {

        [TestMethod]
        public void TestCreate()
        {
            string lTutorName = "atutor";
            string lStudentName = "astudent";
            int lPrice = 55;

            Booking lBooking = new Booking(lTutorName, lStudentName, lPrice);

            Assert.AreEqual(lTutorName, lBooking.TutorName);
            Assert.AreEqual(lStudentName, lBooking.StudentName);
            Assert.AreEqual(lPrice, lBooking.Price);
        }
    }
}
