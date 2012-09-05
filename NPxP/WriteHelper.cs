using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NPxP
{
    public class WriteHelper
    {
        const string PATH = @"c:\temp\PxPLifeCycle.txt";
        static object lockMe = new object();
        public static int i = 1;
        public WriteHelper()
        {

        }
        public static void Log(string msg )
        {
           
            lock (lockMe)
            {
                using (StreamWriter sw = new StreamWriter(PATH, true))
                {
                    sw.WriteLine(i + ". : " + msg + "\r");
                    sw.Close(); 
                } 
                i++;
            }
        }
    }
}
