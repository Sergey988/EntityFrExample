using System;

namespace EntityFrExample_FluentAPI_
{
    class Program
    {
        static void Main(string[] args)
        {
            AirLinesDb airLinesDb = new AirLinesDb();

            foreach (var item in airLinesDb.Clients)
            {
                Console.WriteLine($"{item.Id} {item.Account} {item.FlightNumber}");
            }
        }
    }
}
