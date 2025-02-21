using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models;

public class Book
{
    [Required(ErrorMessage = "Title Is Required!")]
    public string Title { get; set; } = string.Empty;
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? Genre {  get; set; }
    public DateOnly? ReleaseDate { get; set; } = null;
}
