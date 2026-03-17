using System.Collections.ObjectModel;
using Calligraphy.Application;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;

namespace Calligraphy.Presentation.ViewModels;

public class WordGameViewModel : GameViewModelBase<WordGameService, WordGameSession, WordGameSettings>
{
    private string _gameId;
    
    public WordGameViewModel(WordGameService service, MainViewModel mainViewModel, GameSettings settings) : base(service, mainViewModel, settings)
    {
    }
    
    public void Initialize(string gameId)
    {
        _gameId = gameId;
        LoadBestScore(_gameId);
        Settings = AllSettings.WordGames[gameId];
        Service.StartSession(_gameId, Settings.Words.Select(w => w.Word).ToList());
    }

    protected override void RestartGame()
    {
        Service.StartSession(_gameId, Settings.Words.Select(w => w.Word).ToList());
        LoadBestScore(_gameId);
        ResetGameState();
    }
}