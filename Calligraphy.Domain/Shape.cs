namespace Calligraphy.Domain;

public abstract class Shape
{
    public abstract string Name { get; }

    public abstract List<List<StrokePoint>> GetStrokes(double canvasWidth, double canvasHeight);


    protected static (double cx, double cy, double r) GetLayout(double w, double h)
    {
        double size = Math.Min(w, h) * 0.6;
        return (w / 2, h / 2, size / 2);
    }
}