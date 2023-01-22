public static class GameTypeExtensions
{
    private static readonly Dictionary<GameType, GameSettings> _gameSettings = new Dictionary<GameType, GameSettings>
    {
        { GameType.Loto, new GameSettings { MaxNumber = 38, TotalNumbers = 6 } },
        { GameType.SuperKino, new GameSettings { MaxNumber = 70, TotalNumbers = 20 } }
    };

    public static GameSettings GetGameSettings(this GameType gameType)
    {
        return _gameSettings[gameType];
    }
}