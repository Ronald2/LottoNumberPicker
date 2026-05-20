public static class GameTypeExtensions
{
    private static readonly IReadOnlyDictionary<GameType, GameSettings> GameSettingsByType =
        new Dictionary<GameType, GameSettings>
        {
            { GameType.Loto, new GameSettings { MaxNumber = 38, TotalNumbers = 6 } },
            { GameType.PoolLoto, new GameSettings { MaxNumber = 27, TotalNumbers = 5 } },
            { GameType.SuperKino, new GameSettings { MaxNumber = 70, TotalNumbers = 20 } },
            { GameType.MegaMillions, new GameSettings { MaxNumber = 70, TotalNumbers = 5 } },
            { GameType.PowerBall, new GameSettings { MaxNumber = 69, TotalNumbers = 5 } }
        };

    public static IReadOnlyDictionary<int, GameType> BuildSelectionMap()
    {
        return Enum.GetValues<GameType>()
            .Select((gameType, index) => new { Option = index + 1, gameType })
            .ToDictionary(item => item.Option, item => item.gameType);
    }

    public static string BuildSelectionPrompt()
    {
        return string.Join(", ", BuildSelectionMap().Select(entry => $"{entry.Key} for {entry.Value}"));
    }

    public static GameSettings GetGameSettings(this GameType gameType)
    {
        if (!GameSettingsByType.TryGetValue(gameType, out var settings))
        {
            throw new ArgumentOutOfRangeException(nameof(gameType), $"Unsupported game type: {gameType}");
        }

        settings.Validate();
        return settings;
    }
}
