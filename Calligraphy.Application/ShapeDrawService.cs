using Calligraphy.Domain;

namespace Calligraphy.Application;

public class ShapeDrawService
{
    private ShapeDrawSession _session;
    private readonly Recognizer _recognizer;
    
    public ShapeDrawService()
    {
        _recognizer = new Recognizer();
    }
    
    public void InitializeSession(Shape shape)
    {
        _session = new ShapeDrawSession(shape);
    }
    
    public void AddStrokes(List<List<StrokePoint>> points)
    {
        _session.AddStrokes(points);
    }
    
    public (bool success, double score, int stars) CheckShape()
    {
        (bool success, double score) = _recognizer.CheckShape(_session.Strokes, _session.Shape.Name);
        var stars = _session.CalculateStars((int)score);
        return (success, score, stars);
        
    }

    public Shape GetShape()
    {
        return _session.Shape;
    }
}