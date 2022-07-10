using MicroShow.Models;
using MicroShow.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroShow.Controllers;

[Controller]
[Route("[controller]/[action]")]
public class BookController : Controller
{
    private IBookOperations _bookOperations;

    public BookController(IBookOperations bookOperations)
    {
        _bookOperations = bookOperations;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Book>>> GetAll()
    {
        Console.WriteLine("Monolith handles GetAll");
        return Ok(await _bookOperations.GetAll());
    }
}