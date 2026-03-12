using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
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
        InkCanvas.SetDrawingEnabled(false);
        ResultPopup.DataContext = DataContext;

        DrawTemplate();

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
        DrawTemplate();
    }

    private void DrawTemplate()
    {
        TemplateCanvas.Children.Clear();

        var points = ViewModel?.GetTemplatePoints();
        if (points == null || !points.Any()) return;

        var figure = new PathFigure
        {
            StartPoint = new Point(points[0].X, points[0].Y),
            IsClosed = false
        };

        var wpfPoints = points.Skip(1).Select(p => new Point(p.X, p.Y));

        var segment = new PolyLineSegment(wpfPoints, true);
        figure.Segments.Add(segment);

        var geometry = new PathGeometry(new[] { figure });

        TemplateCanvas.Children.Add(new Path
        {
            Data = geometry,
            Stroke = new SolidColorBrush(Color.FromArgb(60, 0, 0, 0)),
            StrokeThickness = ViewModel.GetThickness(),
            StrokeLineJoin = PenLineJoin.Round,
            StrokeStartLineCap = PenLineCap.Round,
            StrokeEndLineCap = PenLineCap.Round
        });
    }
}