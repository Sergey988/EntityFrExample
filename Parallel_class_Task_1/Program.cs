using System;
using System.Threading.Tasks;
using System.IO;


namespace Parallel_class_Task_1
{
    //Create a program that writes the multiplication tables into the files.
    //User inputs the range boundary, then the program write the multiplication table
    //of each number to separate file.
    //For example, boundaries: 5, 8
    //Output:

    //5 * 1 = 5
    //5 * 2 = 10
    //...........
    //5 * 10 = 50
    //6 * 1 = 6
    //6 * 2 = 12
    //...........
    //8 * 10 = 80


    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Plz inputs the range boundary.");
            //Console.Write("First number: ");
            //int firstNumber = Int32.Parse(Console.ReadLine());
            //Console.Write("Second number: ");
            //int secondNumber = Int32.Parse(Console.ReadLine());
           
            int firstNumber = 3;
            int secondNumber = 10;

            Parallel.For(firstNumber, secondNumber+1, WriteMultiTable);

            static void WriteMultiTable(int number)
            {
                string fileName = "MultiTable_" + number + "x.txt";

                Directory.CreateDirectory("Result");
                string docPath = @"Result\" + fileName;

                //if want add text to the file need to change param to "true"
                using (StreamWriter sw = new StreamWriter(docPath, false, System.Text.Encoding.Default))
                {

                    for (int k = 1; k <= 10; k++)
                        sw.WriteLine($"{number} * {k} = {number * k}");

                    Console.WriteLine($"File {fileName} created: {DateTime.Now.ToString("HH:mm:ss:ms")}");

                }
            }
        }
    }
}
