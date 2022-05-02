string? bagCapacityInput = Console.ReadLine();
string? itemsCountInput = Console.ReadLine();

if (bagCapacityInput is null || itemsCountInput is null) return;

int bagCapacity = int.Parse(bagCapacityInput.Replace("Capacity: ", ""));
int itemsCount = int.Parse(itemsCountInput.Replace("Items: ", ""));

List<Item> items = new(itemsCount);

for (int i = 0; i < itemsCount; i++)
{
    string? itemInput = Console.ReadLine();

    if (itemInput is null) continue;

    string[] itemParts = itemInput.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    if (itemParts.Length != 2) continue;

    double price = double.Parse(itemParts[0]);
    double weight = double.Parse(itemParts[1]);

    items.Add(new Item { Price = price, Weight = weight });
}

items = items.OrderByDescending(x => x.ValueRatio).ToList();

double totalPrice = 0.0;
double bagWeight = 0.0;

foreach (var item in items)
{
    if (bagWeight + item.Weight <= bagCapacity)
    {
        totalPrice += item.Price;
        bagWeight += item.Weight;

        PrintOutput(item, 100);
    }
    else
    {
        double leftCapacity = bagCapacity - bagWeight;
        double quotient = leftCapacity / item.Weight;

        totalPrice += item.Price * quotient;

        double percentToTake = quotient * 100;

        PrintOutput(item, percentToTake);

        break;
    }
}

Console.WriteLine($"Total price: {totalPrice:F2}");

static void PrintOutput(Item item, double percentToTake)
{
    static string PercentFormat(double percent) => percent == 100 ? percent.ToString() : $"{percent:F2}";

    Console.WriteLine(
        $"Take {PercentFormat(percentToTake)}% of item with price {item.Price:F2} and weight {item.Weight:F2}"
    );
}
