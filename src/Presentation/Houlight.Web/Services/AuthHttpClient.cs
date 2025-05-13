using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;


namespace Houlight.Web.Services;

public class AuthHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILocalStorageService _localStorage;

    public AuthHttpClient(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _localStorage = localStorage;
    }

    public async Task SetAuthHeader()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<T?> GetAsync<T>(string url)
    {
        await SetAuthHeader();
        return await _httpClient.GetFromJsonAsync<T>(url);
    }

    public async Task<T?> PostAsync<T>(string url, object data)
    {
        try
        {
            await SetAuthHeader();
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var userId = await _localStorage.GetItemAsync<string>("userId");
            
            Console.WriteLine($"AuthHttpClient.PostAsync: Token durumu: {(string.IsNullOrEmpty(token) ? "Boş" : "Var")}");
            Console.WriteLine($"AuthHttpClient.PostAsync: UserId durumu: {(string.IsNullOrEmpty(userId) ? "Boş" : userId)}");
            Console.WriteLine($"AuthHttpClient.PostAsync: İstek gönderiliyor - URL: {url}");
            Console.WriteLine($"AuthHttpClient.PostAsync: Gönderilen veri: {System.Text.Json.JsonSerializer.Serialize(data)}");
            Console.WriteLine($"AuthHttpClient.PostAsync: Authorization Header: {_httpClient.DefaultRequestHeaders.Authorization}");

            var response = await _httpClient.PostAsJsonAsync(url, data);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"AuthHttpClient.PostAsync: Yanıt durumu: {response.StatusCode}");
            Console.WriteLine($"AuthHttpClient.PostAsync: Yanıt içeriği: {responseContent}");

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    // Önce hata yanıtını parse etmeyi deneyelim
                    var errorResponse = System.Text.Json.JsonSerializer.Deserialize<ErrorResponse>(responseContent);
                    if (errorResponse?.errors != null)
                    {
                        var errorMessages = errorResponse.errors.SelectMany(e => e.Value.Select(m => $"{e.Key}: {m}"));
                        var detailedError = string.Join(", ", errorMessages);
                        Console.WriteLine($"AuthHttpClient.PostAsync: Backend'den gelen detaylı hata: {detailedError}");
                        
                        var error = new HttpRequestException(detailedError, null, response.StatusCode);
                        error.Data["ResponseContent"] = responseContent;
                        error.Data["DetailedError"] = detailedError;
                        throw error;
                    }
                }
                catch (Exception parseEx)
                {
                    Console.WriteLine($"AuthHttpClient.PostAsync: Hata yanıtı parse edilemedi: {parseEx.Message}");
                }

                var error2 = new HttpRequestException(responseContent, null, response.StatusCode);
                error2.Data["ResponseContent"] = responseContent;
                throw error2;
            }

            return System.Text.Json.JsonSerializer.Deserialize<T>(responseContent, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"AuthHttpClient.PostAsync: HTTP isteği hatası - {ex.Message}");
            if (ex.Data.Contains("ResponseContent"))
            {
                Console.WriteLine($"AuthHttpClient.PostAsync: Backend'den gelen ham hata içeriği - {ex.Data["ResponseContent"]}");
            }
            if (ex.Data.Contains("DetailedError"))
            {
                Console.WriteLine($"AuthHttpClient.PostAsync: Backend'den gelen detaylı hata - {ex.Data["DetailedError"]}");
            }
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AuthHttpClient.PostAsync: Beklenmeyen hata - {ex}");
            throw new HttpRequestException("İstek işlenirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.", ex);
        }
    }

    public async Task<T?> PutAsync<T>(string url, object data)
    {
        try
        {
        await SetAuthHeader();
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var userId = await _localStorage.GetItemAsync<string>("userId");
            
            Console.WriteLine($"AuthHttpClient.PutAsync: Token durumu: {(string.IsNullOrEmpty(token) ? "Boş" : "Var")}");
            Console.WriteLine($"AuthHttpClient.PutAsync: UserId durumu: {(string.IsNullOrEmpty(userId) ? "Boş" : userId)}");
            Console.WriteLine($"AuthHttpClient.PutAsync: İstek gönderiliyor - URL: {url}");
            Console.WriteLine($"AuthHttpClient.PutAsync: Gönderilen veri: {System.Text.Json.JsonSerializer.Serialize(data)}");
            Console.WriteLine($"AuthHttpClient.PutAsync: Authorization Header: {_httpClient.DefaultRequestHeaders.Authorization}");

        var response = await _httpClient.PutAsJsonAsync(url, data);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"AuthHttpClient.PutAsync: Yanıt durumu: {response.StatusCode}");
            Console.WriteLine($"AuthHttpClient.PutAsync: Yanıt içeriği: {responseContent}");

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    // Önce hata yanıtını parse etmeyi deneyelim
                    var errorResponse = System.Text.Json.JsonSerializer.Deserialize<ErrorResponse>(responseContent);
                    if (errorResponse?.errors != null)
                    {
                        var errorMessages = errorResponse.errors.SelectMany(e => e.Value.Select(m => $"{e.Key}: {m}"));
                        var detailedError = string.Join(", ", errorMessages);
                        Console.WriteLine($"AuthHttpClient.PutAsync: Backend'den gelen detaylı hata: {detailedError}");
                        
                        var error = new HttpRequestException(detailedError, null, response.StatusCode);
                        error.Data["ResponseContent"] = responseContent;
                        error.Data["DetailedError"] = detailedError;
                        throw error;
                    }
                }
                catch (Exception parseEx)
                {
                    Console.WriteLine($"AuthHttpClient.PutAsync: Hata yanıtı parse edilemedi: {parseEx.Message}");
                }

                var error2 = new HttpRequestException(responseContent, null, response.StatusCode);
                error2.Data["ResponseContent"] = responseContent;
                throw error2;
            }

            return System.Text.Json.JsonSerializer.Deserialize<T>(responseContent, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"AuthHttpClient.PutAsync: HTTP isteği hatası - {ex.Message}");
            if (ex.Data.Contains("ResponseContent"))
            {
                Console.WriteLine($"AuthHttpClient.PutAsync: Backend'den gelen ham hata içeriği - {ex.Data["ResponseContent"]}");
            }
            if (ex.Data.Contains("DetailedError"))
            {
                Console.WriteLine($"AuthHttpClient.PutAsync: Backend'den gelen detaylı hata - {ex.Data["DetailedError"]}");
            }
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AuthHttpClient.PutAsync: Beklenmeyen hata - {ex}");
            throw new HttpRequestException("İstek işlenirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.", ex);
        }
    }

    public async Task<bool> DeleteAsync(string url)
    {
        await SetAuthHeader();
        var response = await _httpClient.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }

    private class ErrorResponse
    {
        public string message { get; set; }
        public Dictionary<string, string[]> errors { get; set; }
    }
} 