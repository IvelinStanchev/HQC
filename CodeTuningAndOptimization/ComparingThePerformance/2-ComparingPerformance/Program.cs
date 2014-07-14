using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ComparingPerformance
{
    class Program
    {
        public const int VALUE = 5;

        static void Main(string[] args)
        {
            CalculatePerformanceOfAddingAndPrintResult();
            Console.WriteLine(new string('-', 50));
            CalculatePerformanceOfSubstractingAndPrintResult();
            Console.WriteLine(new string('-', 50));
            CalculatePerformanceOfIncrementingAndPrintResult();
            Console.WriteLine(new string('-', 50));
            CalculatePerformanceOfMultiplyingAndPrintResult();
            Console.WriteLine(new string('-', 50));
            CalculatePerformanceOfDividingAndPrintResult();
        }

        public static void PrintElapsedTime(string action, string type, Stopwatch elapsedTime)
        {
            Console.WriteLine("{0} {1} numbers: {2}", action, type, elapsedTime.Elapsed);
        }

        public static void CalculatePerformanceOfAddingAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            AddNumbers(VALUE);
            watch.Stop();
            PrintElapsedTime("Adding", "int", watch);

            watch.Start();
            AddNumbers((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Adding", "double", watch);

            watch.Start();
            AddNumbers((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Adding", "decimal", watch);

            watch.Start();
            AddNumbers((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Adding", "float", watch);

            watch.Start();
            AddNumbers((long)VALUE);
            watch.Stop();
            PrintElapsedTime("Adding", "long", watch);
        }

        public static void CalculatePerformanceOfSubstractingAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            SubstractNumbers(VALUE);
            watch.Stop();
            PrintElapsedTime("Substracting", "int", watch);

            watch.Start();
            SubstractNumbers((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Substracting", "double", watch);

            watch.Start();
            SubstractNumbers((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Substracting", "decimal", watch);

            watch.Start();
            SubstractNumbers((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Substracting", "float", watch);

            watch.Start();
            SubstractNumbers((long)VALUE);
            watch.Stop();
            PrintElapsedTime("Substracting", "long", watch);
        }

        public static void CalculatePerformanceOfIncrementingAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            IncrementNumbers(VALUE);
            watch.Stop();
            PrintElapsedTime("Incrementing", "int", watch);

            watch.Start();
            IncrementNumbers((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Incrementing", "double", watch);

            watch.Start();
            IncrementNumbers((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Incrementing", "decimal", watch);

            watch.Start();
            IncrementNumbers((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Incrementing", "float", watch);

            watch.Start();
            IncrementNumbers((long)VALUE);
            watch.Stop();
            PrintElapsedTime("Incrementing", "long", watch);
        }

        public static void CalculatePerformanceOfMultiplyingAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            MultiplyNumbers(VALUE);
            watch.Stop();
            PrintElapsedTime("Multiplying", "int", watch);

            watch.Start();
            MultiplyNumbers((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Multiplying", "double", watch);

            watch.Start();
            MultiplyNumbers((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Multiplying", "decimal", watch);

            watch.Start();
            MultiplyNumbers((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Multiplying", "float", watch);

            watch.Start();
            MultiplyNumbers((long)VALUE);
            watch.Stop();
            PrintElapsedTime("Multiplying", "long", watch);
        }

        public static void CalculatePerformanceOfDividingAndPrintResult()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            DivideNumbers(VALUE);
            watch.Stop();
            PrintElapsedTime("Diving", "int", watch);

            watch.Start();
            DivideNumbers((double)VALUE);
            watch.Stop();
            PrintElapsedTime("Diving", "double", watch);

            watch.Start();
            DivideNumbers((decimal)VALUE);
            watch.Stop();
            PrintElapsedTime("Diving", "decimal", watch);

            watch.Start();
            DivideNumbers((float)VALUE);
            watch.Stop();
            PrintElapsedTime("Diving", "float", watch);

            watch.Start();
            DivideNumbers((long)VALUE);
            watch.Stop();
            PrintElapsedTime("Diving", "long", watch);
        }

        public static void AddNumbers(dynamic number)
        {
            for (int i = 0; i < 1000000; i++)
            {
                number = number + i * 100;
            }
        }

        public static void SubstractNumbers(dynamic number)
        {
            for (int i = 0; i < 1000000; i++)
            {
                number = number - i * 100;
            }
        }

        public static void IncrementNumbers(dynamic number)
        {
            for (int i = 0; i < 1000000; i++)
            {
                number++;
            }
        }

        public static void MultiplyNumbers(dynamic number)
        {
            for (int i = 0; i < 1000000; i++)
            {
                number = number * i;
            }
        }

        public static void DivideNumbers(dynamic number)
        {
            for (int i = 0; i < 1000000; i++)
            {
                number = number / 1;
            }
        }
    }
}
