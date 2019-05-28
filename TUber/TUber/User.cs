using System;
using System.Collections.Generic;
using System.Text;

namespace TUber
{
    public abstract class User
    {
        private string userName;

        public User(string aName)
        {
            userName = aName;
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public abstract bool Book(Calendar aCalendar);

        virtual public void AddSubject(Subject aSubject)
        {
        }
    }
}
