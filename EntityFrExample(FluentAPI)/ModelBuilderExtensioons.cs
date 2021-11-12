using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EntityFrExample_FluentAPI_.Configurations
{
    public static class ModelBuilderExtensioons
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Airplane airplane = new Airplane()
            {
                Id = 1,
                Model = "Boeing",
                Type = "Passenger",
                NumberOfPessengers = 189,
                Country = "USA",
                FlightNumber = 505
               
            };
            
            Flight flight = new Flight()
            {
                Id = 1,
                Number = 505,
                DepartureDate = new System.DateTime(2021, 11, 01),
                ArrivalDate = new System.DateTime(2021, 11, 01),
                DepartureCity = "Rivne",
                ArrivalCity = "Kiev",
                AirplaneId = 1 
            };

            Client client = new Client()
            {
                Id = 1,
                Name = "Serg",
                Email = "sdf@gmail.com",
                Gender = "male",
                FlightNumber = flight.Id
            };

            Account account = new Account()
            {
                Login = "user1",
                Password = "qwerty",
                ClientId = 1
            };

            modelBuilder.Entity<Client>().HasData(client);
            modelBuilder.Entity<Account>().HasData(account);
            modelBuilder.Entity<Flight>().HasData(flight);
            modelBuilder.Entity<Airplane>().HasData(airplane);
        }
    }
}
