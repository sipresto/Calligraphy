using System.Collections.ObjectModel;
using System.Windows.Input;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;
using Calligraphy.Presentation.Models;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class WordGameViewModel : GameViewModelBase<WordGameService, WordGameSession, WordGameSettings>
{
    private string _gameId;
    private const int CanvasSize = 110;
    
    public WordGameViewModel(WordGameService service, MainViewModel mainViewModel, GameSettings settings) : base(service, mainViewModel, settings)
    {
        CheckCommand = new RelayCommand(() => Check?.Invoke());
    }
    
    public ICommand CheckCommand { get; }
    public event Action Check;
    
    public ObservableCollection<LetterItem> Letters { get; set; }
    
    public string ImageSource => Settings.ImageSource;
    
    public double LineThickness => Settings.ToleranceDistance * 2;
    
    public bool IsClickable
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
    
    public void Initialize(string gameId)
    {
        _gameId = gameId;
        LoadBestScore(_gameId);
        Settings = AllSettings.WordGames[gameId];
        Letters = BuildLetters();
        Service.StartSession(_gameId, Settings.ToleranceDistance, Settings.RequiredAccuracy);
        IsClickable = true;
    }

    protected override void RestartGame()
    {
        Service.StartSession(_gameId, Settings.ToleranceDistance, Settings.RequiredAccuracy);        
        LoadBestScore(_gameId);
        ResetGameState();
        IsClickable = true;
    }

    private ObservableCollection<LetterItem> BuildLetters()
    {
        var letters = new List<LetterItem>();
        var thickness = Settings.ToleranceDistance * 2;
        
        foreach (var word in Settings.Words)
        {
            int currentX = word.X;
            int currentY = word.Y;
            
            foreach (var letter in word.Word)
            {
                var template = TraceFactory.GetTraceTemplateByLetter(letter);
                var templatePoints = template.GetTemplatePoints(CanvasSize, CanvasSize);
                
                letters.Add(new LetterItem(template.Name, templatePoints, currentX, currentY, CanvasSize, thickness));
                
                currentX += CanvasSize + 4;
            }
        }
        
        return new ObservableCollection<LetterItem>(letters);
    }

    public void AddLetter(LetterItem letterItem, List<StrokePointDto> userPoints)
    {
        var domainStroke = userPoints
            .Select(p => new StrokePoint(p.X, p.Y, p.Pressure, p.Timestamp))
            .ToList();
        
        Service.AddLetter(letterItem.Name, letterItem.LetterPoints, domainStroke);
    }
}