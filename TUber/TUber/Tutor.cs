using System;
using System.Collections.Generic;
using System.Text;

namespace TUber
{
    public class Tutor : User
    {
        private List<Subject> mySubjects;
        private int fPrice;

        public Tutor(string aName) : base (aName)
        {
            fPrice = 0;
            mySubjects = new List<Subject>();
        }

        /*
        public string LoadTutor()
        {
            return UserName + " teaches " + mySubject + " and charges " + (fPrice) + " per tute.";
        }
        */

        public void AddSubject(Subject aSubject)
        {
            mySubjects.Add(aSubject);
        } 

        public int Price
        {
            get { return fPrice; }

            set { fPrice = value; }
        }

        public List<Subject> GetSubjects()
        {
            return mySubjects;
        }

        public override bool Book(Calendar aCalendar)
        {
            return true;
        }
    }
}
