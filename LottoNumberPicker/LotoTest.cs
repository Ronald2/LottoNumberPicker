public class LotoTest
{
    private readonly Random _random = new Random();

    public LotoTest() { }

    public List<int> GetNumbers(GameType gameType)
    {
        var gameSettings = gameType.GetGameSettings();
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
    public List<int> GetWinningNumbers(GameType gameType)
    {
        return GetNumbers(gameType);
        //var winningNumbers = new HashSet<int>();
        //var gameSettings = gameType.GetGameSettings();

        //while (winningNumbers.Count < gameSettings.TotalNumbers)
        //{
        //    var num = _random.Next(1, gameSettings.MaxNumber + 1);
        //    winningNumbers.Add(num);
        //}
        //return winningNumbers.ToList();
    }
}
