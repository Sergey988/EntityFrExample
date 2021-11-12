namespace EntityFrExample_FluentAPI_
{
    class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int NumberOfPessengers { get; set; }
        public string Country { get; set; }
        public int FlightNumber { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
