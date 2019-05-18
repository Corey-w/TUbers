using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUber;

namespace TUberTest
{
    [TestClass]
    public class TutorTest
    {
        private readonly string lTutorName1 = "Aaron Douglas";
        private readonly string lTutorName2 = "Ron Glass";
        private readonly int lPrice = 60;
        private readonly Subject lSubject1 = Subject.English;
        private readonly Subject lSubject2 = Subject.Math;

        [TestMethod]
        public void TestLoadandSaveTutor()
        {
            Calendar lCalendar = new Calendar();
            Tutor lTutor = new Tutor(lTutorName1);

            lTutor.Price = lPrice;
            lTutor.AddSubject(lSubject1);
            lTutor.AddSubject(lSubject2);
            lCalendar.AddTutor(lTutor);

            lCalendar.SaveTutors(Globals.TUTOR_FILE_NAME);
            lCalendar.LoadTutors(Globals.TUTOR_FILE_NAME);

            Assert.AreEqual(lTutor.UserName, lCalendar.GetTutor(lTutorName1).UserName);
        }

        [TestMethod]
        public void TestMultipleLoadandSaveTutor()
        {
            Calendar lCalendar = new Calendar();

            //create a new tutor with different values
            Tutor lTutor2 = new Tutor(lTutorName2);

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

    }
}