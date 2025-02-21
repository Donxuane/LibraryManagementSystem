using MvcApp.Models;

namespace MvcApp.Services;

public class BookServices : IBookServices
{
    private List<Book> books = [
        new Book
        {
            Title ="test", Author = "testAuthor", Description = "testDescription", Genre = "testGenre", ReleaseDate= DateOnly.MaxValue
        },
        new Book
        {
            Title ="test1", Author = "testAuthor1", Description = "testDescription1", Genre = "testGenre1", ReleaseDate= DateOnly.MaxValue
        },
        new Book
        {
            Title ="test2", Author = "testAuthor2", Description = "testDescription2", Genre = "testGenre2", ReleaseDate= DateOnly.MaxValue
        }
        ];

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void DeleteBook(string bookTitle)
    {
        books.RemoveAll(x=>x.Title == bookTitle);
    }

    public List<Book> GetAllBook()
    {
        return books;
    }
}
