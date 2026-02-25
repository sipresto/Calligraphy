using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Calligraphy.Application.Recognition;

namespace Calligraphy.Presentation.Views;

    public partial class ShapeDrawView : UserControl
    {
        private NDollarRecognizer _recognizer;
        private List<PointR> _points = new();
        private List<List<PointR>> _strokes = new();
        private bool _isDrawing = false;
        private string _currentShape = "Square";

        public ShapeDrawView()
        {
            InitializeComponent();

            InitializeRecognizer();
            LoadTemplates();
            StartLevel();
        }


        private void InitializeRecognizer()
        {
            _recognizer = new NDollarRecognizer();
        }

        private void LoadTemplates()
        {
            AddTemplate("Square", CreateSquare());
            AddTemplate("Triangle", CreateTriangle());
            AddTemplate("Circle", CreateCircle());
        }

        private void AddTemplate(string name, List<List<PointR>> strokes)
        {
            var gesture = new Multistroke(name, "app", "default", strokes);
            _recognizer.AddGesture(gesture);
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
                    poly.Points.Add(new System.Windows.Point(p.X, p.Y));
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


        private void DrawCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDrawing = true;
            _points.Clear();
            _strokes.Clear();
            _strokes.Add(new List<PointR>());
        }

        private void DrawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDrawing) return;

            var pos = e.GetPosition(DrawCanvas);

            var point = new PointR(pos.X, pos.Y, Environment.TickCount);
            _points.Add(point);
            _strokes[0].Add(point);

            if (_points.Count > 1)
            {
                var line = new Line
                {
                    X1 = _points[^2].X,
                    Y1 = _points[^2].Y,
                    X2 = point.X,
                    Y2 = point.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 3
                };

                DrawCanvas.Children.Add(line);
            }
        }

        private void DrawCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDrawing = false;
        }


        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            DrawCanvas.Children.Clear();
            _points.Clear();
            _strokes.Clear();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (_points.Count == 0)
                return;

            var result = _recognizer.Recognize(_points, 1);

            double sizeRatio = GetSizeRatio();

            if (result.Name == _currentShape &&
                result.Score >= 0.90 &&
                sizeRatio > 0.8 && sizeRatio < 1.2)
            {
                MessageBox.Show("Correct! 🎉");
            }
            else
            {
                MessageBox.Show("Not accurate enough. Try again.");
            }
        }


        private double GetSizeRatio()
        {
            var template = GetBoundingBox(GetCurrentShape()[0]);
            var drawn = GetBoundingBox(_points);

            double templateSize = template.width * template.height;
            double drawnSize = drawn.width * drawn.height;

            return drawnSize / templateSize;
        }

        private (double width, double height) GetBoundingBox(List<PointR> points)
        {
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = double.MinValue;
            double maxY = double.MinValue;

            foreach (var p in points)
            {
                if (p.X < minX) minX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.X > maxX) maxX = p.X;
                if (p.Y > maxY) maxY = p.Y;
            }

            return (maxX - minX, maxY - minY);
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
