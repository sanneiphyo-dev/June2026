using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BookCopies
{
    public class BookCopyHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly BookCopyService _directService;

        public BookCopyHttpClientService(string baseUrl = "https://localhost:7123/")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(3)
            };
            _directService = new BookCopyService();
        }

        public async Task<List<BookCopyViewModel>> ReadAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<BookCopyViewModel>>("api/bookcopies");
                if (result != null && result.Count > 0) return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            return _directService.Read();
        }

        public async Task<BookCopyViewModel?> GetByIdAsync(string copyId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<BookCopyViewModel>($"api/bookcopies/{copyId}");
            }
            catch
            {
                return _directService.GetById(copyId);
            }
        }

        public async Task<bool> CreateAsync(BookCopyViewModel copy)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/bookcopies", copy);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Create(copy);
            return true;
        }

        public async Task<bool> UpdateAsync(BookCopyViewModel copy)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/bookcopies/{copy.CopyId}", copy);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Update(copy);
            return true;
        }

        public async Task<bool> DeleteAsync(string copyId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/bookcopies/{copyId}");
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Delete(copyId);
            return true;
        }
    }
}
