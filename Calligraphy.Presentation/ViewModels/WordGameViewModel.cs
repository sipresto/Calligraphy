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
    private const int LetterSpacing = 74;
    
    public WordGameViewModel(WordGameService service, MainViewModel mainViewModel, GameSettings settings) : base(service, mainViewModel, settings)
    {
    }
    
    public ObservableCollection<LetterItem> Letters { get; set; }
    
    public string ImageSource => Settings.ImageSource;
    
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
            int currentX = word.X;
            int currentY = word.Y;
            
            foreach (var letter in word.Word)
            {
                var templatePoints = TraceFactory.GetTraceTemplateByLetter(letter).GetTemplatePoints();
                
                letters.Add(new LetterItem(templatePoints, currentX, currentY));
                
                currentX += LetterSpacing;
            }
        }
        
        return new ObservableCollection<LetterItem>(letters);
    }
}