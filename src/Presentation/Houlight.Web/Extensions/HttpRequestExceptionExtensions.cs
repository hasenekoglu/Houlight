using System.Net.Http;

namespace Houlight.Web.Extensions;

public static class HttpRequestExceptionExtensions
{
    public static async Task<string> GetResponseContentAsync(this HttpRequestException ex)
    {
        if (ex.Data.Contains("ResponseContent"))
        {
            return ex.Data["ResponseContent"]?.ToString() ?? string.Empty;
        }
        return string.Empty;
    }
} 