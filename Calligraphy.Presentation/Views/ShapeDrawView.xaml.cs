using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Domain;
using Calligraphy.Presentation.Models;
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
        
        ViewModel?.Reset += OnReset;
        ViewModel?.Check += OnCheck;

        DrawTemplate();

        InkCanvas.StrokeCompleted += InkCanvas_StrokeCompleted;
    }

    private void OnReset()
    {
        InkCanvas.SetDrawingEnabled(true);
        InkCanvas.Clear();
    }

    private void OnCheck()
    {
        InkCanvas.SetDrawingEnabled(false);

        var result = ViewModel.CheckGame();
        MessageBox.Show(result.Message);
    }

    private void InkCanvas_StrokeCompleted(List<StrokePointDto> dtoStroke)
    {
        if (dtoStroke == null || dtoStroke.Count == 0)
            return;

        var domainStroke = dtoStroke
            .Select(p => new StrokePoint(p.X, p.Y))
            .ToList();

        ViewModel.AddStroke(domainStroke);
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
