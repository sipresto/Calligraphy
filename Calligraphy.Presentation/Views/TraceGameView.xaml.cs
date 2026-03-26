using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Calligraphy.Presentation.ViewModels;
using Calligraphy.Presentation.Views.themes;
using Calligraphy.Presentation.Views.Controls;

namespace Calligraphy.Presentation.Views;

public partial class TraceGameView : UserControl
{
    private CancellationTokenSource _animationCts;

    public TraceGameView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private ITraceGameViewModel ViewModel => DataContext as ITraceGameViewModel;

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel.IsTimed)
            InkCanvas.SetDrawingEnabled(false);

        ResultPopup.DataContext = DataContext;
        PausePopup.DataContext = DataContext;

        ViewModel!.DrawingStarted += OnDrawingStarted;
        ViewModel!.DrawingEnded += OnDrawingEnded;
        ViewModel!.Restarted += OnRestart;
        ViewModel!.Paused += OnPaused;
        ViewModel!.Resumed += OnResumed;
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

        if (ViewModel?.GameResult != null)
        {
            _animationCts = new CancellationTokenSource();
            var themeView = FindThemeView(ThemeHost);

            if (themeView != null)
            {
                ViewModel.IsAnimationPlaying = true;
                await themeView.PlayVictoryAnimation(ViewModel.TemplatePoints, _animationCts.Token);
            }

            if (_animationCts == null || _animationCts.IsCancellationRequested || ViewModel?.GameResult == null)
            {
                return;
            }

            ViewModel.IsAnimationPlaying = false;
            await GameResultViewHelpers.AnimateStarsIfResultAsync(ResultPopup, ViewModel.GameResult);
        }
    }

    private void OnPaused()
    {
        var themeView = FindThemeView(ThemeHost);
        themeView?.PauseAnimation();
    }
    
    private void OnResumed()
    {
        var themeView = FindThemeView(ThemeHost);
        themeView?.ResumeAnimation();
    }

    private IThemeView FindThemeView(DependencyObject parent)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is IThemeView themeView) return themeView;
            var result = FindThemeView(child);
            if (result != null) return result;
        }
        return null;
    }

    private void OnRestart()
    {
        _animationCts?.Cancel();
        _animationCts = null;
        InkCanvas.Clear(ViewModel.EndOnLift);
        ResultPopup.ResetStars();
    }
}