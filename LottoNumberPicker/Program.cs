var gameTypeMap = new Dictionary<int, GameType>()
        {
            { 1, GameType.Loto },
            { 2, GameType.SuperKino },
            { 3, GameType.MegaMillions },
            { 4, GameType.PowerBall },
            {5, GameType.PoolLoto }
        };

Console.WriteLine("Please select a game type (1 for Loto, 2 for SuperKino, 3 for MegaMillions, 4 for PowerBall, 5 for Loto Pool):");
int gameTypeInput;
if (!int.TryParse(Console.ReadLine(), out gameTypeInput) || !gameTypeMap.ContainsKey(gameTypeInput))
{
    Console.WriteLine("Invalid game type. Please select a valid option.");
    return;
}

GameType gameType = gameTypeMap[gameTypeInput];
var test = new LotoTest(gameType);

Console.WriteLine("Please enter the number of lists of numbers you want to generate:");
int numberOfLists;
if (!int.TryParse(Console.ReadLine(), out numberOfLists) || numberOfLists <= 0)
{
    Console.WriteLine("Invalid number. Please enter a valid number.");
    return;
}

Console.WriteLine("Do you want to compare the numbers with the winning numbers? (Y/N)");
string answer = Console.ReadLine().ToLower();

DisplayResult(test, numberOfLists, answer);

void DisplayResult(LotoTest test, int numberOfLists, string answer)
{
    var winningNumbers = answer == "y" ? test.GetWinningNumbers() : null;

    if (winningNumbers != null)
    {
        Console.WriteLine($"Winning Numbers: {string.Join(", ", winningNumbers.Select(x => $"{x:D2}"))}");
    }

    for (int i = 1; i <= numberOfLists; i++)
    {
        var generatedTest = test.GetNumbers();
        var generatedTestString = string.Join(", ", generatedTest.Select(x => string.Format("{0:D2}", x)));
        Console.WriteLine("\nYour numbers for list " + i + ": " + generatedTestString);

        if (winningNumbers != null)
        {
            var matchedNumbers = test.GetMatchingNumbers(generatedTest, winningNumbers);
            var matches = matchedNumbers.Count > 0
                ? $"You have {matchedNumbers.Count} matches. These are: {string.Join(",", matchedNumbers)}"
                : "You have no matches.";
            Console.WriteLine(matches);
        }
    }
}



//var generatedTest = test.GetNumbers();
//var generatedTestString = string.Join(", ", generatedTest.Select(x => string.Format("{0:D2}", x)));
//Console.WriteLine("\nYour numbers for list " + i + ": " + generatedTestString);



////var type = GameType.Loto;
////var test = new LotoTest(type);
////List<int> winningNumber = test.GetWinningNumbers();
////int count = 0;


////while (true)
////{
////    int match = 0;
////    var generatedNumber = test.GetNumbers();
////    foreach (var item in generatedNumber)
////    {
////        if (winningNumber.Contains(item))
////        {
////            match++;
////        }
////    }
////    count++;
////    if (match == 6)
////    { break; }
////}
////Console.WriteLine($"you have played {count} tickets for win 6 numbers in loto");