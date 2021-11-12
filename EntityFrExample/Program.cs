using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext context = new MyDbContext();

            //Add
            //context.Countries.Add(new Country() { Name = "Ukraine"});
            //context.Countries.Add(new Country() { Name = "USA"});

            //Edit
            //Country element = context.Countries.First(c => c.Name == "Russia");

            //delete
            //context.Countries.Remove(element);


            //Country country1 = new Country { Name = "Russia" };
            //Country country2 = new Country { Name = "USA" };
            //Country country3 = new Country { Name = "Ukraine" };
            //Country country4 = new Country { Name = "France" };

            //Artist artist1 = new Artist { Name = "Dima", Surname = "Bilan", Country = country1 };
            //Artist artist2 = new Artist { Name = "Michael", Surname = "Jackson", Country = country2 };
            //Artist artist3 = new Artist { Name = "Sviatoslav", Surname = "Vakarchuk", Country = country3 };
            //Artist artist4 = new Artist { Name = "Paul", Surname = "Van Haver", Country = country4 };

            //Genre genre1 = new Genre { Name = "rock" };
            //Genre genre2 = new Genre { Name = "relax" };
            //Genre genre3 = new Genre { Name = "pop" };
            //Genre genre4 = new Genre { Name = "opera" };

            //Album album1 = new Album { Name = "Ne molchi", Year = 2015, Artist = artist1, Genre = genre3 };
            //Album album2 = new Album { Name = "Dotianis", Year = 2013, Artist = artist1, Genre = genre3 };
            //Album album3 = new Album { Name = "Dangerous", Year = 1991, Artist = artist2, Genre = genre2 };
            //Album album4 = new Album { Name = "Invincible", Year = 2001, Artist = artist2, Genre = genre2 };
            //Album album5 = new Album { Name = "Tam de nas nema", Year = 1998, Artist = artist3, Genre = genre1 };
            //Album album6 = new Album { Name = "Gloria", Year = 2005, Artist = artist3, Genre = genre1 };
            //Album album7 = new Album { Name = "Cheese", Year = 2010, Artist = artist4, Genre = genre4 };
            //Album album8 = new Album { Name = "Racine Carree", Year = 2013, Artist = artist4, Genre = genre4 };

            //Track track1 = new Track { Name = "Ne molchi", Duration = 232, Album = album1 };
            //Track track2 = new Track { Name = "Teleport", Duration = 195, Album = album1 };
            //Track track3 = new Track { Name = "Malish", Duration = 212, Album = album1 };
            //Track track4 = new Track { Name = "Dotianis", Duration = 232, Album = album2 };
            //Track track5 = new Track { Name = "Stranica", Duration = 195, Album = album2 };
            //Track track6 = new Track { Name = "Tak ne bivaet", Duration = 212, Album = album2 };
            //Track track7 = new Track { Name = "Dangerous", Duration = 420, Album = album3 };
            //Track track8 = new Track { Name = "Gone Too Soon", Duration = 203, Album = album3 };
            //Track track9 = new Track { Name = "Give In to Me", Duration = 329, Album = album3 };
            //Track track10 = new Track { Name = "Invincible", Duration = 285, Album = album4 };
            //Track track11 = new Track { Name = "Break of Dawn", Duration = 332, Album = album4 };
            //Track track12 = new Track { Name = "You Are My Life", Duration = 273, Album = album4 };
            //Track track13 = new Track { Name = "Noviy den", Duration = 168, Album = album5 };
            //Track track14 = new Track { Name = "Tam de nas nema", Duration = 209, Album = album5 };
            //Track track15 = new Track { Name = "Golos tviy", Duration = 234, Album = album5 };
            //Track track16 = new Track { Name = "Persha pisnia", Duration = 225, Album = album6 };
            //Track track17 = new Track { Name = "Ti i ia", Duration = 209, Album = album6 };
            //Track track18 = new Track { Name = "Vishe neba", Duration = 239, Album = album6 };
            //Track track19 = new Track { Name = "Bienvenue chez moi", Duration = 175, Album = album7 };
            //Track track20 = new Track { Name = "Te quiero", Duration = 203, Album = album7 };
            //Track track21 = new Track { Name = "ail de musique", Duration = 248, Album = album7 };
            //Track track22 = new Track { Name = "Papaoutai", Duration = 232, Album = album8 };
            //Track track23 = new Track { Name = "Formidable", Duration = 213, Album = album8 };
            //Track track24 = new Track { Name = "Carmen", Duration = 189, Album = album8 };

            //context.Countries.AddRange(country1, country2, country3, country4);
            //context.Artists.AddRange(artist1, artist2, artist3, artist4);
            //context.Genres.AddRange(genre1, genre2, genre3, genre4);
            //context.Albums.AddRange(album1, album2, album3, album4, album5, album6, album7, album8);
            //context.Traks.AddRange(track1, track2, track3, track4, track5, track6, track7, track8, track9, track10, track11, track12,
            //    track13, track14, track15, track16, track17, track18, track19, track20, track21, track22, track23, track24);

            //context.SaveChanges();



            //context.PlayLists.Add(new PlayList() { Name = "MyFirstlist", Tracks = new List<Track>() { 1, 2 } });

            
            foreach (Track item in context.Traks.Include(c => c.Album).ToList())
            {
                Console.WriteLine($"Album: {item.Album.Name}, song: {item.Name} ");
            }

            //context.SaveChanges();
        }
    }
}
