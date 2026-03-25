using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Calligraphy.Domain;
using XamlAnimatedGif;

namespace Calligraphy.Presentation.Views.themes
{
    public partial class CastleThemeView : UserControl, IThemeView
    {
        // ── Asset paths ──────────────────────────────────────────────────────────
        private const string Base = "/Resources/Assets/Images/Themes/Castle/Tiles/";
        private const string WallLeft = Base + "WallLeftThing.png";
        private const string Wall = Base + "Wall.png";
        private const string WallRight = Base + "WallRightThing.png";
        private const string WallFillLeft = Base + "WallFillLeftThing.png";
        private const string WallFill1 = Base + "WallFill1.png";
        private const string WallFill2 = Base + "WallFill2.png";
        private const string WallFillRight = Base + "WallFillRightThing.png";

        // ── Layout constants ─────────────────────────────────────────────────────
        private const int TileSize = 60;

        // Merlon caps
        private const int MerlonStartX = 95;
        private const int MerlonStep = 100;
        private const int MerlonTop = 400;
        private const int MerlonCols = 8;

        // Body rows
        private const int BodyStartX = 95;
        private const int BodyStep = 50;
        private const int BodyTopFirst = 450;
        private const int BodyRowStep = 50;
        private const int BodyRows = 7;
        private const int BodyCols = 17;

        public CastleThemeView()
        {
            InitializeComponent();
            Loaded += (_, __) => BuildTerrain();
        }

        private void BuildTerrain()
        {
            BuildMerlonRow();

            for (int row = 0; row < BodyRows; row++)
            {
                int top = BodyTopFirst + row * BodyRowStep;
                bool startsWithFill2 = (row % 2 == 0);
                BuildBodyRow(top, startsWithFill2);
            }
        }

        // Merlon caps: WallLeftThing | N×Wall (100px apart) | WallRightThing
        private void BuildMerlonRow()
        {
            TerrainCanvas.Children.Add(MakeImage(WallLeft, MerlonStartX, MerlonTop));

            for (int col = 0; col < MerlonCols; col++)
            {
                int x = MerlonStartX + MerlonStep + col * MerlonStep;
                TerrainCanvas.Children.Add(MakeImage(Wall, x, MerlonTop));
            }

            int rightX = MerlonStartX + MerlonStep + MerlonCols * MerlonStep;
            TerrainCanvas.Children.Add(MakeImage(WallRight, rightX, MerlonTop));
        }

        // Body row: WallFillLeftThing | N alternating fills (50px apart) | WallFillRightThing
        private void BuildBodyRow(int top, bool startsWithFill2)
        {
            TerrainCanvas.Children.Add(MakeImage(WallFillLeft, BodyStartX, top));

            for (int col = 0; col < BodyCols; col++)
            {
                int x = BodyStartX + BodyStep + col * BodyStep;
                string src = ((col % 2 == 0) == startsWithFill2) ? WallFill2 : WallFill1;
                TerrainCanvas.Children.Add(MakeImage(src, x, top));
            }

            int rightX = BodyStartX + BodyStep + BodyCols * BodyStep;
            TerrainCanvas.Children.Add(MakeImage(WallFillRight, rightX, top));
        }

        private Image MakeImage(string packUri, int left, int top)
        {
            var img = new Image
            {
                Source = new BitmapImage(new Uri(packUri, UriKind.Relative)),
                Width = TileSize,
                Height = TileSize,
                Stretch = System.Windows.Media.Stretch.Fill,
            };
            Canvas.SetLeft(img, left);
            Canvas.SetTop(img, top);
            return img;
        }

        public async Task PlayVictoryAnimation()
        {
            var knight = new Image
            {
                Width = 140,
                Height = 140,
                Stretch = Stretch.Fill
            };

            var uri = new Uri("pack://application:,,,/Resources/Assets/Images/Themes/Castle/knight.gif", UriKind.Absolute);
            AnimationBehavior.SetSourceUri(knight, uri);
            AnimationBehavior.SetRepeatBehavior(knight, RepeatBehavior.Forever);

            Canvas.SetLeft(knight, 50);
            Canvas.SetTop(knight, 329);
            AnimationCanvas.Children.Add(knight);

            var tcs = new TaskCompletionSource<bool>();

            var anim = new DoubleAnimation
            {
                From = 50,
                To = 1000,
                Duration = new Duration(TimeSpan.FromSeconds(10))
            };

            anim.Completed += (_, __) =>
            {
                AnimationCanvas.Children.Remove(knight);
                tcs.SetResult(true);
            };

            knight.BeginAnimation(Canvas.LeftProperty, anim);
            await tcs.Task;
        }

        public Task PlayVictoryAnimation(List<StrokePoint> templatePoints)
        {
            return PlayVictoryAnimation(); 
        }
    }
}