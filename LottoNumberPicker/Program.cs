// See https://aka.ms/new-console-template for more information

var gameTypeMap = new Dictionary<int, GameType>()
    {
        { 1, GameType.Loto },
        { 2, GameType.SuperKino },
        { 3, GameType.MegaMillions },
        { 4, GameType.PowerBall },
    };

Console.WriteLine("Please select a game type (1 for Loto, 2 for SuperKino, 3 for MegaMillions, 4 for Powerball):");

int gameTypeInput;

if (!int.TryParse(Console.ReadLine(), out gameTypeInput) || !gameTypeMap.ContainsKey(gameTypeInput))
{
    Console.WriteLine("Invalid game type. Please select a valid option.");
    return;
}

GameType gameType = gameTypeMap[gameTypeInput];

var test = new LotoTest();
var generatedTest = test.GetNumbers(gameType);
var generatedTestString = string.Join(", ", generatedTest.Select(x => string.Format("{0:D2}", x)));

Console.WriteLine("\nLotery Random numbers \n");
Console.WriteLine("Your numbers: " + generatedTestString);

var result = test.CompareNumbers(generatedTest, test.GetWinningNumbers(gameType));

Console.WriteLine(result);

