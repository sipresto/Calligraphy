
using Calligraphy.Domain;
using Calligraphy.Domain.Recognition;

namespace Calligraphy.Application
{
    public class ShapeDrawService
    {
        private readonly NDollarRecognizer _recognizer;

        public ShapeDrawService()
        {
            _recognizer = new NDollarRecognizer();
        }

        public void LoadTemplateForShape(string shapeName, double w, double h)
        {
            _recognizer.ClearGestures();
            AddTemplate(shapeName, w, h);
        }
        
        private void AddTemplate(string name, double w, double h)
        {
            var strokes = ShapeFactory.GetShape(name, w, h);

            var pointRs = ConvertToPointRStrokes(strokes);
            
            _recognizer.AddGesture(
                new Multistroke(name, "app", "default", pointRs));
        }

        public (bool success, double score) CheckShape(
            ShapeDrawSession session,
            double canvasWidth,
            double canvasHeight)
        {
            if (session.Strokes.Count == 0)
                return (false, 0);

            var flattenedPoints = ConvertToPointR(session.Strokes);

            var result = _recognizer.Recognize(flattenedPoints, session.Strokes.Count);

            var template = ShapeFactory.GetShape(
                session.ShapeName,
                canvasWidth,
                canvasHeight);

            var flattenedTemplate = ConvertToPointR(template);
            
            double sizeRatio = CalculateSizeRatio(flattenedTemplate, flattenedPoints);

            bool success =
                result.Score >= 0.90 &&
                result.Name.Equals(session.ShapeName, StringComparison.OrdinalIgnoreCase) &&
                sizeRatio > 0.8 &&
                sizeRatio < 1.2;
            return (success, result.Score);
        }
        
        private List<PointR> ConvertToPointR(IReadOnlyList<IReadOnlyList<StrokePoint>> strokes)
        {
            var result = new List<PointR>();

            foreach (var stroke in strokes)
            {
                foreach (var p in stroke)
                {
                    result.Add(new PointR(
                        p.X,
                        p.Y));
                }
            }

            return result;
        }
        
        private List<List<PointR>> ConvertToPointRStrokes(List<List<StrokePoint>> strokes)
        {
            var result = new List<List<PointR>>();

            foreach (var stroke in strokes)
            {
                var convertedStroke = new List<PointR>();

                foreach (var p in stroke)
                {
                    convertedStroke.Add(new PointR(
                        p.X,
                        p.Y));
                }

                result.Add(convertedStroke);
            }

            return result;
        }

        private double CalculateSizeRatio(
            List<PointR> template,
            List<PointR> drawn)
        {
            var t = GetBoundingBox(template.ToList());
            var d = GetBoundingBox(drawn);

            double templateArea = t.width * t.height;
            double drawnArea = d.width * d.height;

            if (templateArea == 0)
                return 0;

            return drawnArea / templateArea;
        }

        private (double width, double height) GetBoundingBox(List<PointR> points)
        {
            double minX = points.Min(p => p.X);
            double maxX = points.Max(p => p.X);
            double minY = points.Min(p => p.Y);
            double maxY = points.Max(p => p.Y);

            return (maxX - minX, maxY - minY);
        }
    }
}