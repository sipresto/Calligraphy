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
            new(cx, cy - r),
            new(cx + r, cy + r),
            new(cx - r, cy + r),
            new(cx, cy - r)
        };

        return [stroke];
    }
}

public class Circle : Shape
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
            double theta = Math.PI * i / spikes - Math.PI / 2;
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
            new(cx, cy - r),
            new(cx + r, cy),
            new(cx, cy + r),
            new(cx - r, cy),
            new(cx, cy - r)
        };

        return [stroke];
    }
}

public class Pentagon : Shape
{
    public override string Name => "Pentagon";

    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        return PolygonStrokes(5, w, h);
    }

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
    {
        return Pentagon.PolygonStrokes(6, w, h);
    }
}

public class Oval : Shape
{
    public override string Name => "Oval";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double rx = r * 1.4;
        double ry = r * 0.75;
        var stroke = new List<StrokePoint>();
        const int segments = 64;
 
        for (int i = 0; i <= segments; i++)
        {
            double theta = 2 * Math.PI * i / segments;
            stroke.Add(new StrokePoint(
                cx + rx * Math.Cos(theta),
                cy + ry * Math.Sin(theta)));
        }
 
        return [stroke];
    }
}
 
public class Heart : Shape
{
    public override string Name => "Heart";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double scale = r / 16.0;
        var stroke = new List<StrokePoint>();
        const int segments = 128;
 
        for (int i = 0; i <= segments; i++)
        {
            double t = 2 * Math.PI * i / segments;
            double x = 16 * Math.Pow(Math.Sin(t), 3);
            double y = -(13 * Math.Cos(t) - 5 * Math.Cos(2 * t)
                        - 2 * Math.Cos(3 * t) - Math.Cos(4 * t));
            stroke.Add(new StrokePoint(
                cx + x * scale,
                cy + y * scale));
        }
 
        return [stroke];
    }
}
 
public class Arrow : Shape
{
    public override string Name => "Arrow";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double shaftH = r * 0.35;
        double headX  = cx;
 
        var stroke = new List<StrokePoint>
        {
            new(cx - r,   cy - shaftH),
            new(headX,    cy - shaftH),
            new(headX,    cy - r),
            new(cx + r,   cy),
            new(headX,    cy + r),
            new(headX,    cy + shaftH),
            new(cx - r,   cy + shaftH),
            new(cx - r,   cy - shaftH),
        };
 
        return [stroke];
    }
}
 
public class Cross : Shape
{
    public override string Name => "Cross";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
 
        var stroke1 = new List<StrokePoint>
        {
            new(cx - r, cy - r),
            new(cx + r, cy + r),
        };
 
        var stroke2 = new List<StrokePoint>
        {
            new(cx + r, cy - r),
            new(cx - r, cy + r),
        };
 
        return [stroke1, stroke2];
    }
}
 
public class Plus : Shape
{
    public override string Name => "Plus";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
 
        var horizontal = new List<StrokePoint>
        {
            new(cx - r, cy),
            new(cx + r, cy),
        };
 
        var vertical = new List<StrokePoint>
        {
            new(cx, cy - r),
            new(cx, cy + r),
        };
 
        return [horizontal, vertical];
    }
}
 
public class Trapezoid : Shape
{
    public override string Name => "Trapezoid";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double topW  = r * 0.6;
        double botW  = r;
        double halfH = r * 0.6;
 
        var stroke = new List<StrokePoint>
        {
            new(cx - topW, cy - halfH),
            new(cx + topW, cy - halfH),
            new(cx + botW, cy + halfH),
            new(cx - botW, cy + halfH),
            new(cx - topW, cy - halfH),
        };
 
        return [stroke];
    }
}
 
public class HalfMoon : Shape
{
    public override string Name => "HalfMoon";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        var stroke = new List<StrokePoint>();
        const int segments = 64;
 
        for (int i = 0; i <= segments; i++)
        {
            double theta = -Math.PI / 2 + Math.PI * i / segments;
            stroke.Add(new StrokePoint(
                cx + r * Math.Cos(theta),
                cy + r * Math.Sin(theta)));
        }
 
        stroke.Add(new StrokePoint(cx, cy - r));
 
        return [stroke];
    }
}
 
public class WaningMoon : Shape
{
    public override string Name => "WaningMoon";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double rInner = r * 0.65;
        double offset = r * 0.30;
        var stroke = new List<StrokePoint>();
        const int segments = 64;
 
        for (int i = 0; i <= segments; i++)
        {
            double theta = 2 * Math.PI * i / segments;
            stroke.Add(new StrokePoint(
                cx + r * Math.Cos(theta),
                cy + r * Math.Sin(theta)));
        }
 
        for (int i = segments; i >= 0; i--)
        {
            double theta = 2 * Math.PI * i / segments;
            stroke.Add(new StrokePoint(
                cx + offset + rInner * Math.Cos(theta),
                cy +          rInner * Math.Sin(theta)));
        }
 
        return [stroke];
    }
}
 
public class FourLeafClover : Shape
{
    public override string Name => "FourLeafClover";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        var stroke = new List<StrokePoint>();
        const int segments = 256;
 
        for (int i = 0; i <= segments; i++)
        {
            double theta = 2 * Math.PI * i / segments;
            double radius = r * Math.Abs(Math.Cos(2 * theta));
            stroke.Add(new StrokePoint(
                cx + radius * Math.Cos(theta),
                cy + radius * Math.Sin(theta)));
        }
 
        return [stroke];
    }
}