using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFeLinq
{

    class BookLibrary
    {
        private BookDb context;
        public BookLibrary()
        {
            context = new BookDb();
        }
        public IEnumerable<Book> GetBooksWichPagesMore(int number) => context.Books.Where(p => p.Pages > number).ToList();
        public IEnumerable<Book> GetBooksWithStartSomeLetter(char letter) => context.Books.Where(n => n.Name.ToUpper().StartsWith(letter)).ToList();
        public IEnumerable<Book> GetAllBooksBySomeAuthor(string author) => context.Books.Include(a => a.Author).Where(a => a.Author.Surname == author).ToList();
        public IEnumerable<Book> GetBooksWithNameOfLessThanSomeSymbolCount(int count, int take) => context.Books.Where(n => n.Name.Length <= count).Take(take).ToList();
        public void GetTheAuthorWhoHasTheLeastBooks()
        {
            var dictionary = context.Books.ToList().GroupBy(i => i.AuthorId).OrderBy(c=> c.Count()).Select(g => new { AuthorId = g.Key, Count = g.Count()}); 
           
            foreach (var item in dictionary)
                Console.WriteLine($"{item.AuthorId} - {item.Count} book(s)");
        }
        public void GetTheCountryThatHasTheMostAuthors()
        {
            var dictionary = context.Authors.ToList().GroupBy(i => i.CountryId).OrderByDescending(c => c.Count()).Select(g => new { CountryId = g.Key, Count = g.Count()});

            foreach (var item in dictionary)
                Console.WriteLine($"{item.CountryId} - {item.Count} author(s)");
        }
        
        public void GetAllBooksByAuthorsFromSomeCountry(string country)
        {
            var dictionary = context.Books.Include(a => a.Author).ThenInclude(c => c.Country).Where(t => t.Author.Country.Name == country);

            foreach (var item in dictionary)
                Console.WriteLine($"Author: {item.Author.FullName} - book: {item.Name} - country: {item.Author.Country.Name} - {item.Pages} pages");

        }

        public void GetBookWithTheMinPageCountOfSomeCountry(string country) 
        {
            var dictionary = context.Books.Include(a => a.Author).ThenInclude(c => c.Country).Where(t => t.Author.Country.Name == country).OrderBy(p => p.Pages).Take(1);
            
            foreach (var item in dictionary)
                Console.WriteLine($"Author: {item.Author.FullName} - book: {item.Name} - country: {item.Author.Country.Name} - {item.Pages} pages");
        }


        public void PrintBooks(IEnumerable<Book> books)
        {
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Name} - {item.Pages}");
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            BookLibrary bookDb = new BookLibrary();

            //Get all books which have pages more that some number.
            //var res = bookDb.GetBooksWichPagesMore(400);
            //bookDb.PrintBooks(res);


            //Get Books with name starting of some letter (ignore case)
            //var res = bookDb.GetBooksWithStartSomeLetter('A');
            //bookDb.PrintBooks(res);


            //Get all books by some author
            //var res = bookDb.GetAllBooksBySomeAuthor("Seaward");
            //bookDb.PrintBooks(res);


            //Get books with name of less than some symbol count
            //var res = bookDb.GetBooksWithNameOfLessThanSomeSymbolCount(9, 2);
            //bookDb.PrintBooks(res);


            //Get the author who has the least books        
            //bookDb.GetTheAuthorWhoHasTheLeastBooks();

            ////Get the country that has the most authors
            //bookDb.GetTheCountryThatHasTheMostAuthors();


            //Get all books by authors from some country
            bookDb.GetAllBooksByAuthorsFromSomeCountry("Indonesia");

            //Get book with the min page count of some country
            Console.WriteLine("--------------------------------------");
            bookDb.GetBookWithTheMinPageCountOfSomeCountry("Indonesia");

        }





    }
}
