using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Parallel_class_Task_2
{

    //Write a program that read the numbers from the file to the list.
    //Determine if each number is even, simple or perfect.


    class Program
    {

        static string fileName = "listOfNumbers.txt";

        static void Main(string[] args)
        {
            WriteNumbersToFile();

            List<int> myList = GetNumberFromFile();
            Parallel.ForEach(myList, ShowNumberType);

        }



        static bool isSimple(int n)
        {
            if (n == 0)
                return false;
            if (n == 2)
                return true;

            if (n < 2 || n % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }
        static bool isPerfect(int n)
        {
            int sum = 0;
            if (n == 0)
                return false;

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                    sum = sum + i;

            }
            return (sum == n) ? true : false;
        }
        static bool isEven(int n)
        {
            return (n % 2 == 0) ? true : false;
        }

        static void ShowNumberType(int number)
        {

            if (isEven(number) == true)
                Console.WriteLine($"Number {number} is even");
            else
                Console.WriteLine($"Number {number} is odd");

            if (isSimple(number) == true)
                Console.WriteLine($"Number {number} is simple");

            if (isPerfect(number) == true)
                Console.WriteLine($"Number {number} is perfect");
        }

        static List<int> GetNumberFromFile()
        {
            string docPath = @"Result\" + fileName;
            List<int> intList = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(docPath))
                {
                    string c = sr.ReadToEnd();
                    intList = c.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return intList;
        }


        static void WriteNumbersToFile()
        {

            Directory.CreateDirectory("Result");
            string docPath = @"Result\" + fileName;
            Random rnd = new Random();

            using (StreamWriter sw = new StreamWriter(docPath, false, System.Text.Encoding.Default))
            {
                int k;
                for (k = 1; k <= 15; k++)
                    sw.Write($"{rnd.Next(100)} ");


                Console.WriteLine($"File with {k-1} numbers created");
            }

        }
    }
}
