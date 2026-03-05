using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Domain;
using Calligraphy.Presentation.ViewModels;

//TODO: make sure mouse doesn't work
namespace Calligraphy.Presentation.Views;

public partial class ShapeDrawView : UserControl
{
    public ShapeDrawView()
    {
        InitializeComponent();

        Loaded += OnLoaded;
    }

    private ShapeDrawViewModel ViewModel =>
        DataContext as ShapeDrawViewModel;

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel == null)
            return;

        ResultPopup.DataContext = DataContext;

        ViewModel?.Initialize("Diamond");

        ViewModel?.Restarted += OnReset;
        ViewModel?.Check += OnCheck;

        DrawTemplate();
    }

    private void OnReset()
    {
        InkCanvas.SetDrawingEnabled(true);
        InkCanvas.Clear();
        ResultPopup.ResetStars();

        ViewModel?.Initialize("Diamond");
    }

    private async void OnCheck()
    {
        var points = InkCanvas.EndDrawing();
        ViewModel.FinishGame(points, new StarThresholds(40, 60, 85));
        if (ViewModel?.GameResult != null)
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