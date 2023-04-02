using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublisherDomain;

namespace PublisherData
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cover> Covers { get; set; }
        
        public PubContext(DbContextOptions<PubContext> options)
            : base(options) 
        { 

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //add logging functionality
        //    optionsBuilder.UseSqlServer(
        //        "data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase")
        //        .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information );
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var authors = new Author[]
            {
                new Author { AuthorId = 1, FirstName = "James", LastName = "Bold" },
                new Author { AuthorId = 2, FirstName = "Jack", LastName = "Siv" },
                new Author { AuthorId = 3, FirstName = "Blue", LastName = "Big" }
            };
            modelBuilder.Entity<Author>().HasData(authors);

            var books = new Book[]
            {
                new Book { AuthorId = 1, BookId =1, Title= "TheyBelong", BasePrice = 20},
                new Book { AuthorId = 1, BookId =2, Title= "Taste the Rainbow", BasePrice = 50},
                new Book {  AuthorId = 1, BookId =3, Title= "Just do it", BasePrice = 80}
            };
            modelBuilder.Entity<Book>().HasData(books);

            var artists = new Artist[]
            {
                new Artist { ArtistId = 1, FirstName ="Ludwig", LastName = "Van"},
                new Artist { ArtistId = 2, FirstName ="Petr", LastName = "Cech"},
                new Artist { ArtistId = 3, FirstName ="Romeo", LastName = "Miller"}
            };
            modelBuilder.Entity<Artist>().HasData(artists);

            var covers = new Cover[]
            {
                new Cover { BookId = 3, CoverId = 1, DesignIdeas="Change colour to blue", DigitalOnly = false },
                new Cover { BookId = 2, CoverId = 2, DesignIdeas="Move clock to bottom", DigitalOnly = true },
                new Cover { BookId = 1, CoverId = 3, DesignIdeas="Set face to left", DigitalOnly = false }
            };
            modelBuilder.Entity<Cover>().HasData(covers);

        }
    }
}