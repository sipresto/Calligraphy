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
    
    public void InitializeSession(string shapeName)
    {
        _session = new ShapeDrawSession(shapeName);
    }

    public void Reset()
    {
        _session.Reset();
    }

    public void AddStrokes(List<List<StrokePoint>> points)
    {
        _session.AddStrokes(points);
    }
    
    public (bool success, double score) CheckShape(string shapeName)
    {
        return _recognizer.CheckShape(_session.Strokes, shapeName);
    }
}