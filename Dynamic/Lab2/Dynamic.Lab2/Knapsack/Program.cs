using static Knapsack.Definitions;

string? knapsackCapacityInput = Console.ReadLine();

if (knapsackCapacityInput is null) return;

int knapsackCapacity = int.Parse(knapsackCapacityInput);

List<Item> items = new(knapsackCapacity);

while (true)
{
    string? itemInput = Console.ReadLine();

    if (itemInput is null) continue;

    if (itemInput == "end") break;

    string[] itemParts = itemInput.Split(" ");

    Item newItem = new()
    {
        Name = itemParts[0],
        Weight = int.Parse(itemParts[1]),
        Price = int.Parse(itemParts[2])
    };

    items.Add(newItem);
}

Item[] itemsTaken = FillKnapsack(items, knapsackCapacity);

double totalWeight = itemsTaken.Sum(i => i.Weight);
double totalValue = itemsTaken.Sum(i => i.Price);

Console.WriteLine($"Total Weight: {totalWeight}");
Console.WriteLine($"Total Value: {totalValue}");

foreach (var item in itemsTaken.OrderBy(i => i.Name))
{
    Console.WriteLine(item.Name);
}
