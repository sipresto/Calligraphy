using System.Text;
using System.Text.Json;
using Calligraphy.Core;

namespace Calligraphy.Infrastructure;

public class FastApiHandwritingService : IHandwritingService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "http://localhost:8000/analyze";

    public FastApiHandwritingService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> SubmitSessionAsync(HandwritingSession session)
    {
        
        try
        {
            var json = JsonSerializer.Serialize(session);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiUrl, content);

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fout bij verzenden: {ex.Message}");
            return false;
        }
    }
}