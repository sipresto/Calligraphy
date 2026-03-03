namespace Calligraphy.Domain;

public class ShapeDrawSession: ISession
{
    public Shape Shape { get; }
    private List<List<StrokePoint>> _strokes = [];

    public ShapeDrawSession(Shape shape)
    {
        Shape = shape;
    }
    
    public IReadOnlyList<IReadOnlyList<StrokePoint>> Strokes => _strokes;
    
    public void AddStrokes(List<List<StrokePoint>> strokes) => _strokes = strokes;

    public int CalculateStars(int score)
    {
        if (score > 90) return 3;
        if (score > 60) return 2;
        if (score > 30)  return 1;
        return 0;
    }
}