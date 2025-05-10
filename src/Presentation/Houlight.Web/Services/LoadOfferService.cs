using System.Net.Http.Json;
using Houlight.Domain.Entities;

namespace Houlight.Web.Services;

public interface ILoadOfferService
{
    Task<List<LoadOfferEntity>> GetAllOffersAsync();
}

public class LoadOfferService : ILoadOfferService
{
    private readonly HttpClient _httpClient;

    public LoadOfferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<LoadOfferEntity>> GetAllOffersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<LoadOfferEntity>>("api/LoadOffers") ?? new List<LoadOfferEntity>();
    }
} 