using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Domain;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class InfinityRaceView : UserControl
{
    private InfinityRaceViewModel ViewModel => DataContext as InfinityRaceViewModel;
    
    public InfinityRaceView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        InkCanvas.SetDrawingEnabled(false);
        ResultPopup.DataContext = DataContext;
        
        List<RaceCircle> circles = GetCircleData();
        
        ViewModel?.Initialize(circles);
        
        ViewModel?.DrawingStarted += OnDrawingStarted;
        ViewModel?.DrawingEnded += OnDrawingEnded;
        ViewModel?.Restarted += OnRestart;
    }
    
    private void OnDrawingStarted()
    {
        InkCanvas.SetDrawingEnabled(true);
    }
    
    private async void OnDrawingEnded()
    {
        var strokes = InkCanvas.EndDrawing();

        ViewModel?.FinishGame(strokes, new StarThresholds(1, 5, 10));

        if (ViewModel?.GameResult != null)
        {
            await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
        }
    }

    private void OnRestart()
    {
        InkCanvas.Clear();
        ResultPopup.ResetStars();
        
        List<RaceCircle> circles = GetCircleData();
        
        ViewModel?.Initialize(circles);
    }
    
    private List<RaceCircle> GetCircleData()
    {
        return [GetCircleInfo(LeftCircle), GetCircleInfo(RightCircle)];
    }

    private RaceCircle GetCircleInfo(Ellipse ellipse)
    {
        Point localCenter = new Point(ellipse.Width / 2, ellipse.Height / 2);
        Point canvasCenter = ellipse.TranslatePoint(localCenter, InkCanvas);
        double radius = ellipse.Width / 2;

        return new RaceCircle(canvasCenter.X, canvasCenter.Y, radius);
    }
}