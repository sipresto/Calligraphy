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
        return 3;
    }
}