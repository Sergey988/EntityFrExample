using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFrExample
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() 
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Artist>()
            //    .HasData(
            //         new Artist() { Id = 1, Name = "Dima", Surname = "Bilan"}
            //         //new Artist() { Id = 2, Name = "Michael", Surname = "Jackson"},
            //         //new Artist() { Id = 3, Name = "Sviatoslav", Surname = "Vakarchuk"},
            //         //new Artist() { Id = 4, Name = "Paul", Surname = "Van Haver"},
            //         //new Artist() { Id = 5, Name = "Luciano", Surname = "Pavarotti"}
            //     );







            //var country = new[]
            //{
            //     new Country{Id = 1, Name = "Russia"},
            //     new Country{Id = 2, Name = "USA" }
            //};
            //modelBuilder.Entity<Country>().HasData(country);

            //var artist = new[]
            //{
            //     new Artist{Id = 1, Name = "Dima", Surname = "Bilan", Country = country[0]},
            //     new Artist{Id = 2, Name = "Michael", Surname = "Jackson", Country = country[1]},
            //     new Artist{Id = 3, Name = "Sviatoslav", Surname = "Vakarchuk", Country = country[1]}
            //};


            //modelBuilder.Entity<Artist>().HasData(artist);



        }

        // Database Collection

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Track> Traks { get; set; }
        public virtual DbSet<PlayList> PlayLists { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

    }

    // Entities

    public class Artist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public virtual Country Country { get; set; }
        //navigation properties
        public virtual ICollection<Album> Albums { get; set; }

    }

    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }

    }

    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public virtual Genre Genre { get; set; }
        [Required]
        public virtual Artist Artist { get; set; }
        [Required]
        virtual public ICollection<Track> Tracks { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual ICollection<Album> Albums { get; set; }
    }
    
    public class Track
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        virtual public Album Album { get; set; }
    }
    
    public class PlayList
    {
        public int Id { get; set; }
        [Required]        
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public virtual ICollection<Track> Tracks { get; set; }
    }
    
    public class Category
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<PlayList> PlayLists { get; set; }
    }

}
