namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseB : Letter
{
    public ConnectorLowercaseB()
    {
        IsTall = true;
    }
    
    public override string Name { get; } = "b";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 82.938215;
        double cy = 55.649557;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0.3498, -2.6087, 2.17105, -10.4196, 3.32328, -14.5254, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.35718, -8.39961, 4.74677, -15.8654, 9.95514, -23.0281, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.05731, -2.82928, 4.52682, -5.35853, 7.53501, -7.13479, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.2636, -0.746118, 2.45992, -1.47234, 3.88047, -1.94797, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.89213, -0.633524, 3.34227, -0.675971, 5.29155, -0.931625, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.0498, -0.399991, 4.50793, 0.092591, 7.0554, 0.747653, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.54339, 0.396877, 3.31912, 1.43524, 4.57076, 2.60104, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.60214, 1.49226, 2.88239, 3.65328, 3.59739, 5.60285, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.54972, 1.49892, 0.87338, 2.70791, 1.26165, 4.25134, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.40401, 1.60604, 0.50914, 3.33715, 0.69981, 4.9599, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.0988, 0.840569, 0.0993, 1.59425, 0.10072, 2.47995, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.002, 1.12777, 0.0578, 1.95128, -0.0599, 3.18851, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.27653, 2.90624, -0.7567, 6.03911, -1.31907, 8.85697, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.61166, 3.06482, -1.58559, 5.36517, -2.74187, 8.50269, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.41119, 3.82919, -3.54187, 7.38638, -5.68625, 10.9826, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.36003, 5.63501, -7.62222, 11.2767, -11.7416, 16.2968, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.21219, 1.47725, -2.2247, 2.75072, -3.55656, 4.25134, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.40177, 2.70611, -5.18471, 5.97, -7.70241, 8.50269, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.08416, 1.09062, -2.10566, 2.08569, -3.07422, 3.18851, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.665847, 0.758162, -1.19107, 1.40373, -1.87845, 2.12567, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.73921, 1.82664, -3.8382, 3.80073, -5.61655, 5.66846, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.11622, 1.17234, -2.03506, 2.37562, -3.19399, 3.5376, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.77164, 1.77629, -2.85958, 2.25618, -4.57949, 3.91647, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.91409, 1.84773, -3.15645, 3.1742, -4.94014, 4.94705, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.77321, 1.76242, -4.59007, 4.44704, -6.34469, 6.08152, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.46986, 1.36922, -2.24287, 2.50354, -3.53804, 3.83692, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.32779, 2.39647, -7.76277, 7.72824, -10.3259, 9.78887, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.83798, 1.47766, -3.32526, 2.2147, -4.83807, 3.31944, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 83.129832;
        cy = 55.221769;

        AddRelativeBezier(newPoints, ref cx, ref cy, -3.13505, 13.1863, -7.24664, 29.5634, -9.6253, 43.1542, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.176525, 1.00859, -0.400547, 1.82911, -0.682939, 2.8378, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.373536, 1.33423, -0.646648, 2.49238, -0.781489, 3.90196, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.112339, 1.1743, -0.359496, 2.41571, -0.642115, 3.54724, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.339722, 1.36014, -0.629111, 2.04614, -1.0172, 3.54725, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.783038, 3.02876, -1.48938, 5.38153, -1.90183, 8.86811, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.46079, 3.89515, -2.0982, 7.87031, -2.88013, 11.7059, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.70493, 8.36322, -3.49511, 16.8157, -5.32337, 25.1854, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.36973, 6.27063, -2.87705, 12.8241, -3.63003, 19.1551, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.234304, 1.96995, -0.574734, 3.03502, -0.302417, 5.32087, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.382125, 3.20763, 0.533081, 6.14945, 1.68083, 9.22282, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.0201, 2.73158, 2.15091, 4.70646, 4.17033, 6.73456, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.10275, 2.11177, 4.58193, 3.69712, 7.40296, 4.76686, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.45098, 0.92947, 5.68868, 1.4245, 8.11367, 1.59164, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.24868, 0.086, 1.9325, 0.0317, 3.17491, 0.0317, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.42866, -8e-05, 2.20292, 0.0266, 3.52768, -0.15053, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.54458, -0.47372, 6.96073, -1.12592, 10.2303, -2.39959, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.25319, -1.26731, 7.50658, -3.57383, 10.2303, -5.58142, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.67514, -1.23474, 3.40066, -2.72383, 4.93358, -4.28517, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.85847, -1.89293, 3.57532, -3.9028, 5.1644, -6.02893, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.79134, -1.05881, 1.50472, -2.04942, 2.22985, -3.19252, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.66228, -4.19691, 5.09191, -8.73973, 6.87107, -13.4795, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.30065, -3.46499, 2.34924, -6.4865, 3.36546, -9.93228, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.50012, -5.0865, 2.37972, -10.7455, 3.47133, -15.9626, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.81606, -3.90014, 1.83934, -7.81975, 2.68822, -11.7059, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.50397, -2.30707, 1.13737, -5.24486, 1.61904, -7.4492, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.7825, -3.58105, 1.50922, -5.33185, 1.75894, -8.51337, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 136.809410;
        cy = 115.900040;

        AddRelativeBezier(newPoints, ref cx, ref cy, 1.13496, 1.49504, 2.59938, 4.01868, 3.71074, 5.46546, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.48145, 4.53218, 4.3535, 5.86025, 8.99321, 8.50679, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}