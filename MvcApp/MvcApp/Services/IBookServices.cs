using MvcApp.Models;
namespace MvcApp.Services
{
    public interface IBookServices
    {
        public void AddBook(Book book);
        public void DeleteBook(string bookTitle);
        public List<Book> GetAllBook();
    }
}
