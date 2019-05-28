using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUber
{
    public class Day
    {
        private List<Booking> _bookings = new List<Booking>();
        private int _numBookings;
        private Weekday _name;

        public Day()
        {
            _numBookings = 0;
            _name = Weekday.Monday;
        }

        public Day(Weekday aName)
        {
            _numBookings = 0;
            _name = aName;
        }

        public Weekday Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int NumBookings()
        {
            return _numBookings;
        }

        public void AddBookings(Booking aBooking)
        {
            _bookings.Add(aBooking);
            _numBookings += 1;
        }

        public bool CheckBookings(string aTutorName)
        {
            bool result = true;

            //returns false if the booking has already been made//
            foreach (Booking aBooking in _bookings)
            {
                if (aBooking.TutorName == aTutorName)
                {
                    result = false;
                }
            }
            
            return result;
        }

        public void RemoveBooking(string aUsername, bool aIsTutor)
        {
            Booking lBooking = getBooking(aUsername, aIsTutor);
            if(lBooking != null)
            {
                _bookings.Remove(getBooking(aUsername, aIsTutor));
                _numBookings--;
            }
        }

        //returns a list of all bookings, used for saving
        public List<Booking> getAllBookings()
        {
            return _bookings;
        }

        //searches bookings given a username and depending on if the user is a tutor.
        public Booking getBooking(string aUserName, Boolean aIsTutor)
        {
            //if there are no bookings, the tutor and student will be blank with a price of 0
            Booking lBooking = new Booking();
            lBooking = null;
            
            //Tutor
            if (aIsTutor == true)
            {
                foreach (Booking aBooking in _bookings)
                {
                    if (aBooking.TutorName == aUserName)
                    {

                        lBooking = aBooking;
                    }
                }
            }
            else if(aIsTutor == false)
            //Student
            {
                foreach (Booking aBooking in _bookings)
                {
                    if (aBooking.StudentName == aUserName)
                    {
                        lBooking = aBooking;
                    }
                }
            }

            return lBooking;
        }
    }
}
