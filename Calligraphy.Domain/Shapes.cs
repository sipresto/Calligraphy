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
                cy + r * Math.Sin(theta)
                )
            );
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
                cy + radius * Math.Sin(theta)
                )
            );
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
                cy + r * Math.Sin(theta)
                )
            );
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
                cy + ry * Math.Sin(theta)
                )
            );
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
                cy + y * scale)
            );
        }
 
        return [stroke];
    }
}
 
 
public class Cross : Shape
{
    public override string Name => "Cross";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double t = r * 0.22;
 
        var stroke = new List<StrokePoint>
        {
            new(cx - r, cy - r + t),
            new(cx - t, cy),
            new(cx - r, cy + r - t),
            new(cx - r + t, cy + r),
            new(cx, cy + t),
            new(cx + r - t, cy + r),
            new(cx + r, cy + r - t),
            new(cx + t, cy),
            new(cx + r, cy - r + t),
            new(cx + r - t, cy - r),
            new(cx, cy - t),
            new(cx - r + t, cy - r),
            new(cx - r, cy - r + t),
        };
 
        return [stroke];
    }
}
 
public class Plus : Shape
{
    public override string Name => "Plus";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double t = r * 0.28;
 
        var stroke = new List<StrokePoint>
        {
            new(cx - t, cy - r),
            new(cx + t, cy - r),
            new(cx + t, cy - t),
            new(cx + r, cy - t),
            new(cx + r, cy + t),
            new(cx + t, cy + t),
            new(cx + t, cy + r),
            new(cx - t, cy + r),
            new(cx - t, cy + t),
            new(cx - r, cy + t),
            new(cx - r, cy - t),
            new(cx - t, cy - t),
            new(cx - t, cy - r),
        };
 
        return [stroke];
    }
}
 
public class Trapezoid : Shape
{
    public override string Name => "Trapezoid";
 
    public override List<List<StrokePoint>> GetStrokes(double w, double h)
    {
        var (cx, cy, r) = GetLayout(w, h);
        double topW = r * 0.6;
        double botW = r;
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
                cy + r * Math.Sin(theta)
                )
            );
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
        const int segments = 100;

        double rInner = r * 0.8;
        double offset = r * 0.45;

        double icx = cx - offset;
        double icy = cy;

        double d = Math.Abs(icx - cx);
        double a = (r * r - rInner * rInner + d * d) / (2 * d);
        double hVal = Math.Sqrt(Math.Max(0, r * r - a * a));

        double midX = cx - a;

        double tipTopX = midX;
        double tipTopY = cy - hVal;

        double tipBottomX = midX;
        double tipBottomY = cy + hVal;

        double angleTopOuter = Math.Atan2(tipTopY - cy, tipTopX - cx);
        double angleBottomOuter = Math.Atan2(tipBottomY - cy, tipBottomX - cx);

        var stroke = new List<StrokePoint>();

        double outerSweep = angleBottomOuter - angleTopOuter;
        if (outerSweep > 0) outerSweep -= 2 * Math.PI;

        for (int i = 0; i <= segments; i++)
        {
            double t = (double)i / segments;
            double theta = angleTopOuter + outerSweep * t;

            stroke.Add(new StrokePoint(
                cx + r * Math.Cos(theta),
                cy + r * Math.Sin(theta)
                )
            );
        }

        double angleBottomInner = Math.Atan2(tipBottomY - icy, tipBottomX - icx);
        double angleTopInner = Math.Atan2(tipTopY - icy, tipTopX - icx);

        double innerSweep = angleTopInner - angleBottomInner;

        while (innerSweep > Math.PI) innerSweep -= 2 * Math.PI;
        while (innerSweep < -Math.PI) innerSweep += 2 * Math.PI;

        for (int i = 1; i <= segments; i++)
        {
            double t = (double)i / segments;
            double theta = angleBottomInner + innerSweep * t;

            stroke.Add(new StrokePoint(
                icx + rInner * Math.Cos(theta),
                icy + rInner * Math.Sin(theta)
                )
            );
        }

        return [stroke];
    }
}