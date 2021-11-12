namespace EntityFrExample_FluentAPI_
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public int FlightNumber{ get; set; }
        public virtual Flight Flight { get; set; }
    }
}
