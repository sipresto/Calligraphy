namespace Calligraphy.Domain;

public class ShapeDrawSession: ISession
{
    private readonly string _shapeName;

    private List<List<StrokePoint>> _strokes = [];

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
    
    public void AddStrokes(List<List<StrokePoint>> strokes) => _strokes = strokes;

    public int CalculateScore()
    {
        return 1;
    }
}