using System;
using System.Collections.Generic;
using System.Text;

namespace TUber
{
    public class Student : User
    {

        public Student(string aName) : base (aName) {}

        public override bool Book(Calendar aCalendar)
        {
            return true;
        }
    }
}
