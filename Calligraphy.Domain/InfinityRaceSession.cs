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
    
    public IReadOnlyList<StrokePoint> GetTotalStroke()
    {
        return _strokes
            .SelectMany(stroke => stroke)
            .ToList();
    }

    public void AddStroke(List<StrokePoint> stroke) => _strokes.Add(stroke);

    public int CalculateScore()
    {
        var checks = new List<Func<StrokePoint, bool>>
        {
            p => _circles[1].IsLeftOf(p.X) && _circles[0].IsRightOf(p.X),
            p => _circles[1].IsAbove(p.Y),
            p => _circles[1].IsRightOf(p.X),
            p => _circles[1].IsBelow(p.Y),
            p => _circles[1].IsLeftOf(p.X) && _circles[0].IsRightOf(p.X),
            p => _circles[0].IsAbove(p.Y),
            p => _circles[0].IsLeftOf(p.X),
            p => _circles[0].IsBelow(p.Y),
            p => _circles[1].IsLeftOf(p.X) && _circles[0].IsRightOf(p.X)
        };
        
        int score = 0;
        
        foreach (var stroke in _strokes)
        {
            int current = 0;
            
            foreach (var point in stroke)
            {
                if (current >= checks.Count)
                {
                    score++;
                    current = 0;
                }

                if (_circles[0].IsInside(point.X, point.Y) || _circles[1].IsInside(point.X, point.Y))
                {
                    current = 0;
                    continue;
                }

                if (checks[current](point)) current++;
            }
        }
        
        return score;
    }
}