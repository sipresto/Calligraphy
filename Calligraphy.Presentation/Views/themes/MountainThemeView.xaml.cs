using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Calligraphy.Domain;
using XamlAnimatedGif;

namespace Calligraphy.Presentation.Views.themes
{
    public partial class MountainThemeView : UserControl, IThemeView
    {
        private Storyboard _storyboard;
        private Image _animatedElement;
        // ── Asset paths ──────────────────────────────────────────────────────────
        private const string Base = "/Resources/Assets/Images/Themes/Mountain/";
        private const string RampShortB = Base + "terrain_snow_ramp_short_b.png";
        private const string BlockTopLeft = Base + "terrain_snow_block_top_left.png";
        private const string BlockTop = Base + "terrain_snow_block_top.png";
        private const string BlockTopRight = Base + "terrain_snow_block_top_right.png";
        private const string BlockLeft = Base + "terrain_snow_block_left.png";
        private const string BlockCenter = Base + "terrain_snow_block_center.png";
        private const string BlockRight = Base + "terrain_snow_block_right.png";
        private const string BlockBotLeft = Base + "terrain_snow_block_bottom_left.png";
        private const string BlockBot = Base + "terrain_snow_block_bottom.png";
        private const string BlockBotRight = Base + "terrain_snow_block_bottom_right.png";

        // ── Peak constants ───────────────────────────────────────────────────────
        private const int PeakCount = 12;
        private const int PeakStartX = 100;
        private const int PeakStep = 80;
        private const int PeakTop = 430;
        private const int RampW = 42;
        private const int RampH = 150;

        // ── Block tile constants ─────────────────────────────────────────────────
        private const int BlockSize = 60;
        private const int BlockStartX = 40;
        private const int BlockCols = 17;

        // Row Y positions
        private const int TopY = 570;
        private const int MidRow1Y = 629;
        private const int MidRow2Y = 688;
        private const int BotY = 747;

        public MountainThemeView()
        {
            InitializeComponent();
            Loaded += (_, __) => BuildTerrain();
        }

        private void BuildTerrain()
        {
            BuildPeaks();
            BuildBlockRow(TopY, BlockTopLeft, BlockTop, BlockTopRight);
            BuildBlockRow(MidRow1Y, BlockLeft, BlockCenter, BlockRight);
            BuildBlockRow(MidRow2Y, BlockLeft, BlockCenter, BlockRight);
            BuildBlockRow(BotY, BlockBotLeft, BlockBot, BlockBotRight);
        }

        // Peaks
        private void BuildPeaks()
        {
            for (int i = 0; i < PeakCount; i++)
            {
                int baseX = PeakStartX + i * PeakStep;

                // Left slope
                var left = MakeImage(RampShortB, baseX, PeakTop, RampW, RampH);
                left.RenderTransform = new ScaleTransform(-1, 1, 20.5, 0);
                TerrainCanvas.Children.Add(left);

                // Right slope
                TerrainCanvas.Children.Add(MakeImage(RampShortB, baseX + 40, PeakTop, RampW, RampH));
            }
        }

        // Block rows: left-cap | N centre tiles | right-cap, overlapping 1 px to seal seams
        private void BuildBlockRow(int top, string leftSrc, string centreSrc, string rightSrc)
        {
            TerrainCanvas.Children.Add(MakeImage(leftSrc, BlockStartX, top, BlockSize, BlockSize));
            for (int col = 0; col < BlockCols; col++)
            {
                int x = BlockStartX + BlockSize - 1 + col * (BlockSize - 1);
                TerrainCanvas.Children.Add(MakeImage(centreSrc, x, top, BlockSize, BlockSize));
            }
            int rightX = BlockStartX + BlockSize - 1 + BlockCols * (BlockSize - 1);
            TerrainCanvas.Children.Add(MakeImage(rightSrc, rightX, top, BlockSize, BlockSize));
        }

        private static Image MakeImage(string packUri, int left, int top, int width, int height)
        {
            var img = new Image
            {
                Source = new BitmapImage(new Uri(packUri, UriKind.Relative)),
                Width = width,
                Height = height,
                Stretch = Stretch.Fill,
            };
            Canvas.SetLeft(img, left);
            Canvas.SetTop(img, top);
            return img;
        }

        public async Task PlayVictoryAnimation(List<StrokePoint> templatePoints, CancellationToken cancellationToken = default)
        {
            var goat = new Image { Width = 200, Height = 200, Stretch = Stretch.Fill };
            AnimationBehavior.SetSourceUri(goat,
                new Uri("pack://application:,,,/Resources/Assets/Images/Themes/Mountain/goat.gif", UriKind.Absolute));
            AnimationBehavior.SetRepeatBehavior(goat, RepeatBehavior.Forever);
            Canvas.SetLeft(goat, -100);
            Canvas.SetTop(goat, 400);
            AnimationCanvas.Children.Add(goat);
            _animatedElement = goat; 

            var anim = new DoubleAnimation
            {
                From = 50,
                To = 1000,
                Duration = new Duration(TimeSpan.FromSeconds(8))
            };

            _storyboard = new Storyboard();
            Storyboard.SetTarget(anim, goat);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Canvas.LeftProperty));
            _storyboard.Children.Add(anim);

            await ThemeAnimationHelper.PlayStoryboardAsync(this, _storyboard, cancellationToken);
            AnimationCanvas.Children.Remove(goat);
        }
        public void PauseAnimation()
        {
            if (_storyboard != null) _storyboard.Pause(this);
            if (_animatedElement != null) AnimationBehavior.GetAnimator(_animatedElement)?.Pause();
        }

        public void ResumeAnimation()
        {
            if (_storyboard != null) _storyboard.Resume(this);
            if (_animatedElement != null) AnimationBehavior.GetAnimator(_animatedElement)?.Play();
        }
    }
}