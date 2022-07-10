using MicroShow.Models;

namespace MicroShow.Services;

public interface IBookOperations
{
    Task<ICollection<Book>> GetAll();
}