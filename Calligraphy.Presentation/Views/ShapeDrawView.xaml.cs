using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Application;
using Calligraphy.Application.Recognition;
using Calligraphy.Presentation.ViewModels;

//TODO: make sure mouse doesn't work
namespace Calligraphy.Presentation.Views;

    public partial class ShapeDrawView : UserControl
    {
        private ShapeDrawViewModel ViewModel => 
            DataContext as ShapeDrawViewModel;
        
        private ShapeRecognitionService _recognizer;
        private List<PointR> _points = new();
        private string _currentShape = "Triangle";

        public ShapeDrawView()
        {
            InitializeComponent();

            InitializeRecognizer();
            StartLevel();
        }
        
        private void InitializeRecognizer()
        {
            _recognizer = new ShapeRecognitionService();
        }
        

        private void StartLevel()
        {
            DrawTemplate();
        }


        private void DrawTemplate()
        {
            TemplateCanvas.Children.Clear();

            var poly = new Polyline
            {
                Stroke = Brushes.Gray,
                StrokeThickness = 3
            };

            foreach (var stroke in GetCurrentShape())
            {
                foreach (var p in stroke)
                    poly.Points.Add(new Point(p.X, p.Y));
            }

            TemplateCanvas.Children.Add(poly);
        }

        private List<List<PointR>> GetCurrentShape()
        {
            return _currentShape switch
            {
                "Triangle" => CreateTriangle(),
                "Circle" => CreateCircle(),
                _ => CreateSquare(),
            };
        }
        
        

        private List<List<PointR>> CreateSquare()
        {
            return new()
            {
                new()
                {
                    new PointR(100,100,0),
                    new PointR(200,100,0),
                    new PointR(200,200,0),
                    new PointR(100,200,0),
                    new PointR(100,100,0)
                }
            };
        }

        private List<List<PointR>> CreateTriangle()
        {
            return new()
            {
                new()
                {
                    new PointR(150,100,0),
                    new PointR(250,200,0),
                    new PointR(50,200,0),
                    new PointR(150,100,0)
                }
            };
        }

        private List<List<PointR>> CreateCircle()
        {
            var stroke = new List<PointR>();
            int radius = 75;
            int centerX = 150;
            int centerY = 150;

            for (int i = 0; i <= 360; i += 10)
            {
                double angle = i * Math.PI / 180;
                stroke.Add(new PointR(
                    centerX + radius * Math.Cos(angle),
                    centerY + radius * Math.Sin(angle),
                    0));
            }

            return new() { stroke };
        }
    }
