using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUber
{
    public class Booking
    {
        private string _tutorName = "";
        private string _studentName = "";
        private int _price = 0;


        public Booking()
        {
            _tutorName = "";
            _studentName = "";
            _price = 0;
        }

        public Booking(string aTutorName, string aStudentName, int aPrice)
        {
            _tutorName = aTutorName;
            _studentName = aStudentName;
            _price = aPrice;
        }


        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        public string TutorName
        {
            get { return _tutorName; }
            set { _tutorName = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
