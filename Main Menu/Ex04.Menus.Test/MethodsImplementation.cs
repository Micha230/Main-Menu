using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
   internal class MethodsImplementation
    {
        public static void ShowVersion()
        {
            Console.WriteLine("Version: 23.1.4.8859");
        }

        public static void CountUppercase()
        {
            Console.WriteLine("Please enter a sentence in English:");
            string userSentence = Console.ReadLine();
            int countUppercase = 0;

            for (int i = 0; i < userSentence.Length; i++)
            {
                if (char.IsUpper(userSentence[i]))
                {
                    countUppercase++;
                }
            }

            Console.WriteLine("There are {0} upper case letters in your sentence.", countUppercase);
        }

        public static void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        public static void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }
    }
}
