using SumOfCoins;

var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
var targetSum = 923;

var selectedCoins = Solution.ChooseCoins(availableCoins, targetSum);

Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
foreach (var selectedCoin in selectedCoins)
{
    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
}
