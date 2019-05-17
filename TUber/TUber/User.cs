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

        public virtual string GetUser()
        {
            return userName;
        }
    }
}
