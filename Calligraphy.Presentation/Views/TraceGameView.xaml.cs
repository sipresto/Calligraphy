using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Domain.TraceTemplates;
using Calligraphy.Presentation.TraceHelpers;
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
    }

    private void DrawHopTemplate()
    {
        TemplateCanvas.Children.Clear();

        var figure = TraceTemplateGeometryBuilder.BuildHopFigure(ViewModel?.GetCurrentTemplateMetadata());

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
}