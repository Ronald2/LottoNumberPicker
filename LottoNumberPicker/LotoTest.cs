public class LotoTest
{
    private readonly Random _random = new Random();
    private readonly GameType _gameType;

    public LotoTest(GameType gameType) {
        _gameType= gameType;
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

    public string CompareNumbers(List<int> generatedNumbers, List<int> winningNumbers)
    {
        var matches = generatedNumbers.Intersect(winningNumbers).Count();
        return matches > 0 ? $"You have {matches} matches." : "You have no matches.";
    }

    //the Winning numbers could be read from a file, a database, or an external API
    //this is only for testing.
    public List<int> GetWinningNumbers()
    {
        return GetNumbers();
    }

    public void SaveNumbersToFile(List<int> generatedNumbers, string fileName)
    {        
        using (var file = new StreamWriter(fileName))
        {            
            foreach (var number in generatedNumbers)
            {
                file.WriteLine(number);
            }
        }
    }
}
