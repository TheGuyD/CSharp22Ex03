using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CountCapitals : IExecute
    {
        public void Execute()
        {
            Console.WriteLine("Please enter your sentence: ");

            string userInputSentence = Console.ReadLine();
            int countUpperCase = 0;
            
            foreach (char character in userInputSentence)
            {
                if(char.IsUpper(character)) countUpperCase++;
            }

            Console.WriteLine("There are {0} capitals in your sentence.", countUpperCase);
        }
    }

    internal class ShowVersion : IExecute
    {
        public void Execute()
        {
            Console.WriteLine("Version: 22.1.4.8930");
        }
    }

    internal class ShowDate : IExecute
    {
        public void Execute()
        {
            Console.WriteLine("Date: {0}", DateTime.Now.ToString("dd MMMM, yyyy"));
        }
    }

    internal class ShowTime : IExecute
    {
        public void Execute()
        {
            Console.WriteLine("Time: {0:hh:mm:ss tt}", DateTime.Now);
        }
    }
}
