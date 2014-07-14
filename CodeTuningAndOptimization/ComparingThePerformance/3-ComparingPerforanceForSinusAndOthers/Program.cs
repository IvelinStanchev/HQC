using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_ComparingPerforanceForSinusAndOthers
{
    class Program
    {
        public const int VALUE = 5;

        static void Main(string[] args)
        {
            CalculatePerformanceOfSquareRootAndPrintResult();
            Console.WriteLine(new string('-', 50));
            CalculatePerformanceOfNaturalLogarithmAndPrintResult();
            Console.WriteLine(new string('-', 50));
            CalculatePerformanceOfSinusAndPrintResult();
        }

        public static void PrintElapsedTime(string action, string type, Stopwatch elapsedTime)
        {
            Console.WriteLine("{0} for {1} numbers: {2}", action, type, elapsedTime.Elapsed);
        }

        public static void CalculatePerformanceOfSquareRootAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            CalculateSquareRoot((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating square root", "float", watch);

            watch.Start();
            CalculateSquareRoot((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating square root", "double", watch);

            watch.Start();
            CalculateSquareRoot((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating square root", "decimal", watch);
        }

        public static void CalculatePerformanceOfNaturalLogarithmAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            CalculateNaturalAlgorithm((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating natural logarithm", "float", watch);

            watch.Start();
            CalculateNaturalAlgorithm((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating natural logarithm", "double", watch);

            watch.Start();
            CalculateNaturalAlgorithm((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating natural logarithm", "decimal", watch);
        }

        public static void CalculatePerformanceOfSinusAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            CalculateSinus((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating sinus", "float", watch);

            watch.Start();
            CalculateSinus((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating sinus", "double", watch);

            watch.Start();
            CalculateSinus((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Calculating sinus", "decimal", watch);
        }

        public static void CalculateSquareRoot(dynamic number)
        {
            if (number is decimal)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Math.Sqrt((double)number);
                }
            }
            else
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Math.Sqrt(number);
                }
            }
        }

        public static void CalculateNaturalAlgorithm(dynamic number)
        {
            if (number is decimal)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Math.Log((double)number);
                }
            }
            else
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Math.Log(number);
                }
            }
        }

        public static void CalculateSinus(dynamic number)
        {
            if (number is decimal)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Math.Sin((double)number);
                }
            }
            else
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Math.Sin(number);
                }
            }
        }
    }
}
