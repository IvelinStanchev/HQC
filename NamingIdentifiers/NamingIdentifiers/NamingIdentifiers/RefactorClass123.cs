using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingIdentifiers
{
    class Refactor
    {
        public const int MAX_COUNT = 6; // This variable isn't used

        private class Printer
        {
            public void Print(bool isBigger)
            {
                string isBiggerAsString = isBigger.ToString();
                Console.WriteLine(isBiggerAsString);
            }
        }

        public static void Main()
        {
            Refactor.Printer instance = new Refactor.Printer();
            instance.Print(true);
        }
    }
}
