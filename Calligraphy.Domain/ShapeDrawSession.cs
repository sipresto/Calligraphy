namespace Calligraphy.Domain;

public class ShapeDrawSession: ISession
{
    private readonly string _shapeName;

    private readonly List<List<StrokePoint>> _strokes = [];

    public ShapeDrawSession(string shapeName)
    {
        _shapeName = shapeName;
    }
    
    public IReadOnlyList<IReadOnlyList<StrokePoint>> Strokes => _strokes;
    public string ShapeName => _shapeName;
    public void Reset()
    {
        _strokes.Clear();
    }
    
    public void AddStroke(List<StrokePoint> stroke) => _strokes.Add(stroke);

    public int CalculateScore()
    {
        return 1;
    }
}