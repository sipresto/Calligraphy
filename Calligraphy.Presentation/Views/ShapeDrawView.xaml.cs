using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Presentation.ViewModels;

//TODO: make sure mouse doesn't work
namespace Calligraphy.Presentation.Views;

public partial class ShapeDrawView : UserControl
{
    private ShapeDrawViewModel ViewModel => 
        DataContext as ShapeDrawViewModel;
    
    public ShapeDrawView()
    {
        InitializeComponent();

        Loaded += OnLoaded;
    }
    
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel == null)
            return;
        
        ResultPopup.DataContext = DataContext;
        ViewModel?.Initialize("Diamond");
        ViewModel?.Reset += OnReset;
        ViewModel?.Check += OnCheck;

        DrawTemplate();
    }

    private void OnReset()
    {
        InkCanvas.SetDrawingEnabled(true);
        InkCanvas.Clear();
        MascotFeedback.Hide();
        ResultPopup.ResetStars();
    }

    private async void OnCheck()
    {
        var points = InkCanvas.EndDrawing();
        ViewModel.AddStrokes(points);
        ViewModel.CheckGame();
        if (ViewModel?.GameResult != null)
        {
            MascotFeedback.ShowFeedback(
                ViewModel.GameResult.StarCount
            );
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
