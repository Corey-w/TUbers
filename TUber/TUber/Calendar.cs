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
        private List<Tutor> Tutors = new List<Tutor>();

        public Calendar()
        {
            for (int i = 0; i < 5; i++)
                switch (i)
                {
                    case 0:
                        Days[i] = new Day(Weekday.Monday);
                        break;
                    case 1:
                        Days[i] = new Day(Weekday.Tuesday);
                        break;
                    case 2:
                        Days[i] = new Day(Weekday.Wednesday);
                        break;
                    case 3:
                        Days[i] = new Day(Weekday.Thursday);
                        break;
                    case 4:
                        Days[i] = new Day(Weekday.Friday);
                        break;
                    default:
                        Days[i] = new Day();
                        break;
                }
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
        */
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
        

        /*
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
        */
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

        public void RemoveBooking(string aUsername, Weekday aDay, bool isTutor)
        {
            Days[(int)aDay].RemoveBooking(aUsername, isTutor);
        }

        public void LoadTutors(string aFileName)
        {

            if (DataAccess.Check(aFileName) == true)
            {
                string[] lContent = DataAccess.Read(aFileName);
                int numberOfTutors = 0;
                int numberOfSubjects = 0;
                int line = 1;
                Subject lSubject;

                while (numberOfTutors < Convert.ToInt32(lContent[0]))
                {
                    numberOfSubjects = Convert.ToInt32(lContent[line]) + line + 3;
                    Tutor lTutor = new Tutor(lContent[line + 1], Convert.ToInt32(lContent[line + 2]));
                   // {
                    //    Price = ((Convert.ToInt32(lContent[line + 2])))
                    //};

                    line += 3;

                    while (line < numberOfSubjects)
                    {
                        lSubject = (Subject)Convert.ToInt32(lContent[line]);
                        lTutor.AddSubject(lSubject);
                        line++;
                    }
                    numberOfTutors += 1;
                    Tutors.Add(lTutor);
                }
            }
        }


        //saves tutors
        public void SaveTutors(string aFileName)
        {

            List<string> lContent = new List<string>();
            lContent.Add(Convert.ToString(Tutors.Count()));

            foreach (Tutor lTutor in Tutors)
            {
                {
                    //save number of subjects
                    lContent.Add(Convert.ToString(lTutor.GetSubjects().Count()));

                    //save tutor name
                    lContent.Add(lTutor.UserName);
                    // save price
                    lContent.Add(lTutor.Price.ToString());

                    foreach (Subject aSubject in lTutor.GetSubjects())
                    {
                        //save subject
                        lContent.Add((Convert.ToInt32(aSubject)).ToString());
                    }
                }
            }
            DataAccess.Write(aFileName, lContent);

        }

        public void AddTutor(Tutor aTutor)
        {
            Tutors.Add(aTutor);
        }

        public Tutor GetTutor(string UserName)
        {
            Tutor Result = new Tutor("", 0);
            foreach (Tutor lTutor in Tutors)
            {
                if (lTutor.UserName == UserName)
                {
                    Result = lTutor;
                    break;
                }
            }

            return Result;
        }

        public void ShowTutors()
        {
            foreach(Tutor lTutor in Tutors)
            {
                Console.Write(lTutor.UserName + " teaches ");
                foreach (Subject lSubject in lTutor.GetSubjects())
                {
                    Console.Write(lSubject + " ");
                }
                Console.Write("at $" + lTutor.Price + " a booking\n");
            }
        }


        public void Print()
        {
            foreach(Day aDay in Days)
            {
                if (aDay.NumBookings() != 0)
                {
                    foreach (Booking aBooking in aDay.getAllBookings())
                    {
                        Console.Write(aDay.Name + ": ");
                        aBooking.Print();
                    }
                }
            }
        }
    }
}
