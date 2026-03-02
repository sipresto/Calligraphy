using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.Views.Controls;

public partial class InkCanvasControl : UserControl
{
    private readonly List<List<StrokePointDto>> _strokes = [];
    private List<StrokePointDto> _liveStroke = [];
    
    public InkCanvasControl()
    {
        InitializeComponent();
    }

    // Stroke finished by lifting pen
    public event Action<List<StrokePointDto>> StrokeCompleted;

    private void CallyCanvas_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
    {
        var stroke = e.Stroke;

        var points = stroke.StylusPoints
            .Select(p => new StrokePointDto(p.X, p.Y, p.PressureFactor))
            .ToList();

        StrokeCompleted?.Invoke(points);
    }

    // Stroke finished by calling code
    public List<List<StrokePointDto>> EndDrawing()
    {
        CallyCanvas.IsEnabled = false;
        
        if (_liveStroke.Count > 0)
        {
            _strokes.Add(_liveStroke);
        }
        
        DisplayStoredStrokes(_strokes);

        return _strokes;
    }
    
    public void SetDrawingEnabled(bool enabled)
    {
        CallyCanvas.IsEnabled = enabled;
    }

    private void CallyCanvas_StylusMove(object sender, StylusEventArgs e)
    {
        StylusPointCollection points = e.GetStylusPoints(CallyCanvas);

        foreach (var point in points)
        {
            var strokePoint = new StrokePointDto(
                point.X,
                point.Y,
                point.PressureFactor
            );
            
            _liveStroke.Add(strokePoint);
        }
    }

    private void CallyCanvas_StylusUp(object sender, StylusEventArgs e)
    {
        _strokes.Add(_liveStroke);
        _liveStroke = [];
    }
    
    private void DisplayStoredStrokes(List<List<StrokePointDto>> strokes)
    {
        CallyCanvas.Strokes.Clear();

        foreach (var stroke in strokes)
        {
            if (stroke == null || stroke.Count == 0)
                continue;
            
            var stylusPoints = new StylusPointCollection(
                stroke.Select(p => new StylusPoint(p.X, p.Y, p.Pressure))
            );

            var newStroke = new Stroke(stylusPoints);
            CallyCanvas.Strokes.Add(newStroke);
        }
    }
    
    public void Clear()
    {
        _strokes.Clear();
        _liveStroke.Clear();
        CallyCanvas.Strokes.Clear();
    }
}