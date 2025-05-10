using System.Net.Http.Json;
using Houlight.Domain.Entities;
using Houlight.Application.Features.Loads.Queries.GetAllLoads;

namespace Houlight.Web.Services;

public interface ILoadService
{
    Task<List<GetAllLoadsResponse>> GetAllLoadsAsync();
}

public class LoadService : ILoadService
{
    private readonly HttpClient _httpClient;

    public LoadService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GetAllLoadsResponse>> GetAllLoadsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<GetAllLoadsResponse>>("api/Loads") ?? new List<GetAllLoadsResponse>();
    }
} 