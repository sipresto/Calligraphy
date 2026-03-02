namespace Calligraphy.Domain;

public class InfinityRaceSession
{
    private readonly List<Circle> _circles;
    private readonly List<List<StrokePoint>> _strokes = [];

    public InfinityRaceSession(IEnumerable<Circle> circles)
    {
        _circles = circles.ToList();
    }

    public IReadOnlyList<IReadOnlyList<StrokePoint>> Strokes => _strokes;

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
                if (_circles[0].IsInside(point.X, point.Y) || _circles[1].IsInside(point.X, point.Y))
                {
                    current = 0;
                    continue;
                }

                if (checks[current](point))
                {
                    current++;

                    if (current >= checks.Count)
                    {
                        score++;
                        current = 0;
                    }
                }
                else if (current == 6 && checks[2](point)) current = 6;
                else if (current == 2 && checks[6](point)) current = 2;
            }
        }
        
        return score;
    }
}