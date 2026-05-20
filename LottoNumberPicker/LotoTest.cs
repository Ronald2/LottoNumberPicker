public class LotoTest
{
    private readonly Random _random;
    private readonly GameType _gameType;
    public List<LotoList> GeneratedLists { get; } = new();

    public LotoTest(GameType gameType, Random? random = null)
    {
        _gameType = gameType;
        _random = random ?? Random.Shared;
    }

    public List<int> GetNumbers()
    {
        var gameSettings = _gameType.GetGameSettings();
        var numbers = new HashSet<int>();

        while (numbers.Count < gameSettings.TotalNumbers)
        {
            numbers.Add(_random.Next(1, gameSettings.MaxNumber + 1));
        }

        return numbers.OrderBy(x => x).ToList();
    }

    // The winning numbers could be read from a file, a database, or an external API.
    // This is only for testing.
    public List<int> GetWinningNumbers() => GetNumbers();

    public List<int> GetMatchingNumbers(IReadOnlyCollection<int> generatedNumbers, IReadOnlyCollection<int> winningNumbers)
    {
        return generatedNumbers.Intersect(winningNumbers).OrderBy(x => x).ToList();
    }

    public void GenerateNumbers(int numberOfLists)
    {
        if (numberOfLists <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfLists), "The number of lists must be greater than zero.");
        }

        GeneratedLists.Clear();

        for (int i = 0; i < numberOfLists; i++)
        {
            var generatedNumbers = GetNumbers();
            var lotoList = new LotoList(generatedNumbers, _gameType);
            GeneratedLists.Add(lotoList);
        }
    }
}
