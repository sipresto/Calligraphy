using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Domain.TraceTemplates;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class TraceGameView : UserControl
{
    public TraceGameView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private TimedTraceGameViewModel ViewModel => DataContext as TimedTraceGameViewModel;

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        // TODO: remove hardcode when creating select screen. Also currently being 
        ViewModel?.Initialize("TimedTraceHop");
        
        InkCanvas.SetDrawingEnabled(false);
        ResultPopup.DataContext = DataContext;

        DrawHopTemplate();

        ViewModel!.DrawingStarted += OnDrawingStarted;
        ViewModel!.DrawingEnded += OnDrawingEnded;
        ViewModel!.Restarted += OnRestart;
    }

    private void OnDrawingStarted()
    {
        InkCanvas.SetDrawingEnabled(true);
    }

    private async void OnDrawingEnded()
    {
        var strokes = InkCanvas.EndDrawing();
        ViewModel?.FinishGame(strokes);

        if (ViewModel?.GameResult != null) await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
    }

    private void OnRestart()
    {
        InkCanvas.Clear();
        ResultPopup.ResetStars();
        DrawHopTemplate();

        // TODO: remove hardcode when creating select screen
        ViewModel?.Initialize("TimedTraceHop");
    }

    private void DrawHopTemplate()
    {
        TemplateCanvas.Children.Clear();

        var figure = BuildHopFigure(ViewModel?.GetCurrentTemplateMetadata());

        var geometry = new PathGeometry(new[] { figure });

        TemplateCanvas.Children.Add(new Path
        {
            Data = geometry,
            Stroke = new SolidColorBrush(Color.FromArgb(60, 0, 0, 0)),
            StrokeThickness = 10,
            StrokeLineJoin = PenLineJoin.Round,
            StrokeStartLineCap = PenLineCap.Round,
            StrokeEndLineCap = PenLineCap.Round
        });
    }

    private static PathFigure BuildHopFigure(TraceTemplateMetadata data)
    {
        var figure = new PathFigure
        {
            StartPoint = new Point(data.StartX, data.BaselineY),
            IsClosed = false
        };

        double x = data.StartX;

        for (int i = 0; i < data.LoopCount; i++)
        {
            figure.Segments.Add(new BezierSegment(
                new Point(x, data.BaselineY - 30),
                new Point(x + data.LoopWidth * 0.2, data.TopY),
                new Point(x + data.LoopWidth * 0.5, data.TopY),
                true));

            figure.Segments.Add(new BezierSegment(
                new Point(x + data.LoopWidth * 0.8, data.TopY),
                new Point(x + data.LoopWidth, data.BaselineY - 30),
                new Point(x + data.LoopWidth, data.BaselineY),
                true));

            x += data.LoopWidth;
        }

        return figure;
    }
}