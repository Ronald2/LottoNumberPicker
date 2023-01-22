// See https://aka.ms/new-console-template for more information

var gameTypeMap = new Dictionary<int, GameType>()
        {
            { 1, GameType.Loto },
            { 2, GameType.SuperKino },
            { 3, GameType.MegaMillions },
            { 4, GameType.PowerBall }
        };

Console.WriteLine("Please select a game type (1 for Loto, 2 for SuperKino, 3 for MegaMillions, 4 for PowerBall):");
int gameTypeInput;
if (!int.TryParse(Console.ReadLine(), out gameTypeInput) || !gameTypeMap.ContainsKey(gameTypeInput))
{
    Console.WriteLine("Invalid game type. Please select a valid option.");
    return;
}

GameType gameType = gameTypeMap[gameTypeInput];
var test = new LotoTest();

Console.WriteLine("Please enter the number of lists of numbers you want to generate:");
int numberOfLists;
if (!int.TryParse(Console.ReadLine(), out numberOfLists) || numberOfLists <= 0)
{
    Console.WriteLine("Invalid number. Please enter a valid number.");
    return;
}

Console.WriteLine("Do you want to compare the numbers with the winning numbers? (Y/N)");
string answer = Console.ReadLine();
if (answer.ToLower() == "y")
{
    var winningNumbers = test.GetWinningNumbers(gameType);
    var winningNumbersString = string.Join(", ", winningNumbers.Select(x => string.Format("{0:D2}", x)));
    Console.WriteLine("Winning Numbers: " + winningNumbersString);

    for (int i = 1; i <= numberOfLists; i++)
    {
        var generatedTest = test.GetNumbers(gameType);
        var generatedTestString = string.Join(", ", generatedTest.Select(x => string.Format("{0:D2}", x)));
        Console.WriteLine("\nYour numbers for list " + i + ": " + generatedTestString);
        var result = test.CompareNumbers(generatedTest, winningNumbers);
        Console.WriteLine(result);
    }
}
else
{
    for (int i = 1; i <= numberOfLists; i++)
    {
        var generatedTest = test.GetNumbers(gameType);
        var generatedTestString = string.Join(", ", generatedTest.Select(x => string.Format("{0:D2}", x)));
        Console.WriteLine("\nYour numbers for list " + i + ": " + generatedTestString);
    }
}