using Calligraphy.Domain;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public interface ITraceGameViewModel
{
    event Action DrawingStarted;
    event Action DrawingEnded;
    event Action Restarted;
    event Action Paused;
    event Action Resumed;
    bool IsAnimationPlaying { get; set; }
    
    void FinishGame(List<List<StrokePointDto>> strokes);
    GameResult GameResult { get; }
    public bool SegmentCountCompleted(); 
    
    bool IsTimed { get; }
    bool EndOnLift { get; }
    
    List<StrokePoint> TemplatePoints { get; }
    double TemplateThickness { get; }
}