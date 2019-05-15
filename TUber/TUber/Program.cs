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
            Calendar lCalendar = new Calendar();
            Weekday lWeekDay = Weekday.wednesday;


            //no file path saves in Debug
            string lFileName = "database.txt";

            Console.WriteLine(DataAccess.Check(lFileName));

            //Loads bookings from textfile into days
            lCalendar.LoadDays(lFileName);

            //Add Booking
            lCalendar.AddBooking("Some Tutor", "Some User", 20, lWeekDay);
            Console.WriteLine("saving....");

            //Save to textfile
            lCalendar.SaveDays(lFileName);
            Console.ReadLine();            
        }
    }
}
