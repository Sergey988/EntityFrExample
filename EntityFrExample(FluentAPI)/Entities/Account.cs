namespace EntityFrExample_FluentAPI_
{
     class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
