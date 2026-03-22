using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
using Calligraphy.Presentation.ViewModels;
using Calligraphy.Presentation.Views.Controls;

namespace Calligraphy.Presentation.Views;

public partial class WordGameView : UserControl
{
    public WordGameView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    
    private WordGameViewModel ViewModel => DataContext as WordGameViewModel;

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel == null)
            return;

        ResultPopup.DataContext = DataContext;
        PausePopup.DataContext = DataContext;
        
        ViewModel.Check += OnCheck;
        ViewModel.Restarted += OnRestart;
    }
    
    private void OnRestart()
    {
        foreach (var item in LettersItemsControl.Items)
        {
            var container = LettersItemsControl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
            if (container == null) continue;

            var inkControl = FindVisualChild<InkCanvasControl>(container);
            if (inkControl == null) continue;

            inkControl.Clear(true);
        }

        ResultPopup.ResetStars();
    }
    
    private async void OnCheck()
    {
        ViewModel.IsClickable = false;
        
        foreach (var item in LettersItemsControl.Items)
        {
            if (item is not LetterItem letterItem) continue;
            
            var container = LettersItemsControl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
            if (container == null) continue;

            var inkControl = FindVisualChild<InkCanvasControl>(container);
            if (inkControl == null) continue;

            var localStrokes = inkControl.EndDrawing();

            var localStroke = localStrokes
                .SelectMany(stroke => stroke)
                .ToList();

            ViewModel.AddLetter(letterItem, localStroke);
        }
        
        ViewModel.FinishGame([]);

        if (ViewModel.GameResult != null)
        {
            await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
        }
    }
    
    private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
            if (child is T t) return t;
            T childOfChild = FindVisualChild<T>(child);
            if (childOfChild != null) return childOfChild;
        }
        return null;
    }
}