using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TaskClass_and_async_await_Ex3
{


    //User enters a path to a directory.
    //The program should find the existing duplicated files by name and shows the statistics of them: 
    //file name - count of duplicates.

    //Analyze the subdirectories also.

    class Program
    {

        public static string directoryPass = @"C:\Users\User\source\repos\EntityFrExample\TaskClass_and_async_await_Ex3\Test";
        static void Main(string[] args)
        {
            //Console.Write("Please specify the directory: ");
            //string directoryPass = Console.ReadLine();


            PrintDupFilesAsync();
            PrintAllDirAsync();

            Console.ReadKey();

        }


        static async void PrintDupFilesAsync()
        {

            Dictionary<string, int> res = await ShowDuplicatedFiles();

            foreach (KeyValuePair<string, int> item in res)
                Console.WriteLine($"{item.Key} - {item.Value}");
        }


        static async void PrintAllDirAsync()
        {

            List<string> ls = await Task.Run(() => GetRecursDirs(directoryPass));
            
            Console.WriteLine($"\nShow all dir and subdir in - {directoryPass}");
            
            foreach (string fname in ls)
                Console.WriteLine(fname);
        }



        static Task<Dictionary<string, int>> ShowDuplicatedFiles()
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Show file name and quantity in - {directoryPass}");

                string[] filesPass = Directory.GetFiles(directoryPass);

                Dictionary<string, int> filesNameDictionary = new Dictionary<string, int>(filesPass.Length);
                string[] filesNameArr = new string[filesPass.Length];


                for (int i = 0; i < filesNameArr.Length; i++)
                {
                    FileInfo fileInf = new FileInfo(filesPass[i]);
                    filesNameArr[i] = fileInf.Name.Substring(0, fileInf.Name.IndexOf('.'));
                }


                for (int i = 0; i < filesNameArr.Length; i++)
                {
                    if (i == 0)
                        filesNameDictionary.Add(filesNameArr[i], 1);
                    else
                    {
                        foreach (KeyValuePair<string, int> item in filesNameDictionary)
                        {
                            if (item.Key == filesNameArr[i])
                            {
                                int number = item.Value + 1;
                                filesNameDictionary[item.Key] = number;
                            }
                        }
                        if (!filesNameDictionary.ContainsKey(filesNameArr[i]))
                            filesNameDictionary.Add(filesNameArr[i], 1);
                    }
                }
                return filesNameDictionary;
            });
        }


        static List<string> GetRecursDirs(string start_path)
        {

                List<string> ls = new List<string>();
                try
                {
                    string[] folders = Directory.GetDirectories(start_path);
                    foreach (string folder in folders)
                    {

                        ls.Add(folder.Substring(directoryPass.Length));
                        //ls.Add(folder);
                        ls.AddRange(GetRecursDirs(folder));
                    }

                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return ls;

        }

    }
}
