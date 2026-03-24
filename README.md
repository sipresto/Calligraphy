# Cally

A **Windows desktop application** (WPF, .NET 10) that teaches children to write by guiding them through drawing exercises using a stylus or pen tablet. Players trace patterns, draw shapes, write letters, and spell words — all scored in real time with star-based feedback.

---

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting started](#getting-started)
- [Game Types](#game-types)
- [Technical Overview](#technical-overview)
- [Adding Content](#adding-content)

---

## Prerequisites

| Dependency | Version                        |
|---|--------------------------------|
| .NET SDK | **10.0**                       |
| Windows | required (WPF)                 |
| Stylus / pen tablet | required (mouse does not work) |

---

## Getting started

The app requires Windows, so does not run on macOS or Linux. The entry point of the app is Calligraphy.Presentation.

### 1. Clone the repository

```bash
git clone https://gitlab.com/kdg-ti/the-lab/teams-25-26/49_macrohard/calligraphy.git
```

### 2. Run the application

```bash
cd calligraphy
dotnet run --project Calligraphy.Presentation
```

---

## Game Types

**Schetsen (Sketching)**: Pattern tracing games, both with and without timer.

**Vormen (Shapes)**: Free-hand drawing of geometric shapes with accuracy scoring.

**Letters**: Tracing games to learn the general shapes of letters.

**Woorden (Words)**: Tracing games in smaller spaces to practise precise writing.

---

## Technical Overview

### Architecture

Cally uses a Layered Architecture with MVVM and Dependency Injection (Microsoft.Extensions.DI).

**Presentation (WPF)**: Handles the UI and navigation stack (Home → Categories → Levels → Tutorial → Game).

**Application**: Orchestrates services between the UI and Domain.

**Domain**: Contains templates and scoring and accuracy logic.

**Infrastructure**: Persistence layer using EF Core and SQLite.

### Data & Configuration

**Levels**: Defined in appsettings.json. All level values can be edited.

**Database**: A local Cally.db is created on the first launch to store GameResultRecords. To reset all high scores, simply delete this file.

---

## Adding Content

### New letter or trace pattern

1. Add a class in `Calligraphy.Domain/TraceTemplates/Letters/` (or `RepeatingTraces/`) that extends `TraceTemplate` and returns the ordered list of `StrokePoint` coordinates.
2. Add a new entry to `appsettings.json` under `TraceGames` with the matching `Template` key.

```json
"LowercaseI": {
    "Category": "Letters", // "Schetsen", "Vormen", "Letters" or "Woorden"
    "Level": 1, 
    "Difficulty": "Makkelijk", // "Makkelijk", "Gemiddeld" or "Moeilijk"
    "GameName": "i", // optional: if there is no name, level number gets displayed
    "StarThresholds": [30, 60, 100], // thresholds for 1, 2 and 3 stars
    "Template": "LowercaseI", // must match classname exactly
    "ToleranceDistance": 6, // how many pixels off the line is still valid (line thickness = 2*distance)
    "RequiredAccuracy": 1, // how much of the shape is required to be drawn for full score (0 is nothing, 1 is everything)
    "SegmentCount": 2, // optional (default is 1): how many strokes is max amount before automatically ending the session (not applicable for timed games)
    "Tutorial": {
        "PointsExplanation": "Volg de lijn om de letter a te tekenen. Kijk rechts hoe je moet beginnen", 
        "ShowPressureInfo": true, // wheter or not pressure feedback should be given
        "TargetViewModel": "TraceGameViewModel",
        "ImageSource": "/Resources/Assets/Images/Letters/lowercase-i.png" // optional: image to be show in tutorial
    }
}
```

### New timed trace pattern

1. The same as regular trace patterns, but add a new entry to `appsettings.json` under `TimedTraceGames` with the matching `Template` key.

```json
"TimedTraceLoop": {
    "Category": "Schetsen",
    "Level": 5,
    "Difficulty": "Moeilijk",
    "Template": "LoopPattern",
    "DrawDuration": 45, // Time to draw in seconds
    "StarThresholds": [30, 60, 90],
    "ToleranceDistance": 5,
    "RequiredAccuracy": 0.9,
    "Tutorial": {
        "PointsExplanation": "Teken de Ls zo netjes mogelijk!",
        "ShowPressureInfo": true,
        "TargetViewModel": "TimedTraceGameViewModel"
    }
}
```

### New shape

1. Add the shape name and its polygon definition to `Shapes.cs` extending `Shape`.
2. Add a new entry to `appsettings.json` under `ShapeGames` with the matching `Shape` key.

```json
"Vierkant": {
    "Category": "Vormen",
    "Shape": "Square",
    "Level": 1,
    "Difficulty": "Makkelijk",
    "StarThresholds": [40, 60, 85],
    "Tutorial": {
        "PointsExplanation": "Verdien punten door zo goed mogelijk de vorm na te tekenen",
        "ShowPressureInfo": true,
        "TargetViewModel": "ShapeDrawViewModel"
    }
}
```

### New word level

1. Add an image compiled as a `<Resource>` in the `.csproj`.
2. Add a new entry to `appsettings.json` under `WordGames` with a `Words` array and an `ImageSource` pointing to the image.

```json
"Farm1": {
    "Category": "Woorden",
    "Level": 1,
    "Difficulty": "Moeilijk",
    "StarThresholds": [30, 60, 85],
    "ToleranceDistance": 3.5,
    "RequiredAccuracy": 0.9,
    "Words": [
        { "Word": "koe", "X": 20, "Y": 280 },
        { "Word": "wolk", "X": 400, "Y": 20 },
        { "Word": "kip", "X": 650, "Y": 540 }
    ], // wordlist and the X and Y coordinates of the top left corner of the first letter canvas
    "ImageSource": "/Resources/Assets/Images/WordBackgrounds/farm.png", // background image used - screen size used is 1200x800
    "Tutorial": {
        "PointsExplanation": "Schrijf alle letters in de vakjes",
        "ShowPressureInfo": true,
        "TargetViewModel": "WordGameViewModel"
    }
}
```
