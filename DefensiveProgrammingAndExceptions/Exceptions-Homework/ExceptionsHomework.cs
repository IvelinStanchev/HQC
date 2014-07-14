using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr.Length == 0)
        {
            throw new ArgumentOutOfRangeException("The array should contains minimum one character!");
        }
        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException("The start index should be positive number!");
        }
        if (startIndex > arr.Length)
        {
            throw new ArgumentOutOfRangeException("The start index should be lower than the number of characters!");
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("The count should be positive number!");
        }
        if (count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("The count should be lower than the number of characters!");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null)
        {
            throw new ArgumentNullException("The text cannot be null!");
        }
        if (str == string.Empty)
        {
            throw new ArgumentException("The text should contains at least one character!");
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("The count should be a positive number!");
        }
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("The count should be lower than the text length!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("The number should be a positive number!"); 
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        //If you want to see if the exception works correctly just uncomment the next row
        //Console.WriteLine(ExtractEnding("Hi", 100));

        bool isPrime = CheckPrime(23);
        Console.WriteLine("23 is prime -> {0}", isPrime);

        isPrime = CheckPrime(33);
        Console.WriteLine("33 is prime -> {0}", isPrime);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
