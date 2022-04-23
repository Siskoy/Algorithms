namespace SumOfCoins;

public class Solution
{
    public static IDictionary<int, int> ChooseCoins(IList<int> coinsInput, int targetSum)
    {
        var coins = new HashSet<int>(coinsInput).OrderByDescending(c => c).ToList();

        int coinsIndex = 0;
        int currentSum = 0;
        Dictionary<int, int> result = new();

        while (coinsIndex < coins.Count && currentSum != targetSum)
        {
            int currentCoin = coins[coinsIndex++];

            if (currentSum + currentCoin > targetSum) continue;

            int remainingSum = targetSum - currentSum;
            int coinsToTake = remainingSum / currentCoin;

            currentSum += coinsToTake * currentCoin;
            result.Add(currentCoin, coinsToTake);
        }

        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
}
