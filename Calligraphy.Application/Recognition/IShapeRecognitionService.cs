using Calligraphy.Domain;

namespace Calligraphy.Application.Recognition;

public interface IShapeRecognitionService
{
    RecognitionResult Recognize(List<List<StrokePoint>> strokes);
}