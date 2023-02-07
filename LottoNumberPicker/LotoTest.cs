public class LotoTest
{
    private readonly Random _random = new Random();
    private readonly GameType _gameType;
    public List<LotoList> GeneratedLists { get; set; } = new List<LotoList>();



    public LotoTest(GameType gameType)
    {
        _gameType = gameType;
    }

    public List<int> GetNumbers()
    {
        var gameSettings = _gameType.GetGameSettings();
        var numbers = new HashSet<int>();

        while (numbers.Count < gameSettings.TotalNumbers)
        {
            var num = _random.Next(1, gameSettings.MaxNumber + 1);
            numbers.Add(num);
        }

        return numbers.OrderBy(x => x).ToList();
    }

    //the Winning numbers could be read from a file, a database, or an external API
    //this is only for testing.
    public List<int> GetWinningNumbers()
    {
        return GetNumbers();
    }

    public List<int> GetMatchingNumbers(List<int> generatedNumbers, List<int> winningNumbers)
    {
        var matches = generatedNumbers.Intersect(winningNumbers).ToList();
        return matches;
    }

    public void GenerateNumbers(int numberOfList)
    {
        for (int i = 0; i < numberOfList; i++)
        {
            var generatedTest = GetNumbers();
            var lotoList = new LotoList(generatedTest, _gameType);
            GeneratedLists.Add(lotoList);
        }
    }
}
