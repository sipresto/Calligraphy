using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class TraceGameView : UserControl
{
    private TimedTraceGameViewModel ViewModel => DataContext as TimedTraceGameViewModel;

    public TraceGameView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        InkCanvas.SetDrawingEnabled(false);
        ResultPopup.DataContext = DataContext;

        DrawHopTemplate();

        var dpi = VisualTreeHelper.GetDpi(InkCanvas);
        ViewModel?.Initialize(dpi.PixelsPerInchX);

        ViewModel!.DrawingStarted += OnDrawingStarted;
        ViewModel!.DrawingEnded += OnDrawingEnded;
        ViewModel!.Restarted += OnRestart;
    }

    private void OnDrawingStarted() => InkCanvas.SetDrawingEnabled(true);

    private async void OnDrawingEnded()
    {
        var strokes = InkCanvas.EndDrawing();
        ViewModel?.ProcessFinishedDrawing(strokes);

        if (ViewModel?.GameResult != null)
        {
            MascotFeedback.ShowFeedback(
                ViewModel.GameResult.StarCount,
                ViewModel.AnalyzeStrokes());
            await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
        }
    }

    private void OnRestart()
    {
        InkCanvas.Clear();
        ResultPopup.ResetStars();
        MascotFeedback.Hide();
        DrawHopTemplate();

        var dpi = VisualTreeHelper.GetDpi(InkCanvas);
        ViewModel?.Initialize(dpi.PixelsPerInchX);
    }

    private void DrawHopTemplate()
    {
        TemplateCanvas.Children.Clear();

        var figure = BuildHopFigure(
            TimedTraceGameViewModel.StartX,
            TimedTraceGameViewModel.BaselineY,
            TimedTraceGameViewModel.TopY,
            TimedTraceGameViewModel.LoopWidth,
            TimedTraceGameViewModel.LoopCount);
        
        var geometry = new PathGeometry(new[] { figure });

        TemplateCanvas.Children.Add(new Path
        {
            Data = geometry,
            Stroke = new SolidColorBrush(Color.FromArgb(60, 0, 0, 0)),
            StrokeThickness = 10,
            StrokeLineJoin = PenLineJoin.Round,
            StrokeStartLineCap = PenLineCap.Round,
            StrokeEndLineCap = PenLineCap.Round,
        });
    }

    private static PathFigure BuildHopFigure(double startX, double baselineY, double topY,
        double loopWidth, int loopCount)
    {
        var figure = new PathFigure
        {
            StartPoint = new Point(startX, baselineY),
            IsClosed = false
        };

        double x = startX;

        for (int i = 0; i < loopCount; i++)
        {
            figure.Segments.Add(new BezierSegment(
                new Point(x, baselineY - 30),
                new Point(x + loopWidth * 0.2, topY),
                new Point(x + loopWidth * 0.5, topY),
                isStroked: true));

            figure.Segments.Add(new BezierSegment(
                new Point(x + loopWidth * 0.8, topY),
                new Point(x + loopWidth, baselineY - 30),
                new Point(x + loopWidth, baselineY),
                isStroked: true));

            x += loopWidth;
        }

        return figure;
    }
}