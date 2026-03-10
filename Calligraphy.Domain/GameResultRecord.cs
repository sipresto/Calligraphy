namespace Calligraphy.Domain;

public record GameResultRecord(
    string GameId,
    int Score,
    int Stars,
    DateTime AchievedAt
);