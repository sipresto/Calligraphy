namespace Calligraphy.Domain.Utility;

public static class FeedbackMessageProvider
{
    private static readonly Dictionary<FeedbackType, string[]> Messages = new()
    {
        {
            FeedbackType.PressureInconsistent,
            [
                "Probeer de hele tijd even hard te drukken",
                "Let erop dat je pen overal even stevig op het blad staat",
                "Oefen om met een gelijke druk te schrijven"
            ]
        },
        {
            FeedbackType.PressureTooHigh,
            [
                "Probeer iets zachter te drukken",
                "Je mag je pen wat lichter vasthouden",
                "Let op je druk, probeer minder hard te schrijven"
            ]
        },
        {
            FeedbackType.PressureTooLow,
            [
                "Probeer iets steviger te drukken",
                "Druk iets harder zodat de lijn duidelijker wordt",
                "Houd de pen wat steviger vast tijdens het schrijven"
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
                "Super gedaan! Je bent een echte schrijver!"
            ]
        },
        {
            2,
            [
                "Goed gedaan! Het was al bijna perfect!",
                "Heel netjes! Nog een klein beetje oefenen!",
                "Mooi werk! Je bent goed bezig!"
            ]
        },
        {
            1,
            [
                "Niet slecht! Probeer het nog eens!",
                "Goed geprobeerd! Nog een keer oefenen?",
                "Je bent al goed op weg! Probeer het nog eens!"
            ]
        },
        {
            0,
            [
                "Blijf oefenen! Je kunt het beter doen!",
                "Houd vol! Volgende keer gaat het beter!",
                "Niet opgeven! Probeer het opnieuw!"
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
}