using Calligraphy.Domain;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Application;

public class ShapeDrawService
{
    private ShapeDrawSession _session;
    
    public void InitializeSession(Shape shape)
    {
        _session = new ShapeDrawSession(shape);
    }
    
    public void AddStroke(List<StrokePoint> stroke)
    {
        _session.AddStroke(stroke);
    }
    
    public (double score, int stars) CheckShape()
    {
        var score = _session.CalculateScore();
        var stars = _session.CalculateStars(score, new StarThresholds(30, 60, 90));
        return (score, stars);
        
    }

    public Shape GetShape()
    {
        return _session.Shape;
    }
}