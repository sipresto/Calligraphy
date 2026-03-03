using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public abstract class GameViewModelBase : ViewModelBase
{
    public virtual bool HasNextLevel { get; init; } = true;

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

    public bool IsGameResultVisible => GameResult != null;
    
    protected int CalculateStars(int score, int oneStar, int twoStars, int threeStars)
    {
        if (score < oneStar) return 0;
        if (score < twoStars) return 1;
        if (score < threeStars) return 2;
        return 3;
    }
    
    //protected abstract void OnGameFinished();
    
    protected abstract void RestartGame();
}