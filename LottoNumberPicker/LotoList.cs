

public class LotoList
{
    public List<int> Numbers { get; set; }
    public GameType GameType { get; set; }
    public DateTime DateGenerated { get; set; }

    public LotoList(List<int> numbers, GameType gameType)
    {
        Numbers = numbers;
        GameType = gameType;
        DateGenerated = DateTime.Now;
    }
}