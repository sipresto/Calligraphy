using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Calligraphy.Domain;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class InfinityRaceView : UserControl
{
    public InfinityRaceView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private InfinityRaceViewModel ViewModel => DataContext as InfinityRaceViewModel;

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

        ViewModel?.FinishGame(strokes);

        if (ViewModel?.GameResult != null)
        {
            await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
        }
    }

    private void OnRestart()
    {
        InkCanvas.Clear();
        ResultPopup.ResetStars();
    }

    private List<RaceCircle> GetCircleData()
    {
        return [GetCircleInfo(LeftCircle), GetCircleInfo(RightCircle)];
    }

    private RaceCircle GetCircleInfo(Grid circleGrid)
    {
        Point localCenter = new Point(circleGrid.Width / 2, circleGrid.Height / 2);
        Point canvasCenter = circleGrid.TranslatePoint(localCenter, InkCanvas);
        double radius = circleGrid.Width / 2;

        return new RaceCircle(canvasCenter.X, canvasCenter.Y, radius);
    }
}