namespace Calligraphy.Domain.TraceTemplates.Letters;

public class ConnectorLowercaseT : Letter
{
    public ConnectorLowercaseT()
    {
        IsTall = true;
    }
    
    public override string Name { get; } = "t";
    
    public override List<StrokePoint> GetTemplatePoints() 
        => ScaleAndCenter(GenerateRawPoints());
    
    public override List<StrokePoint> GetTemplatePoints(double width, double height) 
        => ScaleToSize(GenerateRawPoints(), width, height);

    private List<StrokePoint> GenerateRawPoints()
    {
        var rawPoints = new List<StrokePoint>();
        var newPoints = new List<StrokePoint>();
        int pointsPerCurve = 50;

        double cx = 129.894180;
        double cy = 26.497987;

        AddRelativeBezier(newPoints, ref cx, ref cy, -4.67948, 20.4119, -8.83178, 41.018, -13.7123, 61.3833, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.59167, 2.46891, -0.7979, 4.07512, -1.30767, 6.35, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.50641, 2.25988, -1.59437, 6.4942, -1.85453, 8.81944, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.12398, 1.10814, -0.51325, 4.0197, -0.72461, 4.93889, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.3751, 1.63128, -0.77613, 3.41971, -1.29406, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -2.00174, 7.23474, -3.28286, 15.5216, -5.01266, 22.9306, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.31287, 1.34007, -0.47795, 2.25874, -0.70039, 3.52778, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.50434, 2.87745, -1.51146, 4.80414, -2.63168, 6.14693, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.57597, 1.88909, -3.88261, 3.42211, -5.34512, 4.67425, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.95383, 1.67278, -5.50699, 3.83595, -8.36888, 5.24757, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -3.69898, 1.8245, -8.34595, 3.44002, -11.2592, 5.09792, pointsPerCurve);

        newPoints.Reverse();
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 105.145430;
        cy = 140.881370;

        AddRelativeBezier(newPoints, ref cx, ref cy, -0.57173, 3.1735, -1.83473, 8.72744, -2.54012, 13.1174, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.48067, 2.99137, -1.36467, 6.62355, -1.8891, 9.525, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.29606, 1.638, -0.5393, 2.8564, -0.893648, 4.58611, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -1.14441, 5.58619, -2.98083, 11.2513, -3.86641, 16.9333, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.334465, 2.14599, -0.3382, 3.52329, -0.534603, 5.64445, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, -0.100769, 1.08831, -0.241577, 1.81828, -0.218592, 2.82222, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.03134, 1.36908, 0.151865, 2.28983, 0.400417, 3.88056, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.31907, 2.04204, 0.36925, 3.02139, 1.05126, 5.29167, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 0.716386, 2.38473, 1.6767, 3.86427, 3.38678, 5.6115, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 1.41398, 1.4447, 2.52009, 2.16373, 4.52595, 2.7177, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.04673, 0.56526, 3.05413, 0.67292, 4.93889, 0.93858, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 4.18284, 0.58954, 8.80304, -0.53636, 12.7, -1.97241, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 3.44798, -1.27061, 6.84164, -3.20576, 9.87778, -5.05378, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 2.1548, -1.31155, 2.8886, -1.93274, 4.58612, -3.29993, pointsPerCurve);

        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 93.173877;
        cy = 107.136110;

        AddRelativeBezier(newPoints, ref cx, ref cy, 4.48178, -2.21582, 13.9124, -2.943, 19.4028, -3.68097, pointsPerCurve);
        AddRelativeBezier(newPoints, ref cx, ref cy, 12.5399, -1.68551, 26.2328, -4.51594, 39.1583, -5.84403, pointsPerCurve);
        
        rawPoints.AddRange(newPoints);
        newPoints = [];

        cx = 136.670154;
        cy = 201.62374;

        AddRelativeBezier(newPoints, ref cx, ref cy, 0, 0.117, 0, 0.235, 0, 0.352778, pointsPerCurve);

        rawPoints.AddRange(newPoints);

        return ScaleAndCenter(rawPoints);
    }
}