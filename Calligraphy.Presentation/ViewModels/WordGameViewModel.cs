using System.Collections.ObjectModel;
using Calligraphy.Application;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class WordGameViewModel : GameViewModelBase<WordGameService, WordGameSession, WordGameSettings>
{
    private string _gameId;
    
    public WordGameViewModel(WordGameService service, MainViewModel mainViewModel, GameSettings settings) : base(service, mainViewModel, settings)
    {
    }
    
    public ObservableCollection<LetterItem> Letters { get; set; }
    
    public void Initialize(string gameId)
    {
        _gameId = gameId;
        LoadBestScore(_gameId);
        Settings = AllSettings.WordGames[gameId];
        Letters = BuildLetters();
        Service.StartSession(_gameId, Settings.Words.Select(w => w.Word).ToList());
    }

    protected override void RestartGame()
    {
        Service.StartSession(_gameId, Settings.Words.Select(w => w.Word).ToList());
        LoadBestScore(_gameId);
        ResetGameState();
    }

    private ObservableCollection<LetterItem> BuildLetters()
    {
        var letters = new List<LetterItem>();
        
        foreach (var word in Settings.Words)
        {
            for (int i = 0; i < word.Word.Length; i++)
            {
                char letter = word.Word[i];
                
                letters.Add(new LetterItem(
                        TraceFactory.GetTraceTemplateByLetter(letter).GetTemplatePoints(),
                        i == 0 ? word.X : null,
                        i == 0 ? word.Y : null
                    ));
            }
        }
        
        return new ObservableCollection<LetterItem>(letters);
    }
}