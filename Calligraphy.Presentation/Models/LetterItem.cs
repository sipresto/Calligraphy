using Calligraphy.Domain;

namespace Calligraphy.Presentation.Models;

public record LetterItem(
    string Name,
    List<StrokePoint> LetterPoints,
    int X,
    int Y,
    int Size,
    double LineThickness);