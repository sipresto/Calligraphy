using Calligraphy.Application.Recognition;
using Calligraphy.Domain;

namespace Calligraphy.Application;

public class ShapeRecognitionService : IShapeRecognitionService
{
    private readonly NDollarRecognizer _recognizer;

    public ShapeRecognitionService()
    {
        _recognizer = new NDollarRecognizer();
        LoadTemplates();
    }

    private void LoadTemplates()
    {
        AddTemplate("Square", CreateSquare());
        AddTemplate("Triangle", CreateTriangle());
        AddTemplate("Circle", CreateCircle());
        AddTemplate("Star", CreateStar());
        AddTemplate("Pentagon", CreatePentagon());
        AddTemplate("Hexagon", CreateHexagon());
        AddTemplate("Diamond", CreateDiamond());
    }

    private void AddTemplate(string name, List<List<PointR>> strokes)
    {
        var gesture = new Multistroke(name, "template", "template", strokes);
        _recognizer.AddGesture(gesture);
    }
    
    public RecognitionResult Recognize(List<List<StrokePoint>> strokes)
    {
        var flattenedPoints = new List<PointR>();

        foreach (var stroke in strokes)
        {
            foreach (var point in stroke)
            {
                flattenedPoints.Add(new PointR(point.X, point.Y));
            }
        }

        int numStrokes = strokes.Count;

        var result = _recognizer.Recognize(flattenedPoints, numStrokes);

        return new RecognitionResult
        {
            Name = result.Name,
            Score = result.Score
        };
    }
    
    private double GetBoundingBoxSize(List<PointR> points)
    {
        double minX = points.Min(p => p.X);
        double maxX = points.Max(p => p.X);
        double minY = points.Min(p => p.Y);
        double maxY = points.Max(p => p.Y);

        return Math.Max(maxX - minX, maxY - minY);
    }
    
    private List<List<PointR>> CreateSquare()
    {
        var stroke = new List<PointR>
        {
            new(0,0),
            new(200,0),
            new(200,200),
            new(0,200),
            new(0,0)
        };

        return new List<List<PointR>> { stroke };
    }
    
    private List<List<PointR>> CreateTriangle()
    {
        var stroke = new List<PointR>
        {
            new(100,0),
            new(200,200),
            new(0,200),
            new(100,0)
        };

        return new List<List<PointR>> { stroke };
    }
    
    private List<List<PointR>> CreateCircle()
    {
        var stroke = new List<PointR>();
        int segments = 64;
        double r = 100;

        for (int i = 0; i <= segments; i++)
        {
            double theta = 2 * Math.PI * i / segments;
            stroke.Add(new PointR(
                100 + r * Math.Cos(theta),
                100 + r * Math.Sin(theta)));
        }

        return new List<List<PointR>> { stroke };
    }
    
    private List<List<PointR>> CreateStar()
    {
        var stroke = new List<PointR>();
        int spikes = 5;
        double outer = 100;
        double inner = 40;

        for (int i = 0; i <= spikes * 2; i++)
        {
            double radius = (i % 2 == 0) ? outer : inner;
            double theta = Math.PI * i / spikes;

            stroke.Add(new PointR(
                100 + radius * Math.Cos(theta),
                100 + radius * Math.Sin(theta)));
        }

        return new List<List<PointR>> { stroke };
    }
    
    private List<List<PointR>> CreatePolygon(int sides)
    {
        var stroke = new List<PointR>();
        double r = 100;

        for (int i = 0; i <= sides; i++)
        {
            double theta = 2 * Math.PI * i / sides;
            stroke.Add(new PointR(
                100 + r * Math.Cos(theta),
                100 + r * Math.Sin(theta)));
        }

        return new List<List<PointR>> { stroke };
    }

    private List<List<PointR>> CreatePentagon() => CreatePolygon(5);
    private List<List<PointR>> CreateHexagon() => CreatePolygon(6);
    
    private List<List<PointR>> CreateDiamond()
    {
        var stroke = new List<PointR>
        {
            new(100,0),
            new(200,100),
            new(100,200),
            new(0,100),
            new(100,0)
        };

        return new List<List<PointR>> { stroke };
    }
}