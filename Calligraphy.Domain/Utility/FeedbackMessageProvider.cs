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
                "Schrijf eens met wat minder kracht"
            ]
        },
        {
            FeedbackType.PressureTooLow,
            [
                "Probeer iets steviger te drukken",
                "Je mag je pen wat duidelijker op het blad zetten",
                "Zorg dat je pen het papier goed raakt"
            ]
        },
        {
            FeedbackType.SpeedInconsistent,
            [
                "Probeer in een rustig en gelijk tempo te schrijven",
                "Houd je schrijfsnelheid overal ongeveer hetzelfde",
                "Schrijf in een mooi, gelijk ritme"
            ]
        },
        {
            FeedbackType.SpeedTooHigh,
            [
                "Probeer iets rustiger te schrijven",
                "Neem wat meer tijd voor je beweging",
                "Schrijf iets langzamer en gecontroleerd"
            ]
        },
        {
            FeedbackType.SpeedTooLow,
            [
                "Je mag iets sneller schrijven",
                "Probeer je beweging wat vlotter te maken",
                "Schrijf iets soepeler en iets sneller"
            ]
        },
        {
            FeedbackType.Perfect,
            [
                "Dat heb je heel goed gedaan",
                "Wat knap geschreven",
                "Mooi werk, ga zo door"
            ]
        }
    };
    
    private static readonly Dictionary<int, string[]> StarMessages = new()
    {
        {
            3,
            [
                "Geweldig! Je hebt het heel goed gedaan!",
                "Fantastisch! Dat was bijna perfect!",
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
                "Je bent al op weg! Nog eens proberen!"
            ]
        },
        {
            0,
            [
                "Blijf oefenen! Je kunt het beter doen!",
                "Geen probleem! Probeer het nog eens!",
                "Oefening baart kunst!"
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