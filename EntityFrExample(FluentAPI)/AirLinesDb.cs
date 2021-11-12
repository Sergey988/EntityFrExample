using EntityFrExample_FluentAPI_.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrExample_FluentAPI_
{
    class AirLinesDb : DbContext
    {
        public AirLinesDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AirLinesDb;Trusted_Connection=True;");

        }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);



            //FluentAPi

            //modelBuilder.ApplyConfiguration<Airplane>(new AirplaneConfiguration());
            //modelBuilder.ApplyConfiguration<Flight>(new FlightConfiguration());
            //modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            //modelBuilder.ApplyConfiguration<Account>(new AccountConfiguration());


            //You can use the ApplyConfigurationsFromAssembly extension method, which uses the
            //reflection to find all the configuration files and registers them automatically.

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirLinesDb).Assembly);

        }
    }
}
