using System;
using System.Threading.Tasks;

namespace TaskClass_and_async_await_Ex2
{
    class Program
    {
        //Create a program to find the next values in some array of numbers: 
        //the min and max value, average and sum.

        static void GetMinValue(int[] arr)
        {
            Task.Run(() =>
            {
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                    if (arr[i] < min)
                        min = arr[i];

                Console.WriteLine($"Min value of array - {min}");
            });
        }

        static void GetMaxValue(int[] arr)
        {
            Task.Run(() =>
            {
                int max = arr[0];
                for (int i = 1; i < arr.Length; i++)
                    if (arr[i] > max)
                        max = arr[i];

                Console.WriteLine($"Max value of array - {max}");
            });
        }

        static async Task<int> GetAverageValue(int[] arr)
        {
            return await Task.Run(() =>
            {
                int average = 0;
                for (int i = 0; i < arr.Length; i++)
                    average += arr[i];
                
                return average/arr.Length;
            });
        }

        static async Task<int> GetSumOfArrray(int[] arr)
        {
            return await Task.Run(() =>
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                    sum += arr[i];
                
                return sum;
            });
        }

        static async void Run2AsyncMethod(int[] arr)
        {
            int res1 = await GetAverageValue(arr);
            int res2 = await GetSumOfArrray(arr);

            Console.WriteLine($"Average value of array - {res1}");
            Console.WriteLine($"Sum of array - {res2}");
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int lengthOfArray = 50;
            int[] array = new int[lengthOfArray];

            for (int i = 0; i < lengthOfArray; i++)
            {
                array[i] = rand.Next(100);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();

            GetMinValue(array);
            GetMaxValue(array);
            Run2AsyncMethod(array);
            Console.WriteLine("End the main thread !!!");

            Console.ReadKey();
        }
    }
}
