using System.Windows;
using System.Windows.Controls;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class LetterStringGameView : UserControl
{
    public LetterStringGameView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
 
    private LetterStringGameViewModel ViewModel => DataContext as LetterStringGameViewModel;
 
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel == null)
            return;
 
        ResultPopup.DataContext = DataContext;
        PausePopup.DataContext = DataContext;
 
        ViewModel.Restarted += OnRestart;
        InkCanvas.StylusUp += OnStylusUp;
    }
 
    private void OnRestart()
    {
        InkCanvas.Clear(true);
        ResultPopup.ResetStars();
    }
    
    private void OnStylusUp()
    {
        if (ViewModel.SegmentCountCompleted())
            OnDrawingEnded();
    }
    
    private async void OnDrawingEnded()
    {
        var allStrokes = InkCanvas.EndDrawing();
        
        var allPoints = allStrokes
            .SelectMany(stroke => stroke)
            .ToList();
 
        foreach (var letterItem in ViewModel.Letters)
        {
            var letterPoints = allPoints
                .Where(p => p.X >= letterItem.CanvasOffsetX - (letterItem.LineThickness/2) &&
                            p.X < letterItem.CanvasOffsetX + letterItem.LetterWidth + (letterItem.LineThickness/2))
                .ToList();
 
            ViewModel.AddLetter(letterItem, letterPoints);
        }
 
        ViewModel.FinishGame([]);
 
        if (ViewModel.GameResult != null)
        {
            await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
        }
    }
}