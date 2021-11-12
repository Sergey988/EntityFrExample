using System;
using System.Collections.Generic;

namespace EntityFrExample_FluentAPI_
{
    class Flight 
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual ICollection<Client> Cliets{ get; set; }
    }
}
