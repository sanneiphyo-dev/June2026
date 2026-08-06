using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions
{
    public class BorrowTransactionHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly BorrowTransactionService _directService;

        public BorrowTransactionHttpClientService(string baseUrl = "https://localhost:7123/")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(3)
            };
            _directService = new BorrowTransactionService();
        }

        public async Task<List<BorrowTransactionViewModel>> ReadAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<BorrowTransactionViewModel>>("api/borrowtransactions");
                if (result != null && result.Count > 0) return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            return _directService.Read();
        }

        public async Task<BorrowTransactionViewModel?> GetByIdAsync(string transactionId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<BorrowTransactionViewModel>($"api/borrowtransactions/{transactionId}");
            }
            catch
            {
                return _directService.GetById(transactionId);
            }
        }

        public async Task<bool> CreateAsync(BorrowTransactionViewModel transaction)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/borrowtransactions", transaction);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Create(transaction);
            return true;
        }

        public async Task<bool> UpdateAsync(BorrowTransactionViewModel transaction)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/borrowtransactions/{transaction.TransactionId}", transaction);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Update(transaction);
            return true;
        }

        public async Task<bool> DeleteAsync(string transactionId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/borrowtransactions/{transactionId}");
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Delete(transactionId);
            return true;
        }
    }
}
