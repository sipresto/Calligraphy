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
        
        List<Circle> circles = GetCircleData();
        double middle = InkCanvas.ActualWidth / 2;
        var dpi = VisualTreeHelper.GetDpi(InkCanvas);
        double dpiX = dpi.PixelsPerInchX;
        
        ViewModel?.Initialize(circles, middle, dpiX);
        
        ViewModel?.DrawingStarted += OnDrawingStarted;
        ViewModel?.DrawingEnded += OnDrawingEnded;
        ViewModel?.Restart += OnRestart;
    }
    
    private void OnDrawingStarted()
    {
        InkCanvas.SetDrawingEnabled(true);
    }
    
    private async void OnDrawingEnded()
    {
        var strokes = InkCanvas.EndDrawing();

        ViewModel?.ProcessFinishedDrawing(strokes);

        if (ViewModel?.GameResult != null)
        {
            // TODO: analysestrokes weghalen
            MascotFeedback.ShowFeedback(
                ViewModel.GameResult.StarCount,
                ViewModel.AnalyzeStrokes()
            );
            await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
        }
    }

    private void OnRestart()
    {
        InkCanvas.Clear();
        ResultPopup.ResetStars();
        MascotFeedback.Hide();
        
        List<Circle> circles = GetCircleData();
        double middle = InkCanvas.ActualWidth / 2;
        var dpi = VisualTreeHelper.GetDpi(InkCanvas);
        double dpiX = dpi.PixelsPerInchX;
        
        ViewModel?.Initialize(circles, middle, dpiX);
    }
    
    private List<Circle> GetCircleData()
    {
        return [GetCircleInfo(LeftCircle), GetCircleInfo(RightCircle)];
    }

    private Circle GetCircleInfo(Ellipse ellipse)
    {
        Point localCenter = new Point(ellipse.Width / 2, ellipse.Height / 2);
        Point canvasCenter = ellipse.TranslatePoint(localCenter, InkCanvas);
        double radius = ellipse.Width / 2;

        return new Circle(canvasCenter.X, canvasCenter.Y, radius);
    }
}