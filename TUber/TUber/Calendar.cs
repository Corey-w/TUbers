using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TUber
{
    public class Calendar
    {
        //enumeration for the days of the week, the value refers to its position in the Days array

        private Day[] Days= new Day[5];

        public Calendar()
        {
            for (int i = 0; i < 5; i++) 
                Days[i] = new Day();
        }

        /*
        public void LoadDays(string aFileName)
        {
            StreamReader reader = new StreamReader(aFileName);
            try
            {
                using (reader)
                {
                    while (reader.Peek() > -1)
                    {
                        foreach (Day aDay in Days)
                        {
                            string numofbookings = reader.ReadLine();

                            for (int i = 0; i < Convert.ToInt32(numofbookings); i++)
                            {
                                string student, tutor, price;
                                tutor = reader.ReadLine();
                                student = reader.ReadLine();
                                price = reader.ReadLine();
                                aDay.AddBookings(new Booking(tutor, student, Convert.ToInt32(reader.ReadLine())));
                            }
                        }
                    }
                }
            }
            finally
            {
                reader.Close();
            }

        }

        public void SaveDays(string aFileName)
        {
            StreamWriter writer = new StreamWriter(aFileName);
            try
            {
                using (writer)
                {
                    foreach (Day aDay in Days)
                    {
                        writer.WriteLine(aDay.NumBookings().ToString());
                        List<Booking> CurrentBooking = aDay.getAllBookings();
                        foreach (Booking aBooking in CurrentBooking)
                        {
                            //save booking information
                            writer.WriteLine(aBooking.TutorName);
                            writer.WriteLine(aBooking.StudentName);
                            writer.WriteLine(aBooking.Price.ToString());
                        }
                    }
                }
            }

            finally
            {
                writer.Close();
            }
        }*/

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

                foreach (Day aDay in Days)
                {
                    while (i < k + System.Convert.ToInt32(lContent[k]) * 3)
                    {
                        Booking lBooking = new Booking(lContent[i], lContent[i + 1], System.Convert.ToInt32(lContent[i + 2]));
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
            Booking lBooking = new Booking(aTutorName, aUserName, aPrice);
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

        public void PrintCalendar()
        {
            
        }
    }
}
