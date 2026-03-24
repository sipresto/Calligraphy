using System.Collections.ObjectModel;
using Calligraphy.Application;
using Calligraphy.Domain;
using Calligraphy.Domain.Configuration;
using Calligraphy.Domain.Sessions;
using Calligraphy.Domain.Utility;
using Calligraphy.Presentation.Models;

namespace Calligraphy.Presentation.ViewModels;

public class
    LetterStringGameViewModel : GameViewModelBase<LetterStringGameService, WordGameSession, LetterStringGameSettings>
{
    private string _gameId;

    private const int MaxLetterWidth = 200;
    private const int MinLetterWidth = 60;
    private const int CanvasHeightConst = 200;
    private const int LetterGap = 16;
    private const int AvailableWidth = 1160;
    private const double BridgePointSpacing = 8;
    private const double ScreenWidth = 1200;
    private const double ScreenHeight = 800;

    public LetterStringGameViewModel(LetterStringGameService service, MainViewModel mainViewModel,
        GameSettings settings)
        : base(service, mainViewModel, settings)
    {
    }

    public ObservableCollection<LetterStringItem> Letters { get; private set; }

    public List<StrokePoint> AllTemplatePoints { get; private set; }
    
    public double LineThickness { get; private set; }

    public void Initialize(string gameId)
    {
        _gameId = gameId;
        LoadBestScore(_gameId);
        Settings = AllSettings.LetterStringGames[gameId];
        BuildLetters();
        OnPropertyChanged(nameof(Letters));
        OnPropertyChanged(nameof(AllTemplatePoints));
        Service.StartSession(_gameId, Settings.ToleranceDistance, Settings.RequiredAccuracy);
    }

    protected override void RestartGame()
    {
        Service.StartSession(_gameId, Settings.ToleranceDistance, Settings.RequiredAccuracy);
        LoadBestScore(_gameId);
        ResetGameState();
    }

    private void BuildLetters()
    {
        var items = new List<LetterStringItem>();
        var allPoints = new List<StrokePoint>();

        int count = Settings.LetterString.Length;
        double letterWidth = Math.Max(MinLetterWidth,
            Math.Min(MaxLetterWidth, (AvailableWidth - LetterGap * (count - 1)) / (double)count));

        double prevInkMaxX = 0;
        bool isFirst = true;
        LineThickness = Settings.ToleranceDistance * 2;

        for (int i = 0; i < count; i++)
        {
            var template = TraceFactory.GetTraceTemplateByLetter(Settings.LetterString[i]);
            var localPoints = template.GetTemplatePoints(letterWidth, CanvasHeightConst);

            double localInkMinX = localPoints.Min(p => p.X);
            double localInkMaxX = localPoints.Max(p => p.X);

            double offsetX = isFirst
                ? -localInkMinX
                : prevInkMaxX + LetterGap - localInkMinX;

            var offsetPoints = localPoints
                .Select(p => new StrokePoint(p.X + offsetX, p.Y, p.Pressure))
                .ToList();

            double inkMinX = localInkMinX + offsetX;
            double inkMaxX = localInkMaxX + offsetX;

            if (allPoints.Count > 0 && offsetPoints.Count > 0)
                InsertBridge(allPoints, allPoints[^1], offsetPoints[0]);

            allPoints.AddRange(offsetPoints);

            items.Add(new LetterStringItem(
                template.Name,
                offsetPoints,
                inkMinX,
                inkMaxX - inkMinX,
                LineThickness));

            prevInkMaxX = inkMaxX;
            isFirst = false;
        }

        double rawWidth = isFirst ? 0 : prevInkMaxX;
        double rawHeight = CanvasHeightConst;

        double shiftX = (ScreenWidth - rawWidth) / 2;
        double shiftY = (ScreenHeight - rawHeight) / 2;

        AllTemplatePoints = allPoints
            .Select(p => new StrokePoint(p.X + shiftX, p.Y + shiftY, p.Pressure))
            .ToList();

        var centeredItems = new List<LetterStringItem>(items.Count);
        foreach (var item in items)
        {
            var centeredPoints = item.TemplatePoints
                .Select(p => new StrokePoint(p.X + shiftX, p.Y + shiftY, p.Pressure))
                .ToList();

            centeredItems.Add(
                item with { TemplatePoints = centeredPoints, CanvasOffsetX = item.CanvasOffsetX + shiftX });
        }

        Letters = new ObservableCollection<LetterStringItem>(centeredItems);
    }

    private static void InsertBridge(List<StrokePoint> points, StrokePoint from, StrokePoint to)
    {
        double dx = to.X - from.X;
        double dy = to.Y - from.Y;
        double dist = Math.Sqrt(dx * dx + dy * dy);

        if (dist <= BridgePointSpacing)
            return;

        int steps = (int)Math.Ceiling(dist / BridgePointSpacing);
        double stepX = dx / steps;
        double stepY = dy / steps;

        for (int s = 1; s < steps; s++)
            points.Add(new StrokePoint(from.X + stepX * s, from.Y + stepY * s));
    }

    public void AddLetter(LetterStringItem item, List<StrokePointDto> userPoints)
    {
        var domainStroke = userPoints
            .Select(p => new StrokePoint(p.X, p.Y, p.Pressure, p.Timestamp))
            .ToList();

        Service.AddLetter(item.Name, item.TemplatePoints, domainStroke);
    }
}