using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Books
{
    public class BookHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly BookService _directService;

        public BookHttpClientService(string baseUrl = "https://localhost:7123/")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(3)
            };
            _directService = new BookService();
        }

        public async Task<List<BookViewModel>> ReadAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<BookViewModel>>("api/books");
                if (result != null && result.Count > 0) return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            // Fallback to direct DB service so data always appears on screen
            return _directService.Read();
        }

        public async Task<BookViewModel?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<BookViewModel>($"api/books/{id}");
            }
            catch
            {
                return _directService.GetById(id);
            }
        }

        public async Task CreateAsync(BookViewModel book)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/books", book);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Adding New Book via HttpClient Successfully.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Create(book);
        }

        public async Task UpdateAsync(BookViewModel book)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/books/{book.BookId}", book);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Updating Book via HttpClient Successfully.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Update(book);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/books/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Deleting Book via HttpClient Successfully.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Delete(id);
        }
    }
}
