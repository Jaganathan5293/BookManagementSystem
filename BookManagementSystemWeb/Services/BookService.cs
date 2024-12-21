using System.Net.Http.Json;
using System.Text.Json;
using BookManagementSystem.Web.Models;

namespace BookManagementSystem.Web.Services;

public class BookService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "api/books";
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        try
        {
            Console.WriteLine($"Making request to: {_httpClient.BaseAddress}{BaseUrl}");
            var response = await _httpClient.GetAsync(BaseUrl);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response status: {response.StatusCode}");
            Console.WriteLine($"Response content: {content}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"API returned {response.StatusCode}: {content}");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("API returned empty content");
                return new List<Book>();
            }

            var books = JsonSerializer.Deserialize<List<Book>>(content, JsonOptions);
            Console.WriteLine($"Deserialized {books?.Count ?? 0} books");
            return books ?? new List<Book>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetAllBooksAsync: {ex.GetType().Name} - {ex.Message}");
            throw;
        }
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            var content = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<Book>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetBookByIdAsync: {ex.Message}");
            throw;
        }
    }

    public async Task<Book?> CreateBookAsync(Book book)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, book);
            var content = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<Book>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in CreateBookAsync: {ex.Message}");
            throw;
        }
    }

    public async Task<Book?> UpdateBookAsync(int id, Book book)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", book);
            var content = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<Book>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in UpdateBookAsync: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteBookAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in DeleteBookAsync: {ex.Message}");
            throw;
        }
    }
}
