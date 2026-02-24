using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Calligraphy.Presentation.Views.Controls;

public partial class AnimatedStar : UserControl
{
    public AnimatedStar()
    {
        InitializeComponent();
    }

    public void PlayFillAnimation()
    {
        var storyboard = (Storyboard)Resources["FillStarStoryboard"];
        storyboard?.Begin();
    }
}