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
        await SetAuthHeader();
        var response = await _httpClient.PostAsJsonAsync(url, data);
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T?> PutAsync<T>(string url, object data)
    {
        await SetAuthHeader();
        var response = await _httpClient.PutAsJsonAsync(url, data);
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<bool> DeleteAsync(string url)
    {
        await SetAuthHeader();
        var response = await _httpClient.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
} 