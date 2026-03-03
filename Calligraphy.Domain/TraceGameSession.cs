namespace Calligraphy.Domain;

public class TraceGameSession : IGameSession
{
    private readonly List<List<StrokePoint>> _strokes = [];

    public void AddStroke(List<StrokePoint> stroke)
    {
        if (stroke is { Count: > 0 })
            _strokes.Add(stroke);
    }

    public List<StrokePoint> GetTotalStroke()
    {
        return _strokes.SelectMany(s => s).ToList();
    }

    public int CalculateScore()
    {
        double totalLength = 0;

        foreach (var stroke in _strokes)
        {
            for (int i = 1; i < stroke.Count; i++)
            {
                double dx = stroke[i].X - stroke[i - 1].X;
                double dy = stroke[i].Y - stroke[i - 1].Y;
                totalLength += Math.Sqrt(dx * dx + dy * dy);
            }
        }

        return Math.Min((int)(totalLength / 1000), 15);
    }
}