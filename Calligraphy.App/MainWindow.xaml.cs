using System.Windows;
using System.Windows.Input;
using Calligraphy.Core;
using Calligraphy.Infrastructure;
namespace Calligraphy.App;

public partial class MainWindow : Window
{
    public MainWindow()
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
            var service = new FastApiHandwritingService(); 

            bool success = await service.SubmitSessionAsync(_currentSession);

            if (success) {
                Console.WriteLine("Data succesvol geanalyseerd door Python!");
            }
        }

        _currentSession = new HandwritingSession { TargetLetter = "A" }; 
    }
}