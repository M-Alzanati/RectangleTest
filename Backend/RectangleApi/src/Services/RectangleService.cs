using System.Text.Json;
using RectangleApi.Models;

namespace RectangleApi.Services;

public class RectangleService
{
    private const string JsonFilePath = "rectangle.json";

    public async Task<Dimensions?> GetDimensions(CancellationToken cancellationToken)
    {
        var json = await File.ReadAllTextAsync(JsonFilePath, cancellationToken);
        return JsonSerializer.Deserialize<Dimensions>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task UpdateDimensions(Dimensions dimensions, CancellationToken cancellationToken)
    {
        var json = JsonSerializer.Serialize(dimensions, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(JsonFilePath, json, cancellationToken);
    }
}