internal class Item
{
    public double Price { get; set; }

    public double Weight { get; set; }

    public double ValueRatio => Price / Weight;
}
