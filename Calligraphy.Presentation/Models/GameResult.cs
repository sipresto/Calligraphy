namespace Calligraphy.Presentation.Models;

public record GameResult
{
    public int? Score { get; init; }
    public int? Time { get; init; }
}