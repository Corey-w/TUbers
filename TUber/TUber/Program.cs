using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUber
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TUber\n");
            Console.WriteLine("Are you a student or tutor? (y/n)\n");

            char isTutor;

            do
            {   
                isTutor = (char)Console.Read();
                if(isTutor != 'y' || isTutor != 'n')
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            } while (isTutor != 'y' || isTutor != 'n');

            Console.WriteLine("Please Enter a Username: \n");

            string username = Console.ReadLine();

            if(isTutor == 'y')
            {
                User lUser = new Tutor(username);
            }
            else
            {
                User lUser = new Student(username);
            }

            Calendar lCalendar = new Calendar();

            Console.WriteLine("Do you want to make a booking? \n");




            //no file path saves in Debug

            //Console.WriteLine(DataAccess.Check(Globals.FILE_NAME));

            //Loads bookings from textfile into days
            lCalendar.LoadDays(Globals.FILE_NAME);

            //Add Booking
            //lCalendar.AddBooking("Some Tutor", "Some User", 20, lWeekDay);
            Console.WriteLine("saving....");

            //Save to textfile
            lCalendar.SaveDays(Globals.FILE_NAME);
            Console.ReadLine();  
        }
    }
}
