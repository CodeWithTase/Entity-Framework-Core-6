﻿// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

PubContext _context = new PubContext(); //existing database

CancleBookWithCutsomTransaction(1);

void CancleBookWithCutsomTransaction(int bookId)
{
    using var transaction = _context.Database.BeginTransaction();
    try
    {
        var artists = _context.Artists.Where(cover => cover.Covers.Any(c => c.CoverId == bookId)).ToList();
        foreach (var artist in artists)
        {
            artist.LastName = "RemovedCover";
        }
        _context.Database.ExecuteSqlInterpolated($"DELETE FROM books WHERE bookId={bookId}");
        _context.SaveChanges();
        transaction.Commit();
    }
    catch (Exception)
    {

        //TODO: Handle Failure
    }
}


//InterpolatedSqlStoredProc();

//void InterpolatedSqlStoredProc()
//{
//    int minPrice = 10;
//    int maxPrice = 50;

//    var authors = _context.Authors.FromSqlInterpolated($"AuthorsBookspriceRange {minPrice}, {maxPrice}")
//        .ToList();
//}

//StringFromInteroplate_SafeFromInjection();

//void StringFromInteroplate_SafeFromInjection()
//{
//    var lastNameStartsWith = "B";
//    var authors = _context.Authors.FromSqlInterpolated($"SELECT * FROM authors WHERE lastname LIKE '{lastNameStartsWith}%' ")
//        .OrderBy(a => a.LastName).TagWith("Interpolated_Safe").ToList();
//}

//SimpleRawSQL();

//void SimpleRawSQL()
//{
//    var authors = _context.Authors.FromSqlRaw("select * from authors").ToList();
//}



//ConnectExistingArtistAndCoverObject();

//void ConnectExistingArtistAndCoverObject()
//{
//    using var context =new PubContext();
//    var artistA = context.Artists.Find(1);
//    var artistB = context.Artists.Find(2);
//    var coverA = context.Covers.Find(1);
//    coverA.Artists = new List<Artist>();
//    coverA.Artists.Add(artistA);
//    coverA.Artists.Add(artistB);
//    context.SaveChanges();

//}


//Projections();

//void Projections()
//{
//    using var context = new PubContext();
//    var unknownType = context.Authors.Select(a => new
//    {
//        AuthorId = a.AuthorId,
//        Name = $"{a.FirstName} {a.LastName}",
//        Books = a.Books.Count
//    }).ToList();
//}

//EagerLoadingBooksWithAuthor();

//void EagerLoadingBooksWithAuthor()
//{
//    using var context = new PubContext();
//    var authors = context.Authors.Include(a => a.Books).ToList();
//    authors.ForEach(author =>
//    {
//        Console.WriteLine($"{author.FirstName} ({author.Books.Count})");
//        author.Books.ForEach(book => Console.WriteLine("  "+ book.Title));
//    });

//}


//AddNewBookToExistingAuthorInMemory();

//void AddNewBookToExistingAuthorInMemory()
//{
//    using var context = new PubContext();
//    var author = context.Authors.FirstOrDefault(a => a.LastName == "Bold");
//    if (author != null)
//    {
//        author.Books.Add(new Book { Title = "The Darmordy Tales", PublishDate = new DateTime(2013, 1, 3) });
//    }
//    context.SaveChanges();
//}

//InsertNewAuthorWithNewBook();

//void InsertNewAuthorWithNewBook()
//{
//    using var context = new PubContext();

//    var author = new Author { FirstName = "Koogan", LastName = "Kassius" };
//    author.Books.Add(new Book { Title = "The Art Of Boxing", PublishDate = new DateTime(2021, 2, 1) });

//    context.Authors.Add(author);
//    context.SaveChanges();
//}

//GetAuthors();

//void GetAuthors()
//{
//    using var context = new PubContext();
//    var authors = context.Authors.ToList();
//}



//InsertMultipleAuthors();

//void InsertMultipleAuthors()
//{
//    using var context = new PubContext();

//    var authours = new Author[] {new Author { FirstName = "Roe", LastName = "Bishop" },
//        new Author { FirstName = "Don", LastName = "Jones" },
//        new Author { FirstName = "Jim", LastName = "Lane" },
//        new Author { FirstName = "Pee", LastName = "Herman" }};


//    context.Authors.AddRange(authours);

//    context.SaveChanges();
//}

//DeleteAuthor();

//void DeleteAuthor()
//{
//    var context = new PubContext();
//    var extraEntryOfMe = context.Authors.Find(1);
//    if (extraEntryOfMe != null)
//    {
//        context.Authors.Remove(extraEntryOfMe);
//        context.SaveChanges();
//    }
//}


//CoordinateretrieveAndUpdateAuthor();

//void CoordinateretrieveAndUpdateAuthor()
//{
//    var author = FindThatAuthor(3);
//    if (author?.FirstName == "Tase")
//    {
//        author.FirstName = "Erutase";
//        SaveThatAuthor(author);
//    }
//}


//Author FindThatAuthor(int authorId)
//{
//    using var shortLivedContext = new PubContext();
//    return shortLivedContext.Authors.Find(authorId);
//}


//void SaveThatAuthor(Author author)
//{
//    using var anotherShortLivedContext = new PubContext();
//    anotherShortLivedContext.Authors.Update(author);
//    anotherShortLivedContext.SaveChanges();
//}


//RetrieveAndAupdateAuthor();

//void RetrieveAndAupdateAuthor()
//{
//    using var context = new PubContext();
//    var author = context.Authors.FirstOrDefault(a => a.FirstName == "Tase" && a.LastName == "Akpo");

//    if (author != null)
//    {
//        author.FirstName = "Erutase";
//        context.SaveChanges();
//    }
//}



//QueryFiltersFirstOrDefault();

//void QueryFiltersFirstOrDefault()
//{
//    //where
//    using var context = new PubContext();
//    //var authors = context.Authors.Where(x => x.FirstName == "Tase").ToList();

//    //like
//    var filter = "A%";
//    var author = context.Authors.FirstOrDefault(a => EF.Functions.Like(a.LastName, filter));
//}



//SortingAuthors();
//SortingAuthorsDescending();


//void SortingAuthors()
//{
//    using var context = new PubContext();
//    var authorsByLastName = context.Authors.OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToList();
//    authorsByLastName.ForEach(a => Console.WriteLine($"{a.LastName} {a.FirstName}"));
//}


//void SortingAuthorsDescending()
//{
//    using var context = new PubContext();
//    var authorsByLastName = context.Authors.OrderByDescending(a => a.LastName).ThenByDescending(a => a.FirstName).ToList();
//    Console.WriteLine("**Order by descending**");
//    authorsByLastName.ForEach(a => Console.WriteLine($"{a.LastName} {a.FirstName}"));
//}

//AddSomeMoreAuthors();
//SkipAndTakeAuthors();

//void AddSomeMoreAuthors()
//{
//    using var context = new PubContext();
//    context.Authors.Add(new Author { FirstName = "Roe", LastName = "Bishop" });
//    context.Authors.Add(new Author { FirstName = "Don", LastName = "Jones" });
//    context.Authors.Add(new Author { FirstName = "Jim", LastName = "Lane" });
//    context.Authors.Add(new Author { FirstName = "Pee", LastName = "Herman" });
//    context.SaveChanges();
//}

//void SkipAndTakeAuthors()
//{
//    using var context = new PubContext();
//    var groupSize = 2;
//    for (int i = 0; i < 5; i++)
//    {
//        var authors = context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
//        Console.WriteLine($"Group {i}:");

//        foreach (var author in authors)
//        {
//            Console.WriteLine($"{author.FirstName} {author.LastName}");
//        }
//    }
//}

//QueryFilters();

//void QueryFilters()
//{
//    //where
//    using var context = new PubContext();
//    //var authors = context.Authors.Where(x => x.FirstName == "Tase").ToList();

//    //like
//    var filter = "A%";
//    var authors = context.Authors.Where(a => EF.Functions.Like(a.LastName, filter)).ToList();
//}

//GetAuthors();
//AddAuthors();
//GetAuthors();

//AddAuthorWithBook();
//GetAuthorWithBook();

//void GetAuthorWithBook()
//{
//    using var context = new PubContext();
//    var authors = context.Authors.Include(a => a.Books).ToList();

//    foreach (var author in authors)
//    {
//        Console.WriteLine($"{author.FirstName} {author.LastName}");
//        foreach (var book in author.Books)
//        {
//            Console.WriteLine("*"+book.Title);
//        }
//    }
//}

//void AddAuthorWithBook()
//{
//    var author = new Author { FirstName = "Tase", LastName = "Akpo" };
//    author.Books.Add(new Book
//    {
//        Title = "Programming Entity Framework",
//        PublishDate = new DateTime(2009, 1, 1)
//    });
//    author.Books.Add(new Book
//    {
//        Title = "Programming Entity Framework 2nd Ed",
//        PublishDate = new DateTime(2010, 7, 11)
//    });
//    using var context = new PubContext();
//    context.Authors.Add(author);
//    context.SaveChanges();
//}

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
//    foreach (var author in authors)
//    {
//        Console.WriteLine($"{author.FirstName} {author.LastName}");
//    }
//}