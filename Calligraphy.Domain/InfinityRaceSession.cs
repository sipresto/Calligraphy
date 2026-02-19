namespace Calligraphy.Domain;

public class InfinityRaceSession
{
    private readonly List<Circle> _circles;
    private readonly double _middle;
    private readonly List<List<StrokePoint>> _strokes = [];

    public InfinityRaceSession(IEnumerable<Circle> circles, double middle)
    {
        _circles = circles.ToList();
        _middle = middle;
    }

    public IReadOnlyList<IReadOnlyList<StrokePoint>> Strokes => _strokes;

    public void AddStroke(List<StrokePoint> stroke) => _strokes.Add(stroke);
}