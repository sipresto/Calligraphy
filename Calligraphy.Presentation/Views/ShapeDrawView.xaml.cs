using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Domain;
using Calligraphy.Domain.Recognition;
using Calligraphy.Presentation.Models;
using Calligraphy.Presentation.ViewModels;

//TODO: make sure mouse doesn't work
namespace Calligraphy.Presentation.Views;

    public partial class ShapeDrawView : UserControl
    {
        private ShapeDrawViewModel ViewModel => 
            DataContext as ShapeDrawViewModel;
        
        private List<PointR> _points = new();

        public ShapeDrawView()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }
        
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel == null)
                return;

            ViewModel.InitializeTemplates(
                TemplateCanvas.ActualWidth,
                TemplateCanvas.ActualHeight);

            DrawTemplate();

            InkCanvas.StrokeCompleted += InkCanvas_StrokeCompleted;
        }

        private void InkCanvas_StrokeCompleted(List<StrokePointDto> dtoStroke)
        {
            if (dtoStroke == null || dtoStroke.Count == 0)
                return;

            var domainStroke = dtoStroke
                .Select(p => new StrokePoint(p.X, p.Y))
                .ToList();

            ViewModel.Session.AddStroke(domainStroke);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Reset();

            InkCanvas.SetDrawingEnabled(true);
            InkCanvas.Clear();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Reset();

            var allStrokes = InkCanvas.EndDrawing();

            foreach (var dtoStroke in allStrokes)
            {
                var domainStroke = dtoStroke
                    .Select(p => new StrokePoint(p.X, p.Y))
                    .ToList();

                ViewModel.Session.AddStroke(domainStroke);
            }

            var result = ViewModel.Check(
                TemplateCanvas.ActualWidth,
                TemplateCanvas.ActualHeight);

            MessageBox.Show(result.Message);
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
