using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TUber
{
    class DataAccess
    {

        //Checks for file/database exists
        public static Boolean Check(string afileName)
        {
            return File.Exists(afileName);
        }

        //Reads the file/database and returns an array seperated by lines
        //CHECK FILE EXISTS BEFORE CALLING THIS FUNCTION
        public static string[] Read(string afileName)
        {
            string[] lines = File.ReadAllLines(afileName);
           
            return lines;
        }

        //writes to file/database, creates new file/database if it cannot be found
        public static void Write(string afileName, List <string> aContent)
        {
            System.IO.File.WriteAllLines(afileName, aContent);
        }

    }
}
