using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public abstract class GameViewModelBase : ViewModelBase
{
    public virtual bool HasNextLevel { get; init; } = true;
    public bool IsGameResultVisible => GameResult != null;

    public GameResult GameResult
    {
        get;
        protected set
        {
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsGameResultVisible));
        }
    }

    
    public string MascotMessage
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    } 
    
    public bool IsMascotVisible
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    
    protected int CalculateStars(int score, int oneStar, int twoStars, int threeStars)
    {
        if (score < oneStar) return 0;
        if (score < twoStars) return 1;
        if (score < threeStars) return 2;
        return 3;
    }

    protected string GetStarMessage(int stars) 
    {
        return stars switch
        {
            3 => "Geweldig! Je hebt het heel goed gedaan!",
            2 => "Goed gedaan! Het was al bijna perfect!",
            1 => "Niet slecht! Probeer het nog eens en kijk of je meer punten kunt halen!",
            0 => "Blijf oefenen! Je kunt het beter doen als je het nog eens probeert!",
            _ => ""
        };

    }
    
    protected abstract void OnGameFinished();
    
    protected abstract void RestartGame();

    public abstract void ProcessFinishedDrawing(List<List<StrokePointDto>> strokes);
}