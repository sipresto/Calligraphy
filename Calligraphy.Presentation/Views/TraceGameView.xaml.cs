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
    }
}