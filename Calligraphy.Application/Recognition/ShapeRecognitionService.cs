using Calligraphy.Domain;

namespace Calligraphy.Application.Recognition;

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
        // Example templates:
        // Add square, circle, star, etc.
        // _recognizer.AddGesture(new Multistroke("Square", strokes));
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
    
    private List<List<PointR>> ConvertToRecognizerFormat(List<List<StrokePoint>> strokes)
    {
        return strokes
            .Select(stroke =>
                stroke.Select(p => new PointR(p.X, p.Y)).ToList())
            .ToList();
    }}