using Calligraphy.Domain;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public interface ITraceGameViewModel
{
    event Action DrawingStarted;
    event Action DrawingEnded;
    event Action Restarted;
    
    void FinishGame(List<List<StrokePointDto>> strokes);
    GameResult GameResult { get; }
    public List<StrokePoint> GetTemplatePoints();
    public double GetThickness();
    
    bool IsTimed { get; }
    bool EndOnLift { get; }
}