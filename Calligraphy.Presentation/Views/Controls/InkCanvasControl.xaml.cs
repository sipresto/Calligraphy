using System.Windows.Controls;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.Views.Controls;

public partial class InkCanvasControl : UserControl
{
    public InkCanvasControl()
    {
        InitializeComponent();
    }

    public event Action<List<StrokeDto>> StrokeCompleted;

    private void CallyCanvas_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
    {
        var stroke = e.Stroke;

        var points = stroke.StylusPoints
            .Select(p => new StrokeDto(p.X, p.Y, p.PressureFactor))
            .ToList();

        StrokeCompleted?.Invoke(points);
    }

    /*private HandwritingSession _currentSession = new();

    private void CallyCanvas_StylusMove(object sender, StylusEventArgs e)
    {
        StylusPointCollection points = e.GetStylusPoints(CallyCanvas);

        foreach (var point in points)
        {
            var strokePoint = new StrokePoint(
                point.X,
                point.Y,
                point.PressureFactor,
                DateTimeOffset.Now.ToUnixTimeMilliseconds()
            );

            _currentSession.Points.Add(strokePoint);
        }
    }*/
}