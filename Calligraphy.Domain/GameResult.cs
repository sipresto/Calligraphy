namespace Calligraphy.Domain;

public record GameResult
{
    public int? Score { get; init; }
    public int? Time { get; init; }
    public int StarCount { get; init; }
    public string FeedbackMessage { get; init; }
}