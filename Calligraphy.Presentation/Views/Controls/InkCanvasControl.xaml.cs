using System.Windows.Controls;
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
        CallyCanvas.EditingMode = InkCanvasEditingMode.None;
        CallyCanvas.IsEnabled = false;
        
        _strokes.Add(_liveStroke);

        return _strokes;
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
}