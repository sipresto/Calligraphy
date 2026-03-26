using Calligraphy.Domain;

namespace Calligraphy.Presentation.Models;

public record LetterStringItem(
    string Name,
    List<StrokePoint> TemplatePoints,
    double CanvasOffsetX,
    double LetterWidth,
    double LineThickness);