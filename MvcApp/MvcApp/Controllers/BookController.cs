using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.Services;
namespace MvcApp.Controllers;

public class BookController : Controller
{
    private IBookServices _bookService { get; set; }
    public BookController(IBookServices bookService) 
    { _bookService = bookService; }
    public IActionResult AddBook()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        if (ModelState.IsValid)
        {
           
            _bookService.AddBook(book);
            return RedirectToAction("LibraryBooks");
        }
        return View();
    }
    [HttpGet]
    public IActionResult LibraryBooks()
    {
        var books = _bookService.GetAllBook();
        return View(books);
    }
    [HttpPost]
    public IActionResult DeleteBook(string title)
    {
        _bookService.DeleteBook(title);
        return RedirectToAction("LibraryBooks");
    }
}
