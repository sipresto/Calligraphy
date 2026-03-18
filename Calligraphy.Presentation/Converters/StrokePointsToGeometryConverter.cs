using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Calligraphy.Domain;

namespace Calligraphy.Presentation.Converters;

public class StrokePointsToGeometryConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not List<StrokePoint> points || !points.Any())
            return Geometry.Empty;

        var geometry = new PathGeometry();
        var figure = new PathFigure { StartPoint = new Point(points[0].X, points[0].Y), IsClosed = false };
        var segment = new PolyLineSegment { IsStroked = true };

        for (int i = 1; i < points.Count; i++)
        {
            if (Math.Sqrt(Math.Pow(points[i].X - points[i-1].X, 2) + Math.Pow(points[i].Y - points[i-1].Y, 2)) > 40)
            {
                figure.Segments.Add(segment);
                geometry.Figures.Add(figure);
                figure = new PathFigure { StartPoint = new Point(points[i].X, points[i].Y), IsClosed = false };
                segment = new PolyLineSegment { IsStroked = true };
            }
            else
            {
                segment.Points.Add(new Point(points[i].X, points[i].Y));
            }
        }

        figure.Segments.Add(segment);
        geometry.Figures.Add(figure);
        return geometry;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}