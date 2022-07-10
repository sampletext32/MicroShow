using MicroShow.Clients;
using MicroShow.Models;
using Book = MicroShow.Models.Book;
using Author = MicroShow.Models.Author;

namespace MicroShow.Services;

public class BookOperations : IBookOperations
{
    private readonly BookClient _bookClient;

    public BookOperations()
    {
        _bookClient = new BookClient("http://localhost:5180");
    }
    
    public async Task<ICollection<Book>> GetAll()
    {
        Console.WriteLine("Monolith calls GetAll");
        var books = await _bookClient.GetAllAsync();

        // return _mapper.Map<ICollection<Book>>(books);

        var mappedBooks = books.Select(b => new Book()
        {
            Author = new Author()
            {
                FIO = b.Author.Fio
            },
            Title = b.Title
        }).ToList();

        return mappedBooks;
    }
}