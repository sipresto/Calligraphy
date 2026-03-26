using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class ShapeDrawView : UserControl
{
    public ShapeDrawView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private ShapeDrawViewModel ViewModel => DataContext as ShapeDrawViewModel;

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel == null)
            return;

        ResultPopup.DataContext = DataContext;
        PausePopup.DataContext = DataContext;

        ViewModel.Restarted += OnReset;
        ViewModel.Check += OnCheck;
        DrawTemplate();
    }

    private void OnReset()
    {
        InkCanvas.Clear(true);
        ResultPopup.ResetStars();
    }

    private async void OnCheck()
    {
        ViewModel.IsClickable = false;
        var points = InkCanvas.EndDrawing();
        ViewModel.FinishGame(points);

        if (ViewModel.GameResult != null)
        {
            await ResultPopup.AnimateStars(ViewModel.GameResult.StarCount);
        }
    }

    private void DrawTemplate()
    {
        TemplateCanvas.Children.Clear();

        var shape = ViewModel.GetCurrentTemplateShape(
            TemplateCanvas.ActualWidth,
            TemplateCanvas.ActualHeight);

        foreach (var stroke in shape)
        {
            var polyline = new Polyline
            {
                Stroke = Brushes.LightGray,
                StrokeThickness = 3
            };

            foreach (var p in stroke)
            {
                polyline.Points.Add(new Point(p.X, p.Y));
            }

            TemplateCanvas.Children.Add(polyline);
        }
    }
}