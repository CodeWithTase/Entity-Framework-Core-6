// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
//AddAuthors();
//GetAuthors();

AddAuthorWithBook();
GetAuthorWithBook();

void GetAuthorWithBook()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine($"{author.FirstName} {author.LastName}");
        foreach (var book in author.Books)
        {
            Console.WriteLine("*"+book.Title);
        }
    }
}

void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Tase", LastName = "Akpo" };
    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework",
        PublishDate = new DateTime(2009, 1, 1)
    });
    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework 2nd Ed",
        PublishDate = new DateTime(2010, 7, 11)
    });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

//void AddAuthors()
//{
//    var author = new Author { FirstName = "Reuben", LastName = "Akpobome" };
//    using var context = new PubContext();
//    context.Authors.Add(author);
//    context.SaveChanges();
//}

//void GetAuthors()
//{
//    using var context = new PubContext();
//    var authors = context.Authors.ToList();
//    foreach(var author in authors)
//    {
//        Console.WriteLine($"{author.FirstName} {author.LastName}");
//    }
//}