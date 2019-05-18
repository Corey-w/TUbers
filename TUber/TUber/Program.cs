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

            bool endprogram = false;
            bool endsession = false;
            bool isTutor = false;
            /*
            Calendar lCalendar = new Calendar();
            lCalendar.AddBooking("James", "John", 120, Weekday.Friday);
            lCalendar.AddBooking("Corey", "Ryan", 60, Weekday.Wednesday);
            lCalendar.AddBooking("Henry", "Aaron", 24, Weekday.Monday);
            */
            while (!endprogram)
            {
                {
                    Console.WriteLine("Welcome to TUber\n");
                    Console.WriteLine("Pick an option: \n1. Tutor Login\n2. Student Login");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    while ((choice != 1) && (choice != 2))
                    {
                        Console.WriteLine("Please enter a valid option.");
                        choice = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine("Please Enter a Username: \n");

                    string username = Console.ReadLine();
                    User lUser;

                    if (choice == 1)
                    {
                        lUser = new Tutor(username);
                        isTutor = true;
                    }
                    else
                    {
                        lUser = new Student(username);
                    }

                    Calendar lCalendar = new Calendar();
                    lCalendar.LoadDays(Globals.FILE_NAME);

                    while (!endsession)
                    {
                        Console.WriteLine("Current Schedule: \n");
                        lCalendar.Print();
                        Console.WriteLine("1. Make Booking \n2. Remove Booking \n");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if (isTutor)
                        {
                            if (choice == 1)
                            {
                                Console.WriteLine("Enter students name: ");
                                string tempname = Console.ReadLine();
                                Console.WriteLine("Enter day for booking: ");
                                string tempday = Console.ReadLine();
                                lCalendar.AddBooking(lUser.UserName, tempname, (lUser as Tutor).Price, WeekdayMethods.StringtoWeekday(tempday));
                            }
                            else
                            {
                                Console.WriteLine("Enter day the booking is on: ");
                                string tempday = Console.ReadLine();
                                lCalendar.RemoveBooking(lUser.UserName, WeekdayMethods.StringtoWeekday(tempday), true);
                            }
                        }

                        else
                        {
                            if (choice == 1)
                            {
                                Console.WriteLine("Enter tutors name: ");
                                string tempname = Console.ReadLine();
                                Console.WriteLine("Enter day for booking: ");
                                string tempday = Console.ReadLine();
                                lCalendar.AddBooking(lUser.UserName, tempname, (lUser as Tutor).Price, WeekdayMethods.StringtoWeekday(tempday));
                            }
                            else
                            {
                                Console.WriteLine("Enter day the booking is on: ");
                                string tempday = Console.ReadLine();
                                lCalendar.RemoveBooking(lUser.UserName, WeekdayMethods.StringtoWeekday(tempday), false);
                            }
                        }

                        Console.WriteLine("1. Continue\n2. Logout\n3. Quit");
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 3)
                        {
                            endsession = true;
                            endprogram = true;
                        }
                        else if (choice == 2)
                        {
                            endsession = true;
                        }
                    }
                }
            }
        }
    }
}
