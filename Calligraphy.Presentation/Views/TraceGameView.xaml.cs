using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Domain;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class TraceGameView : UserControl
{
    public TraceGameView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private ITraceGameViewModel ViewModel => DataContext as ITraceGameViewModel;

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel.IsTimed)
        {
            InkCanvas.SetDrawingEnabled(false);
        }
        ResultPopup.DataContext = DataContext;

        DrawTemplate();

        ViewModel!.DrawingStarted += OnDrawingStarted;
        ViewModel!.DrawingEnded += OnDrawingEnded;
        ViewModel!.Restarted += OnRestart;
        InkCanvas.StylusUp += OnStylusUp;
    }

    private void OnStylusUp()
    {
        if (ViewModel.EndOnLift && ViewModel.SegmentCountCompleted()) 
            OnDrawingEnded();
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
        InkCanvas.Clear(ViewModel.EndOnLift);
        ResultPopup.ResetStars();
        DrawTemplate();
    }

    private void DrawTemplate()
    {
        TemplateCanvas.Children.Clear();

        var points = ViewModel?.GetTemplatePoints();
        if (points == null || !points.Any()) return;

        var geometry = new PathGeometry();

        var currentFigure = new PathFigure
        {
            StartPoint = new Point(points[0].X, points[0].Y),
            IsClosed = false
        };
        var currentSegment = new PolyLineSegment { IsStroked = true };

        for (int i = 1; i < points.Count; i++)
        {
            var prevPoint = points[i - 1];
            var currentPoint = points[i];

            if (Distance(prevPoint, currentPoint) > 40)
            {
                currentFigure.Segments.Add(currentSegment);
                geometry.Figures.Add(currentFigure);

                currentFigure = new PathFigure
                {
                    StartPoint = new Point(currentPoint.X, currentPoint.Y),
                    IsClosed = false
                };
                currentSegment = new PolyLineSegment { IsStroked = true };
            }
            else
            {
                currentSegment.Points.Add(new Point(currentPoint.X, currentPoint.Y));
            }
        }

        currentFigure.Segments.Add(currentSegment);
        geometry.Figures.Add(currentFigure);

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
    
    private double Distance(StrokePoint p1, StrokePoint p2)
    {
        double dx = p1.X - p2.X;
        double dy = p1.Y - p2.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}