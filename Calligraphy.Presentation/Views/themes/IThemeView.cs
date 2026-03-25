using Calligraphy.Domain;

namespace Calligraphy.Presentation.Views.themes;

public interface IThemeView
{
    Task PlayVictoryAnimation(List<StrokePoint> templatePoints, CancellationToken cancellationToken = default);
    void PauseAnimation();
    void ResumeAnimation();
}