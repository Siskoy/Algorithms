namespace Knapsack;

public class Definitions
{
    public static Item[] FillKnapsack(List<Item> items, int capacity)
    {
        int[,] maxPrice = new int[items.Count, capacity + 1];
        bool[,] isItemTaken = new bool[items.Count, capacity + 1];

        // Fill first row
        for (int c = 0; c <= capacity; c++)
        {
            if (items[0].Weight > c) continue;

            maxPrice[0, c] = items[0].Price;
            isItemTaken[0, c] = true;
        }

        // Fill rest rows
        for (int i = 1; i < items.Count; i++)
        {
            for (int c = 0; c <= capacity; c++)
            {
                maxPrice[i, c] = maxPrice[i - 1, c];

                int remainingCapacity = c - items[i].Weight;

                if (remainingCapacity < 0) continue;

                int possibleBestPrice = items[i].Price + maxPrice[i - 1, remainingCapacity];

                if (possibleBestPrice > maxPrice[i, c])
                {
                    maxPrice[i, c] = possibleBestPrice;
                    isItemTaken[i, c] = true;
                }
            }
        }

        List<Item> itemsTaken = new(items.Count);

        // Trace back the result
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (isItemTaken[i, capacity])
            {
                itemsTaken.Add(items[i]);
                capacity -= items[i].Weight;
            }
        }

        itemsTaken.Reverse();

        return itemsTaken.ToArray();
    }

    public class Item
    {
        public string Name { get; set; } = default!;

        public int Weight { get; set; }

        public int Price { get; set; }
    }
}