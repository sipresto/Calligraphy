using System.Windows.Controls;
using System.Windows.Input;
using Calligraphy.Domain;

namespace Calligraphy.Presentation.Views.Controls;

public partial class InkCanvasControl : UserControl
{
    public InkCanvasControl()
    {
        InitializeComponent();
    }
    
    private HandwritingSession _currentSession = new();

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
    }
    
    private async void CallyCanvas_StylusUp(object sender, StylusEventArgs e)
    {
        if (_currentSession.Points.Count > 0)
        {

        }

        _currentSession = new HandwritingSession { TargetLetter = "A" }; 
    }

}