namespace Calligraphy.Domain.Utility;

public static class FeedbackMessageProvider
{
    private static readonly Dictionary<FeedbackType, string[]> Messages = new()
    {
        {
            FeedbackType.PressureInconsistent,
            [
                "Probeer de hele tijd even hard te drukken",
                "Let erop dat je pen overal even stevig op de tablet staat",
                "Oefen om met een gelijke druk te schrijven",
                "Probeer rustig en gelijkmatig te schrijven",
                "Houd je pen stabiel en druk niet te hard of te zacht"
            ]
        },
        {
            FeedbackType.PressureTooHigh,
            [
                "Probeer iets zachter te drukken",
                "Je mag je pen wat lichter vasthouden",
                "Let op je druk, probeer minder hard te schrijven",
                "Schrijf wat lichter, dan gaat het makkelijker",
                "Minder druk geeft een mooier resultaat"
            ]
        },
        {
            FeedbackType.PressureTooLow,
            [
                "Probeer iets steviger te drukken",
                "Druk iets harder zodat de lijn duidelijker wordt",
                "Houd de pen wat steviger vast tijdens het schrijven",
                "Je druk is te licht, zet wat meer kracht",
                "Druk de pen iets steviger op de tablet"
            ]
        },
        {
            FeedbackType.InfinityWrongDirection,
            [
                "Let op dat je de richting van de pijl volgt om de liggende 8 vorm te tekenen",
                "De pijl laat zien hoe je moet beginnen, probeer die te volgen"
            ]
        },
        {
            FeedbackType.InfinityCirclesHit,
            [
                "Let op dat je om de cirkels heen gaat",
                "Probeer de cirkels niet te raken"
            ]
        },
        {
            FeedbackType.TraceWrongDirection,
            [
                "Let op dat je de vorm in de goede volgorde volgt",
                "Volg de lijn in de juiste richting"
            ]
        },
        {
            FeedbackType.TraceAccuracy,
            [
                "Blijf dichter bij de lijn",
                "Volg de lijn zo goed mogelijk"
            ]
        },
        {
            FeedbackType.TraceCoverage,
            [
                "Probeer de hele lijn te volgen",
                "Probeer geen stukje over te slaan"
            ]
        },
        {
            FeedbackType.WordAccuracy,
            [
                "Blijf dichter bij de lijnen",
                "Volg de lijnen zo goed mogelijk"
            ]
        },
        {
            FeedbackType.WordCoverage,
            [
                "Probeer de alle letters volledig te volgen",
                "Probeer geen letters over te slaan"
            ]
        },
        {
            FeedbackType.Perfect,
            [
                string.Empty
            ]
        }
    };

    private static readonly Dictionary<int, string[]> StarMessages = new()
    {
        {
            3,
            [
                "Geweldig! Je hebt het heel goed gedaan!",
                "Fantastisch! Dat was perfect!",
                "Super gedaan! Je bent een echte schrijver!",
                "Perfecte score! Je bent een ster!",
                "Wauw, dat was uitstekend!"
            ]
        },
        {
            2,
            [
                "Goed gedaan! Het was al bijna perfect!",
                "Heel netjes! Nog een klein beetje oefenen!",
                "Mooi werk! Je bent goed bezig!",
                "Bijna perfect, nog even doorgaan!",
                "Heel goed, met wat meer oefening lukt het helemaal!"
            ]
        },
        {
            1,
            [
                "Niet slecht! Probeer het nog eens!",
                "Goed geprobeerd! Nog een keer oefenen?",
                "Je bent al goed op weg! Probeer het nog eens!",
                "Één ster, blijf oefenen!",
                "Volgende keer meer sterren, je kunt het!"
            ]
        },
        {
            0,
            [
                "Blijf oefenen! Je kunt het beter doen!",
                "Houd vol! Volgende keer gaat het beter!",
                "Niet opgeven! Probeer het opnieuw!",
                "Het lukt de volgende keer vast beter!",
                "Nog even doorzetten, je komt er wel!"
            ]
        }
    };

    private static readonly Random Random = new();

    public static string GetRandomMessage(FeedbackType type)
    {
        if (!Messages.TryGetValue(type, out var options))
            return string.Empty;

        int index = Random.Next(options.Length);
        return options[index];
    }

    public static string GetStarsMessage(int stars)
    {
        if (!StarMessages.TryGetValue(stars, out var options))
            return string.Empty;

        int index = Random.Next(options.Length);
        return options[index];
    }

    public static string GetRandomWordWrongDirectionMessage(List<string> wrongLetters)
    {
        if (!wrongLetters.Any()) return string.Empty;

        var letterList = string.Join(", ", wrongLetters);

        string[] messages =
        [
            $"De richting van {letterList} was niet correct. Ga terug naar de lettersoefeningen om dit te trainen!",
            $"Let op de richting bij {letterList}. Oefen deze letters nog eens apart!",
            $"{letterList} hadden de verkeerde richting. Oefen ze eerst apart voordat je verder gaat met woorden!"
        ];

        return messages[Random.Next(messages.Length)];
    }
}