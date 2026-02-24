using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Calligraphy.Presentation.Views.Controls;

public partial class GameResultPopup : UserControl
{
    private AnimatedStar[] _stars;
    
    public GameResultPopup()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _stars = [Star1, Star2, Star3];
    }

    public async Task AnimateStars(int starCount)
    {
        await Task.Delay(1000);

        for (int i = 0; i < starCount && i < _stars.Length; i++)
        {
            _stars[i].PlayFillAnimation();
            await Task.Delay(600);
        }
    }

    public void ResetStars()
    {
        foreach (var star in _stars)
        {
            var storyboard = (Storyboard)star.Resources["FillStarStoryboard"];
            storyboard?.Stop();

            if (star.FindName("GoldStarScale") is not ScaleTransform scaleTransform) continue;
            scaleTransform.ScaleX = 0;
            scaleTransform.ScaleY = 0;
        }
    }
}