using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Calligraphy.Domain;
using XamlAnimatedGif;

namespace Calligraphy.Presentation.Views.themes;

public partial class LoopThemeView : UserControl, IThemeView
{
    private bool _isPaused;
    private Image _animatedElement;
    
    public LoopThemeView()
    {
        InitializeComponent();
    }

    public async Task PlayVictoryAnimation(List<StrokePoint> templatePoints, CancellationToken cancellationToken = default)
    {
        _isPaused = false;
        var plane = new Image { Width = 100, Height = 100, Stretch = Stretch.Fill };
        AnimationBehavior.SetSourceUri(plane,
            new Uri("pack://application:,,,/Resources/Assets/Images/Themes/plane.gif", UriKind.Absolute));
        AnimationBehavior.SetRepeatBehavior(plane, RepeatBehavior.Forever);
        AnimationCanvas.Children.Add(plane);
        _animatedElement = plane;
        plane.RenderTransformOrigin = new Point(0.5, 0.5);

        const double speedPixelsPerSecond = 400.0;
        const double msPerFrame = 16.0;
        const double pixelsPerFrame = speedPixelsPerSecond * (msPerFrame / 1000.0);

        var evenPoints = ThemeAnimationHelper.ResamplePointsEvenly(templatePoints, pixelsPerFrame);
        if (evenPoints.Count == 0)
        {
            AnimationCanvas.Children.Remove(plane);
            return;
        }

        StrokePoint lastAnglePoint = evenPoints[0];
        foreach (var point in evenPoints)
        {
            if (cancellationToken.IsCancellationRequested) break;

            Canvas.SetLeft(plane, point.X - plane.Width / 2);
            Canvas.SetTop(plane, point.Y - plane.Height / 2);

            lastAnglePoint = ThemeAnimationHelper.UpdateRotationIfMovedEnough(plane, lastAnglePoint, point, 5.0);

            await ThemeAnimationHelper.WaitWhilePausedAsync(() => _isPaused, cancellationToken);

            try
            {
                await Task.Delay(TimeSpan.FromMilliseconds(msPerFrame), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }

        AnimationCanvas.Children.Remove(plane);
    }
    
    public void PauseAnimation()
    {
        _isPaused = true;
        if (_animatedElement != null)
        {
            var animator = AnimationBehavior.GetAnimator(_animatedElement);
            animator?.Pause();
        }
    }

    public void ResumeAnimation()
    {
        _isPaused = false;
        if (_animatedElement != null)
        {
            var animator = AnimationBehavior.GetAnimator(_animatedElement);
            animator?.Play();
        }
    }
}