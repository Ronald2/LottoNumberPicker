public class LotoList
{
    public IReadOnlyList<int> Numbers { get; }
    public GameType GameType { get; }
    public DateTime DateGenerated { get; }

    public LotoList(IReadOnlyList<int> numbers, GameType gameType)
    {
        Numbers = numbers;
        GameType = gameType;
        DateGenerated = DateTime.Now;
    }
}
