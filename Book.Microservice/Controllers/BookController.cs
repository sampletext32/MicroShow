using Book.Microservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Microservice.Controllers;

[Controller]
[Route("[controller]/[action]")]
public class BookController : Controller
{
    private ICollection<Models.Book> _books = new List<Models.Book>()
    {
        new Models.Book()
        {
            Title = "Harry Potter",
            Author = new Author()
            {
                FIO = "Joan Rowling"
            }
        }
    };

    [HttpGet]
    public async Task<ActionResult<ICollection<Models.Book>>> GetAll()
    {
        Console.WriteLine("Microservice handles GetAll");
        return Ok(_books);
    }

    [HttpGet]
    public async Task<ActionResult<int>> GetRandom(int seed)
    {
        Console.WriteLine("Microservice handles GetRandom");
        return Ok(new Random(seed).Next(1000));
    }
}