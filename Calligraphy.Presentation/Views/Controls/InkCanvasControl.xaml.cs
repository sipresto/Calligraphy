using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.Views.Controls;

public partial class InkCanvasControl : UserControl
{
    private List<List<StrokePointDto>> _strokes = [];
    private List<StrokePointDto> _liveStroke = [];
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    
    public InkCanvasControl()
    {
        InitializeComponent();
        
        CallyCanvas.EditingMode = InkCanvasEditingMode.Ink;
        CallyCanvas.EditingModeInverted = InkCanvasEditingMode.None;
    }
    
    public List<List<StrokePointDto>> EndDrawing()
    {
        CallyCanvas.IsEnabled = false;
        
        if (_liveStroke.Count > 0)
        {
            _strokes.Add(_liveStroke);
        }
        
        DisplayStoredStrokes(_strokes);

        var finishedStrokes = _strokes;
        _strokes = [];
        _liveStroke = [];
        return finishedStrokes;
    }
    
    public void SetDrawingEnabled(bool enabled)
    {
        CallyCanvas.IsEnabled = enabled;
    }
    
    public void Clear()
    {
        _strokes = [];
        _liveStroke = [];
        CallyCanvas.Strokes.Clear();
    }

    private void CallyCanvas_StylusMove(object sender, StylusEventArgs e)
    {
        StylusPointCollection points = e.GetStylusPoints(CallyCanvas);

        foreach (var point in points)
        {
            var strokePoint = new StrokePointDto(
                point.X,
                point.Y,
                point.PressureFactor,
                _stopwatch.ElapsedMilliseconds
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
}