namespace Calligraphy.Domain;

public class Square : Shape
{
    public override string Name => "Square";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
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

        return [stroke];
    }
}

public class Triangle : Shape
{
    public override string Name => "Triangle";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        var stroke = new List<StrokePoint>
        {
            new(cx,     cy - r),
            new(cx + r, cy + r),
            new(cx - r, cy + r),
            new(cx,     cy - r)
        };

        return [stroke];
    }
}

public class CircleShape : Shape
{
    public override string Name => "Circle";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        var stroke = new List<StrokePoint>();
        const int segments = 64;

        for (int i = 0; i <= segments; i++)
        {
            double theta = 2 * Math.PI * i / segments;
            stroke.Add(new StrokePoint(
                cx + r * Math.Cos(theta),
                cy + r * Math.Sin(theta)));
        }

        return [stroke];
    }
}

public class Star : Shape
{
    public override string Name => "Star";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double inner = r * 0.4;
        const int spikes = 5;
        var stroke = new List<StrokePoint>();

        for (int i = 0; i <= spikes * 2; i++)
        {
            double radius = (i % 2 == 0) ? r : inner;
            double theta  = Math.PI * i / spikes - Math.PI / 2;
            stroke.Add(new StrokePoint(
                cx + radius * Math.Cos(theta),
                cy + radius * Math.Sin(theta)));
        }

        return [stroke];
    }
}

public class Diamond : Shape
{
    public override string Name => "Diamond";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);

        var stroke = new List<StrokePoint>
        {
            new(cx,     cy - r),
            new(cx + r, cy    ),
            new(cx,     cy + r),
            new(cx - r, cy    ),
            new(cx,     cy - r)
        };

        return [stroke];
    }
}

public class Pentagon : Shape
{
    public override string Name => "Pentagon";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
        => PolygonStrokes(5, w, h);

    public static List<List<StrokePoint>> PolygonStrokes(int sides, double w, double h)
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

        return [stroke];
    }
}

public class Hexagon : Shape
{
    public override string Name => "Hexagon";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
        => Pentagon.PolygonStrokes(6, w, h);
}
