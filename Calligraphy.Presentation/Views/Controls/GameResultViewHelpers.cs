using Calligraphy.Domain;

namespace Calligraphy.Presentation.Views.Controls;

internal static class GameResultViewHelpers
{
    public static async Task AnimateStarsIfResultAsync(GameResultPopup popup, GameResult gameResult)
    {
        if (gameResult == null) return;
        await popup.AnimateStars(gameResult.StarCount);
    }
}

