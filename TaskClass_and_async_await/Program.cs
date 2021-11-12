using System;
using System.Threading.Tasks;

namespace TaskClass_and_async_await
{
    class Program
    {
        //Create a program using the Task class.
        //User enters some text data, then the program analyzes it and shows the result of: 
        //count of sentences, words, letters, punctuations and etc.

        //'! ','? ','. '
        static void CountOfSentencesAsync(string str)
        {
            Task.Run(()=> 
            {
                int count = 0;

                for (int i = 0; i < str.Length; i++)
                    if( str[i] == '!' || str[i] == '?' || str[i] == '.' )
                        count++;    
      
                Console.WriteLine($"Count of sentences - {count}");
            });
        }

        static void CountOfWordsAsync(string str)
        {
            Task.Run(() =>
            {
                int count = 0;

                for (int i = 0; i < str.Length; i++)
                    if (str[i] == ' ')
                        count++;


                Console.WriteLine($"Count of words - {count+1}");
            });
        }

        static async Task<int> CountOfLettersAsync(string str)
        {
            return await Task.Run(() =>
            {
                int count = 0;

                for (int i = 0; i < str.Length; i++)
                        count++;

                return count;
            });
        }

        static async Task<int> CountOfPunctuationsAsync(string str)
        {
            return await Task.Run(() =>
            {
                int count = 0;

                for (int i = 0; i < str.Length; i++)
                    if (str[i] == '!' || str[i] == '?' || str[i] == '.' || str[i] == ',' || str[i] == ':' || str[i] == ';')
                        count++;

                return count;
            });
        }

        static async void Run2AsyncMethod(string str)
        {
            int res1 = await CountOfLettersAsync(str);
            int res2 = await CountOfPunctuationsAsync(str);

            Console.WriteLine($"Count of letters - {res1}");
            Console.WriteLine($"Count of pounctuations - {res2}");
        }

        static void Main(string[] args)
        {
            //Console.Write("Plz enter some text: ");
            //string str = Console.ReadLine();

            string str = "Lorem; ipsum dolor sit amet, consectetur: adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua? Ut enim ad minim veniam, quis nostrud exercitation: ullamco laboris nisi ut aliquip ex ea, commodo consequat. Duis aute irure dolor in reprehenderit; in, voluptate velit esse cillum dolore, eu fugiat nulla pariatur! Excepteur, sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt, mollit anim id est laborum.";

            CountOfSentencesAsync(str);
            CountOfWordsAsync(str);
            Run2AsyncMethod(str);

            Console.WriteLine("End the main thread !!!");
        }
    }
}
