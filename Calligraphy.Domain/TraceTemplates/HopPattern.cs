namespace Calligraphy.Domain.TraceTemplates;

public class HopPattern : TraceTemplate
{
    public override string Name => "HopPattern";

    private readonly int _loopCount;
    private readonly double _loopWidth;
    private readonly double _baselineY;
    private readonly double _topY;
    private readonly double _startX;
    private readonly int _pointsPerLoop;

    public HopPattern(double startX, double baselineY, double topY, double loopWidth, int loopCount, int pointsPerLoop = 50)
    {
        _startX = startX;
        _baselineY = baselineY;
        _topY = topY;
        _loopWidth = loopWidth;
        _loopCount = loopCount;
        _pointsPerLoop = pointsPerLoop;
    }

    public override List<StrokePoint> GetTemplatePoints()
    {
        var points = new List<StrokePoint>();
        double x = _startX;

        for (int i = 0; i < _loopCount; i++)
        {
            // upward arc
            var p0 = new StrokePoint(x, _baselineY);
            var p1 = new StrokePoint(x, _baselineY - 30);
            var p2 = new StrokePoint(x + _loopWidth * 0.2, _topY);
            var p3 = new StrokePoint(x + _loopWidth * 0.5, _topY);

            for (int j = 0; j < _pointsPerLoop / 2; j++)
            {
                double t = (double)j / (_pointsPerLoop / 2);
                points.Add(EvaluateBezier(p0, p1, p2, p3, t));
            }

            // downward arc
            p0 = new StrokePoint(x + _loopWidth * 0.5, _topY);
            p1 = new StrokePoint(x + _loopWidth * 0.8, _topY);
            p2 = new StrokePoint(x + _loopWidth, _baselineY - 30);
            p3 = new StrokePoint(x + _loopWidth, _baselineY);

            for (int j = 0; j < _pointsPerLoop / 2; j++)
            {
                double t = (double)j / (_pointsPerLoop / 2);
                points.Add(EvaluateBezier(p0, p1, p2, p3, t));
            }

            x += _loopWidth;
        }

        return points;
    }
}