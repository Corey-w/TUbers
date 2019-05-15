using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUber
{
    class Calendar
    {
        //enumeration for the days of the week, the value refers to its position in the Days array
        public enum Weekday
        {
            monday = 0,
            tuesday = 1,
            wednesday = 2,
            thursday = 3,
            friday = 4
        }
        private Day[] Days= new Day[5];

        public Calendar()
        {
            for (int i = 0; i < 5; i++) 
                Days[i] = new Day();
        }

        /*Loads saved data into the Days array
        Format: 
        First line declares how many bookings on the day
        next line contains tutor, followed by student, then price. (this is the saved data for one booking
        repeats until all bookings are completed */
        public void LoadDays(string aFileName)
        {
            if (DataAccess.Check(aFileName) == true)
            {
                string[] lContent = DataAccess.Read(aFileName);
                int i = 1;
                int k = 0;
                Booking lBooking = new Booking();
                foreach (Day aDay in Days)
                {
                    while (i < System.Convert.ToInt32(lContent[0])*3)
                    {
                        lBooking.CreateBooking(lContent[i], lContent[i + 1], System.Convert.ToInt32(lContent[i + 2]));
                        aDay.AddBookings(lBooking);
                        i += 3;
                    }
                    k = i;
                    i = k + 1;
                }
            }
        }

        public void SaveDays(string aFileName)
        {
            List <string> lContent = new List<string>();
            foreach (Day aDay in Days)
            {
                {
                    //save number of bookings for that day
                    lContent.Add(aDay.NumBookings().ToString());

                    List <Booking> CurrentBooking = aDay.getAllBookings();
                    foreach (Booking aBooking in CurrentBooking)
                    {
                        //save booking information
                        lContent.Add(aBooking.TutorName);
                        lContent.Add(aBooking.StudentName);
                        lContent.Add(aBooking.Price.ToString());

                    }
                }
            }
            DataAccess.Write(aFileName, lContent);
         
        }

        //Adds booking under the tutors name and the students on a given day. Stores price.
        public void  AddBooking(string aTutorName, string aUserName, int aPrice, Weekday aDay)
        {
            Booking lBooking = new Booking();
            lBooking.CreateBooking(aTutorName, aUserName, aPrice);
            Days[(int)aDay].AddBookings(lBooking);
        }

        //Check if a booking under a tutors name appears on this day
        public Boolean Check(string aTutorName, Weekday aDay)
        {
            Boolean result = Days[(int)aDay].CheckBookings(aTutorName);
            return result;
        }

        //Returns the Bookings for a given day and username. If the User is not a tutor, set aIsTutor to false.
        public Booking GetBookings(string aUserName, Weekday aDay, Boolean aIsTutor)
        {
                return (Days[(int)aDay].getBooking(aUserName, aIsTutor));
        }



    }
}
