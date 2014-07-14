using System;

namespace Methods
{
    class Methods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive");
            }
            if (!(a + b > c) || !(a + c > b) || !(b + c > a))
            {
                throw new ArgumentException("There is no such a triangle");
            }

            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }

        public static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("Invalid number!");
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("The input should be not null!");
            }
            if (elements.Length == 0)
            {
                throw new ArgumentException("The input should have at least one value!");
            }

            int maxNumber = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        public static void PrintNumberWithPrecisionTwo(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberInPercent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberWithAlignmentEight(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool CheckIfLineIsHorizontal(double x1, double x2)
        {
            bool isVertical = (x1 == x2);

            return isVertical;
        }

        public static bool CheckIfLineIsVertical(double y1, double y2)
        {
            bool isVertical = (y1 == y2);

            return isVertical;
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(ConvertDigitToWord(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintNumberWithPrecisionTwo(1.3);
            PrintNumberInPercent(0.75);
            PrintNumberWithAlignmentEight(2.30);

            double x1, x2, y1, y2;
            x1 = 3;
            x2 = 3;
            y1 = -1;
            y2 = 2.5;

            Console.WriteLine(CalcDistance(x1, y1, x2, y2));

            bool horizontal, vertical;
            horizontal = CheckIfLineIsHorizontal(x1, x2);
            vertical = CheckIfLineIsVertical(y1, y2);

            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.PersonalInfo = new PersonalInformation("17.03.1992", "Sofia");

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.PersonalInfo = new PersonalInformation("03.11.1993", "Vidin", "gamer");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
