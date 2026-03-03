using Calligraphy.Domain;
namespace Calligraphy.Application;

public static class ShapeFactory
{
    public static List<List<StrokePoint>> GetShape(
        string name,
        double canvasWidth,
        double canvasHeight)
    {
        return name switch
        {
            "Triangle" => CreateTriangle(canvasWidth, canvasHeight),
            "Circle" => CreateCircle(canvasWidth, canvasHeight),
            "Star" => CreateStar(canvasWidth, canvasHeight),
            "Pentagon" => CreatePolygon(5, canvasWidth, canvasHeight),
            "Hexagon" => CreatePolygon(6, canvasWidth, canvasHeight),
            "Diamond" => CreateDiamond(canvasWidth, canvasHeight),
            _ => CreateSquare(canvasWidth, canvasHeight)
        };
    }

    private static (double cx, double cy, double r)
        GetLayout(double width, double height)
    {
        double size = Math.Min(width, height) * 0.6;
        return (width / 2, height / 2, size / 2);
    }

    private static List<List<StrokePoint>> CreateSquare(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        var stroke = new List<StrokePoint>
        {
            new(cx - r, cy - r),
            new(cx + r, cy - r),
            new(cx + r, cy + r),
            new(cx - r, cy + r),
            new(cx - r, cy - r)
        };

        return new() { stroke };
    }

    private static List<List<StrokePoint>> CreateTriangle(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        var stroke = new List<StrokePoint>
        {
            new(cx, cy - r),
            new(cx + r, cy + r),
            new(cx - r, cy + r),
            new(cx, cy - r)
        };

        return new() { stroke };
    }

    private static List<List<StrokePoint>> CreateCircle(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        var stroke = new List<StrokePoint>();
        int segments = 64;

        for (int i = 0; i <= segments; i++)
        {
            double theta = 2 * Math.PI * i / segments;
            stroke.Add(new StrokePoint(
                cx + r * Math.Cos(theta),
                cy + r * Math.Sin(theta)));
        }

        return new() { stroke };
    }

    private static List<List<StrokePoint>> CreateStar(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        double inner = r * 0.4;
        int spikes = 5;

        var stroke = new List<StrokePoint>();

        for (int i = 0; i <= spikes * 2; i++)
        {
            double radius = (i % 2 == 0) ? r : inner;
            double theta = Math.PI * i / spikes - Math.PI / 2;

            stroke.Add(new StrokePoint(
                cx + radius * Math.Cos(theta),
                cy + radius * Math.Sin(theta)));
        }

        return new() { stroke };
    }

    private static List<List<StrokePoint>> CreatePolygon(
        int sides,
        double w,
        double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        var stroke = new List<StrokePoint>();

        for (int i = 0; i <= sides; i++)
        {
            double theta = 2 * Math.PI * i / sides - Math.PI / 2;
            stroke.Add(new StrokePoint(
                cx + r * Math.Cos(theta),
                cy + r * Math.Sin(theta)));
        }

        return new() { stroke };
    }

    private static List<List<StrokePoint>> CreateDiamond(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        var stroke = new List<StrokePoint>
        {
            new(cx, cy - r),
            new(cx + r, cy),
            new(cx, cy + r),
            new(cx - r, cy),
            new(cx, cy - r)
        };

        return new() { stroke };
    }
}