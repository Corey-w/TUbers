using System;
using System.Collections.Generic;
using System.Text;

namespace TUber
{
    public class Tutor : User
    {
        private string userName;
        private Subject mySubject;
        private int fPrice;

        public Tutor(string aName) : base (aName)
        {
        }

        public string LoadTutor()
        {
            return userName + " teaches " + mySubject + " and charges " + (fPrice) + " per tute.";
        }

        public void AddSubject(Subject aSubject)
        {
            mySubject = aSubject;
        } 

        public int SetPrice
        {
            set { fPrice = value; }
        }

        public override string GetUser()
        {
            return userName;
        }
    }

}
}
