var gameTypeMap = GameTypeExtensions.BuildSelectionMap();

Console.WriteLine($"Please select a game type ({GameTypeExtensions.BuildSelectionPrompt()}):");
if (!TryReadInt(out var gameTypeInput) || !gameTypeMap.TryGetValue(gameTypeInput, out var gameType))
{
    Console.WriteLine("Invalid game type. Please select a valid option.");
    return;
}

var lotoTest = new LotoTest(gameType);

Console.WriteLine("Please enter the number of lists of numbers you want to generate:");
if (!TryReadInt(out var numberOfLists) || numberOfLists <= 0)
{
    Console.WriteLine("Invalid number. Please enter a valid number.");
    return;
}

Console.WriteLine("Do you want to compare the numbers with the winning numbers? (Y/N)");
var compareWithWinningNumbers = ReadYesNo();

DisplayResult(lotoTest, gameType, numberOfLists, compareWithWinningNumbers);

static bool TryReadInt(out int value)
{
    return int.TryParse(Console.ReadLine(), out value);
}

static bool ReadYesNo()
{
    var answer = Console.ReadLine()?.Trim();
    return string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase);
}

static string FormatNumbers(IEnumerable<int> numbers)
{
    return string.Join(", ", numbers.Select(x => $"{x:D2}"));
}

static void DisplayResult(LotoTest lotoTest, GameType gameType, int numberOfLists, bool compareWithWinningNumbers)
{
    lotoTest.GenerateNumbers(numberOfLists);

    var winningNumbers = compareWithWinningNumbers ? lotoTest.GetWinningNumbers() : null;

    if (winningNumbers is not null)
    {
        Console.WriteLine($"Winning Numbers: {FormatNumbers(winningNumbers)}");
    }

    for (var i = 0; i < numberOfLists; i++)
    {
        var generatedNumbers = lotoTest.GeneratedLists[i].Numbers;
        Console.WriteLine($"\nYour numbers for list {i + 1}: {FormatNumbers(generatedNumbers)}");

        if (winningNumbers is null)
        {
            continue;
        }

        var matchedNumbers = lotoTest.GetMatchingNumbers(generatedNumbers, winningNumbers);
        var message = matchedNumbers.Count > 0
            ? $"You have {matchedNumbers.Count} matches. These are: {string.Join(", ", matchedNumbers)}"
            : "You have no matches.";

        Console.WriteLine(message);
    }

    Console.WriteLine("\nDo you want to save the generated numbers? (Y/N)");
    if (ReadYesNo())
    {
        SaveGeneratedNumbers(lotoTest, gameType);
    }
}

static void SaveGeneratedNumbers(LotoTest lotoTest, GameType gameType)
{
    var fileName = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        $"generated_numbers_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt");

    using var writer = new StreamWriter(fileName);

    writer.WriteLine($"Game Type: {gameType}");
    for (var i = 0; i < lotoTest.GeneratedLists.Count; i++)
    {
        var generatedNumbers = lotoTest.GeneratedLists[i].Numbers;
        writer.WriteLine($"\nYour numbers for list {i + 1}: {FormatNumbers(generatedNumbers)}");
    }

    Console.WriteLine($"Generated numbers have been saved to {fileName}.");
}
