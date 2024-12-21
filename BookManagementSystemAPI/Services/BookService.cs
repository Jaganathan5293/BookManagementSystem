using BookManagementSystem.API.Models;
using BookManagementSystem.API.Repositories;

namespace BookManagementSystem.API.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _repository.GetAllBooksAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _repository.GetBookByIdAsync(id);
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        return await _repository.AddBookAsync(book);
    }

    public async Task<Book?> UpdateBookAsync(Book book)
    {
        return await _repository.UpdateBookAsync(book);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        return await _repository.DeleteBookAsync(id);
    }
}
