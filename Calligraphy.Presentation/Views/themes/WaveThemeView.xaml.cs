using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Calligraphy.Presentation.Views.themes
{
    public partial class WaveThemeView : UserControl
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
    }
}