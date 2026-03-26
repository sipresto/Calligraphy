using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Calligraphy.Domain;

namespace Calligraphy.Presentation.Views.themes
{
    internal static class ThemeAnimationHelper
    {
        public static List<StrokePoint> ResamplePointsEvenly(IReadOnlyList<StrokePoint> templatePoints,
            double pixelsPerFrame)
        {
            if (templatePoints == null || templatePoints.Count == 0)
                return [];

            if (pixelsPerFrame <= 0)
                return new List<StrokePoint>(templatePoints);

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

            return evenPoints;
        }

        public static async Task WaitWhilePausedAsync(Func<bool> isPaused, CancellationToken cancellationToken,
            int delayMs = 50)
        {
            while (isPaused())
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    await Task.Delay(delayMs, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
        }

        public static StrokePoint UpdateRotationIfMovedEnough(Image element, StrokePoint lastAnglePoint,
            StrokePoint point, double distanceThresholdPx = 5.0)
        {
            double dx = point.X - lastAnglePoint.X;
            double dy = point.Y - lastAnglePoint.Y;

            if (Math.Sqrt(dx * dx + dy * dy) <= distanceThresholdPx)
                return lastAnglePoint;

            element.RenderTransform = new RotateTransform(Math.Atan2(dy, dx) * (180 / Math.PI));
            return point;
        }

        public static async Task PlayStoryboardAsync(FrameworkElement host, Storyboard storyboard,
            CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            EventHandler completedHandler = null;
            completedHandler = (_, __) => tcs.TrySetResult(true);

            storyboard.Completed += completedHandler;
            storyboard.Begin(host, true);

            using (cancellationToken.Register(() =>
                   {
                       storyboard.Stop(host);
                       tcs.TrySetResult(false);
                   }))
            {
                await tcs.Task;
            }

            storyboard.Completed -= completedHandler;
        }
    }
}

