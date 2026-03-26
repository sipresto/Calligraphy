using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Calligraphy.Domain;
using XamlAnimatedGif;

namespace Calligraphy.Presentation.Views.themes
{
    public partial class HedgeThemeView : UserControl, IThemeView
    {
        private Storyboard _storyboard;
        private Image _animatedElement;
        // ── Asset paths ──────────────────────────────────────────────────────────
        private const string Base = "/Resources/Assets/Images/Themes/Hedge/";
        private const string Hedge = Base + "Hedge.png";
        private const string BlockTopLeft = Base + "terrain_grass_block_top_left.png";
        private const string BlockTop = Base + "terrain_grass_block_top.png";
        private const string BlockTopRight = Base + "terrain_grass_block_top_right.png";
        private const string BlockLeft = Base + "terrain_grass_block_left.png";
        private const string BlockCenter = Base + "terrain_grass_block_center.png";
        private const string BlockRight = Base + "terrain_grass_block_right.png";
        private const string BlockBotLeft = Base + "terrain_grass_block_bottom_left.png";
        private const string BlockBot = Base + "terrain_grass_block_bottom.png";
        private const string BlockBotRight = Base + "terrain_grass_block_bottom_right.png";

        // ── Hedge row constants ──────────────────────────────────────────────────
        private const int HedgeStripY = 457;
        private const int HedgeStripX = 100;
        private const int HedgeStripW = 980;
        private const int HedgeStripH = 20;

        private const int HedgeTopY = 417;
        private const int HedgeTopH = 60;
        private const int HedgeSegW = 110;
        private const int HedgeStartX = 100;
        private const int HedgeCount = 9;

        // ── Block tile constants ─────────────────────────────────────────────────
        private const int BlockSize = 80;
        private const int BlockStartX = 20;
        private const int BlockCols = 13;

        // Row Y positions
        private const int TopY = 477;
        private const int MidRow1Y = 556;
        private const int MidRow2Y = 635;
        private const int MidRow3Y = 714;
        private const int BotY = 793;

        public HedgeThemeView()
        {
            InitializeComponent();
            Loaded += (_, __) => BuildTerrain();
        }

        private void BuildTerrain()
        {
            BuildHedge();
            BuildBlockRow(TopY, BlockTopLeft, BlockTop, BlockTopRight);
            BuildBlockRow(MidRow1Y, BlockLeft, BlockCenter, BlockRight);
            BuildBlockRow(MidRow2Y, BlockLeft, BlockCenter, BlockRight);
            BuildBlockRow(MidRow3Y, BlockLeft, BlockCenter, BlockRight);
            BuildBlockRow(BotY, BlockBotLeft, BlockBot, BlockBotRight);
        }

        // Hedge
        private void BuildHedge()
        {
            TerrainCanvas.Children.Add(MakeImage(Hedge, HedgeStripX, HedgeStripY, HedgeStripW, HedgeStripH));
            for (int i = 0; i < HedgeCount; i++)
            {
                int x = HedgeStartX + i * HedgeSegW;
                TerrainCanvas.Children.Add(MakeImage(Hedge, x, HedgeTopY, HedgeSegW, HedgeTopH));
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
            var squirrel = new Image { Width = 200, Height = 200, Stretch = Stretch.Fill };
            AnimationBehavior.SetSourceUri(squirrel,
                new Uri("pack://application:,,,/Resources/Assets/Images/Themes/Hedge/squirle.gif", UriKind.Absolute));
            AnimationBehavior.SetRepeatBehavior(squirrel, RepeatBehavior.Forever);
            Canvas.SetLeft(squirrel, 3);
            Canvas.SetTop(squirrel, 335);
            AnimationCanvas.Children.Add(squirrel);
            _animatedElement = squirrel; 

            var tcs = new TaskCompletionSource<bool>();

            var anim = new DoubleAnimation
            {
                From = 50,
                To = 1000,
                Duration = new Duration(TimeSpan.FromSeconds(6))
            };

            _storyboard = new Storyboard();
            Storyboard.SetTarget(anim, squirrel);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Canvas.LeftProperty));
            _storyboard.Children.Add(anim);

            _storyboard.Completed += (_, __) => tcs.TrySetResult(true);
            
            _storyboard.Begin(this, true);

            using (cancellationToken.Register(() =>
                   {
                       _storyboard?.Stop(this); 
                       tcs.TrySetResult(false);
                   }))
            {
                await tcs.Task;
            }

            AnimationCanvas.Children.Remove(squirrel);
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