namespace Calligraphy.Presentation.Models;

public class TutorialInfo
{
    public string PointsExplanation { get; set; } = "";
    public string OneStar { get; set; } = "";
    public string TwoStars { get; set; } = "";
    public string ThreeStars { get; set; } = "";
    public bool ShowPressureInfo { get; set; } = true;
    public string TargetGameViewModelName { get; set; } = "";
    public string ImageSource { get; set; } = null;
}