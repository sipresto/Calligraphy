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
        _stars = [Star1, Star2, Star3]; 
    }

    public async Task AnimateStars(int starCount)
    {
        ResetStars();
        await Task.Delay(400);

        for (int i = 0; i < starCount && i < _stars.Length; i++)
        {
            _stars[i].IsFilled = true;
            await Task.Delay(600);
        }
    }

    public void ResetStars()
    {
        if (_stars == null) return;

        foreach (var star in _stars)
        {
            star.IsFilled = false;
        }
    }
}