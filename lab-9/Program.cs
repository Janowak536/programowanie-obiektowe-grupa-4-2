using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            context.Database.EnsureCreated();
            Console.WriteLine(context.Books.Find(1));
            IQueryable<Book> books =
            from book in context.Books
            where book.EditionYear > 2019
            select book;
            Console.WriteLine(String.Join("\n", books));

            var list =
                from book in context.Books
                join author in context.Authors
                on book.AuthorId equals author.Id
                where book.EditionYear > 2019
                select new { BookAuthor = author.Name, Title = book.Title };//obiekt klasy anonimowej
            Console.WriteLine(String.Join("\n", list));
            foreach (var item in list)
            {
                Console.WriteLine(item.BookAuthor);
            }
            Console.WriteLine();
            list = context.Authors.Join(
               context.Books.Where(b => b.EditionYear > 2019),
               a => a.Id,
               b => b.AuthorId,
               (a, b) => new { BookAuthor = a.Name, Title = b.Title }
               );//ten join robi dokładnie to samo co ten wyżej
            foreach (var item in list)
            {
                Console.WriteLine(item.BookAuthor);
            }

            var list2 =
                from bookCopy in context.BookCopies
                join author in context.Authors
                on bookCopy.Id equals author.Id
                select new { Books = bookCopy.UniqueNumber, author.Name };
            foreach (var item in list2)
            {
                Console.WriteLine(item.Books);
            }

            string xml =
                "<books>" +
                    "<book>" +
                        "<id>1</id>" +
                        "<title>C#</title>" +
                    "</book>" +
                    "<book>" +
                        "<id>2</id>" +
                        "<title>Asp.Net</title>" +
                    "</book>" +
                "</books>";
            XDocument doc = XDocument.Parse(xml);
            
            var booksId=
                doc
                .Elements("books")
                .Elements("book")
                .Select(e => new { Id = e.Elements("id").First().Value, Title = e.Elements("title").First().Value});
            foreach (var e in booksId)
            {
                Console.WriteLine(e);
            }
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/xml");

            xml = client.DownloadString("http://api.nbp.pl/api/exchangerates/tables/C");

            var rates = XDocument.Parse(xml)
                .Elements("ArrayOfExchangeRatesTable")
                .Elements("ExchangeRatesTable")
                .Elements("Rates")
                .Elements("Rate")
                .Select(r => new { 
                    Currency = r.Element("Currency").Value,
                    Code = r.Element("Code").Value,
                    Bid = r.Element("Bid").Value,
                    Ask = r.Element("Ask").Value});
            foreach (var e in rates)
            {
                Console.WriteLine(e);
            }
        }
    }
    public record Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EditionYear { get; set; }
        public int AuthorId { get; set; }
    }
    public record BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UniqueNumber { get; set; }
    }
    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATASOURCE=C:\\Users\\ASUS\\Desktop\\programowanie\\programowanie-obiektowe-grupa-4-2\\database\\base.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("books")
                .HasData(
                new Book() { Id = 1, AuthorId = 1, EditionYear = 2020, Title = "C#" },
                new Book() { Id = 2, AuthorId = 1, EditionYear = 2021, Title = "Asp.Net" },
                new Book() { Id = 3, AuthorId = 2, EditionYear = 2019, Title = "Data structures" },
                new Book() { Id = 4, AuthorId = 2, EditionYear = 2018, Title = "Web application" }
                );
            modelBuilder.Entity<Author>().ToTable("authors").HasData(
                new Author() { Id = 1, Name = "Freeman" },
                new Author() { Id = 2, Name = "Bloch" }
                );
            modelBuilder.Entity<BookCopy>().ToTable("bookcopies").HasData(
                new BookCopy() { Id = 1, BookId = 1, UniqueNumber = "123" },
                new BookCopy() { Id = 2, BookId = 1, UniqueNumber = "124" }
                );
        }
    }
}
