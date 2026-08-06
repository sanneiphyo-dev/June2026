using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Members
{
    public class MemberHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly MemberService _directService;

        public MemberHttpClientService(string baseUrl = "https://localhost:7123/")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(3)
            };
            _directService = new MemberService();
        }

        public async Task<List<MemberViewModel>> ReadAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<MemberViewModel>>("api/members");
                if (result != null && result.Count > 0) return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            return _directService.Read();
        }

        public async Task<MemberViewModel?> GetByIdAsync(string memberId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MemberViewModel>($"api/members/{memberId}");
            }
            catch
            {
                return _directService.GetById(memberId);
            }
        }

        public async Task<bool> CreateAsync(MemberViewModel member)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/members", member);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Create(member);
            return true;
        }

        public async Task<bool> UpdateAsync(MemberViewModel member)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/members/{member.MemberId}", member);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Update(member);
            return true;
        }

        public async Task<bool> DeleteAsync(string memberId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/members/{memberId}");
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HttpClient Fallback to Direct DB]: {ex.Message}");
            }

            _directService.Delete(memberId);
            return true;
        }
    }
}
