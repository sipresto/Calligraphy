using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Calligraphy.Domain;
using XamlAnimatedGif;

namespace Calligraphy.Presentation.Views.themes
{
    public partial class WaveThemeView : UserControl, IThemeView
    {
        // ── Asset paths ──────────────────────────────────────────────────────────
        private const string Base = "/Resources/Assets/Images/Themes/Wave/";
        private const string PillarTop = Base + "terrain_stone_vertical_top.png";
        private const string PillarMiddle = Base + "terrain_stone_vertical_middle.png";
        private const string PillarBottom = Base + "terrain_stone_vertical_bottom.png";
        private const string Waves = Base + "waves.png";

        // ── Layout constants ─────────────────────────────────────────────────────
        private const int PillarSize = 80;
        private const int PillarTopY = 415;
        private const int PillarMiddles = 4;
        private const int LeftPillarX = 20;
        private const int RightPillarX = 1090;

        private const int WavesX = 100;
        private const int WavesY = 415;
        private const int WavesW = 990;
        private const int WavesH = 600;

        public WaveThemeView()
        {
            InitializeComponent();
            Loaded += (_, __) => BuildTerrain();
        }

        private void BuildTerrain()
        {
            TerrainCanvas.Children.Add(MakeImage(Waves, WavesX, WavesY, WavesW, WavesH));

            BuildPillar(LeftPillarX);
            BuildPillar(RightPillarX);
        }

        // Pillar: top + N middles + bottom, each tile 80×80 stacked at exact 80px steps
        private void BuildPillar(int x)
        {
            TerrainCanvas.Children.Add(MakeImage(PillarTop, x, PillarTopY, PillarSize, PillarSize));

            for (int i = 0; i < PillarMiddles; i++)
            {
                int y = PillarTopY + PillarSize * (i + 1);
                TerrainCanvas.Children.Add(MakeImage(PillarMiddle, x, y, PillarSize, PillarSize));
            }

            int bottomY = PillarTopY + PillarSize * (PillarMiddles + 1);
            TerrainCanvas.Children.Add(MakeImage(PillarBottom, x, bottomY, PillarSize, PillarSize));
        }

        private static Image MakeImage(string packUri, int left, int top, int width, int height)
        {
            var img = new Image
            {
                Source = new BitmapImage(new Uri(packUri, UriKind.Relative)),
                Width = width,
                Height = height,
                Stretch = Stretch.Fill,
                SnapsToDevicePixels = true,
                UseLayoutRounding = true,
            };
            RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.NearestNeighbor);
            Canvas.SetLeft(img, left);
            Canvas.SetTop(img, top);
            return img;
        }

       public async Task PlayVictoryAnimation(List<StrokePoint> templatePoints)
{
    var boat = new Image { Width = 130, Height = 130, Stretch = Stretch.Fill };
    AnimationBehavior.SetSourceUri(boat,
        new Uri("pack://application:,,,/Resources/Assets/Images/Themes/Wave/boat.gif", UriKind.Absolute));
    AnimationBehavior.SetRepeatBehavior(boat, RepeatBehavior.Forever);
    AnimationCanvas.Children.Add(boat);

    boat.RenderTransformOrigin = new Point(0.5, 0.5);

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
        const double boatYOffset = -30;
        const double boatXOffset = 30;

        Canvas.SetLeft(boat, point.X - boat.Width / 2 + boatXOffset);
        Canvas.SetTop(boat, point.Y - boat.Height / 2 + boatYOffset);

        double dx = point.X - lastAnglePoint.X;
        double dy = point.Y - lastAnglePoint.Y;
        if (Math.Sqrt(dx * dx + dy * dy) > 5.0)
        {
            boat.RenderTransform = new RotateTransform(Math.Atan2(dy, dx) * (180 / Math.PI));
            lastAnglePoint = point;
        }

        await Task.Delay(TimeSpan.FromMilliseconds(msPerFrame));
    }

    AnimationCanvas.Children.Remove(boat);
}
    }
}