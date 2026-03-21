using Calligraphy.Domain.Utility;

namespace Calligraphy.Domain.Sessions;

public class InfinityRaceSession : GameSession
{
    private readonly List<RaceCircle> _circles;
    private bool _wrongWay = false;
    private bool _tooManyCirclesHit = false;

    public InfinityRaceSession(IEnumerable<RaceCircle> circles)
    {
        _circles = circles.ToList();
    }

    protected override int CalculateScore()
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
        int circlesHit = 0;
        _wrongWay = false;
        _tooManyCirclesHit = false;

        foreach (var stroke in Strokes)
        {
            int current = 0;

            foreach (var point in stroke)
            {
                if (_circles[0].IsInside(point.X, point.Y) || _circles[1].IsInside(point.X, point.Y))
                {
                    current = 0;
                    circlesHit++;
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
                else if (current == 6 && checks[2](point))
                {
                    current = 6;
                    _wrongWay = true;
                }
                else if (current == 2 && checks[6](point))
                {
                    current = 2;
                    _wrongWay = true;
                }
            }
        }

        if (circlesHit > score)
        {
            _tooManyCirclesHit = true;
        }

        return score;
    }

    public override string GetFeedbackMessage(int stars)
    {
        if (_wrongWay)
            return FeedbackMessageProvider.GetRandomMessage(FeedbackType.InfinityWrongDirection);

        if (_tooManyCirclesHit)
            return FeedbackMessageProvider.GetRandomMessage(FeedbackType.InfinityCirclesHit);
        
        return FeedbackMessageProvider.GetStarsMessage(stars);
    }
}