using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Calligraphy.Domain;
using XamlAnimatedGif;

namespace Calligraphy.Presentation.Views.themes;

public partial class LoopThemeView : UserControl, IThemeView
{
    public LoopThemeView()
    {
        InitializeComponent();
    }

    public async Task PlayVictoryAnimation(List<StrokePoint> templatePoints)
{
    var plane = new Image { Width = 100, Height = 100, Stretch = Stretch.Fill };
    AnimationBehavior.SetSourceUri(plane,
        new Uri("pack://application:,,,/Resources/Assets/Images/Themes/plane.gif", UriKind.Absolute));
    AnimationBehavior.SetRepeatBehavior(plane, RepeatBehavior.Forever);
    AnimationCanvas.Children.Add(plane);

    plane.RenderTransformOrigin = new Point(0.5, 0.5);

    const double speedPixelsPerSecond = 300.0;
    const double msPerFrame = 16.0;
    const double pixelsPerFrame = speedPixelsPerSecond * (msPerFrame / 1000.0);

    var evenPoints = new List<StrokePoint>();
    evenPoints.Add(templatePoints[0]);

    double accumulated = 0;
    int srcIndex = 0;
    var current = templatePoints[0];

    while (srcIndex < templatePoints.Count - 1)
    {
        var next = templatePoints[srcIndex + 1];
        double dx = next.X - current.X;
        double dy = next.Y - current.Y;
        double segLen = Math.Sqrt(dx * dx + dy * dy);

        if (accumulated + segLen >= pixelsPerFrame)
        {
            double t = (pixelsPerFrame - accumulated) / segLen;
            current = new StrokePoint(current.X + dx * t, current.Y + dy * t);
            evenPoints.Add(current);
            accumulated = 0;
        }
        else
        {
            accumulated += segLen;
            srcIndex++;
            current = next;
        }
    }

    StrokePoint lastAnglePoint = evenPoints[0];
    foreach (var point in evenPoints)
    {
        Canvas.SetLeft(plane, point.X - plane.Width / 2);
        Canvas.SetTop(plane, point.Y - plane.Height / 2);

        double dx = point.X - lastAnglePoint.X;
        double dy = point.Y - lastAnglePoint.Y;
        if (Math.Sqrt(dx * dx + dy * dy) > 5.0)
        {
            plane.RenderTransform = new RotateTransform(Math.Atan2(dy, dx) * (180 / Math.PI));
            lastAnglePoint = point;
        }

        await Task.Delay(TimeSpan.FromMilliseconds(msPerFrame));
    }

    AnimationCanvas.Children.Remove(plane);
}
}