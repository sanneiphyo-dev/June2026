using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Reservations
{
    public class ReservationHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ReservationService _directService;

        public ReservationHttpClientService(string baseUrl = "https://localhost:7123/")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(3)
            };
            _directService = new ReservationService();
        }

        public async Task<List<ReservationViewModel>> ReadAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<ReservationViewModel>>("api/reservations");
                if (result != null && result.Count > 0) return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            return _directService.Read();
        }

        public async Task<ReservationViewModel?> GetByIdAsync(int reservationId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ReservationViewModel>($"api/reservations/{reservationId}");
            }
            catch
            {
                return _directService.GetById(reservationId);
            }
        }

        public async Task<bool> CreateAsync(ReservationViewModel reservation)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/reservations", reservation);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Create(reservation);
            return true;
        }

        public async Task<bool> UpdateAsync(ReservationViewModel reservation)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/reservations/{reservation.ReservationId}", reservation);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Update(reservation);
            return true;
        }

        public async Task<bool> DeleteAsync(int reservationId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/reservations/{reservationId}");
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Delete(reservationId);
            return true;
        }
    }
}
