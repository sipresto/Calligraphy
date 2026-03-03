using Calligraphy.Domain;

namespace Calligraphy.Domain;

public interface IGameSession
{
    void AddStroke(List<StrokePoint> stroke);
    List<StrokePoint> GetTotalStroke();
    int CalculateScore();
}