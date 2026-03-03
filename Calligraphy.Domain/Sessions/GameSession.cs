namespace Calligraphy.Domain.Sessions;

public abstract class GameSession
{
    protected readonly List<List<StrokePoint>> _strokes = [];

    public IReadOnlyList<IReadOnlyList<StrokePoint>> Strokes => _strokes;
    
    public void AddStroke(List<StrokePoint> stroke)
    {
        if (stroke is { Count: > 0 })
            _strokes.Add(stroke);
    }

    public List<StrokePoint> TotalStroke()
    {
        return _strokes
            .SelectMany(s => s)
            .ToList();
    }

    public int CalculateStars(int score, StarThresholds thresholds)
    {
        if (score < thresholds.OneStar) return 0;
        if (score < thresholds.TwoStars) return 1;
        if (score < thresholds.ThreeStars) return 2;
        return 3;
    }

    public abstract int CalculateScore();
}