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
            bool isTutor = false;

            while (!Globals.END_PROGRAM)
            {
                {
                    Globals.END_SESSION = false;

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
                        Console.WriteLine("Enter price: ");
                        string price = Console.ReadLine();
                        lUser = new Tutor(username, Convert.ToInt32(price));
                        isTutor = true;
                    }
                    else
                    {
                        lUser = new Student(username);
                        isTutor = false;
                    }

                    Calendar lCalendar = new Calendar();
                    lCalendar.LoadDays(Globals.FILE_NAME);
                    //lCalendar.LoadTutors(Globals.TUTOR_FILE_NAME); //

                    while (!Globals.END_SESSION)
                    {
                        Console.WriteLine("System wide bookings: \n");
                        lCalendar.Print();
                        Console.WriteLine("1. Make Booking \n2. Remove Booking \n3. Logout\n4. Quit\n");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if(choice == 4)
                        {
                            lCalendar.SaveDays(Globals.FILE_NAME);
                            Globals.END_PROGRAM = true;
                            Globals.END_SESSION = true;
                        }
                        else if (choice == 3)
                        {
                            lCalendar.SaveDays(Globals.FILE_NAME);
                            Globals.END_SESSION = true;
                        }

                        else
                        {
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

                                if (choice == 3)
                                {
                                    Globals.END_SESSION = true;
                                }

                                else if (choice == 1)
                                {
                                    Console.WriteLine("Enter tutors name: ");
                                    string tempname = Console.ReadLine();
                                    Console.WriteLine("Enter day for booking: ");
                                    string tempday = Console.ReadLine();
                                    lCalendar.AddBooking(tempname, lUser.UserName, lCalendar.GetTutor(tempname).Price, WeekdayMethods.StringtoWeekday(tempday));
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
                                lCalendar.SaveDays(Globals.FILE_NAME);
                                //lCalendar.SaveTutors(Globals.TUTOR_FILE_NAME);//
                                Globals.END_SESSION = true;
                                Globals.END_PROGRAM = true;
                            }

                            else if (choice == 2)
                            {
                                lCalendar.SaveDays(Globals.FILE_NAME);
                                //lCalendar.SaveTutors(Globals.TUTOR_FILE_NAME); //
                                Globals.END_SESSION = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
