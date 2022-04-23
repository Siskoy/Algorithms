using SetCover;

var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 }.ToList();
var sets = new[]
{
    new[] { 20 },
    new[] { 1, 5, 20, 30 },
    new[] { 3, 7, 20, 30, 40 },
    new[] { 9, 30 },
    new[] { 11, 20, 30, 40 },
    new[] { 3, 7, 40 }
}.ToList();

var selectedSets = Solution.ChooseSets(sets, universe).ToList();

Console.WriteLine($"Sets to take ({selectedSets}):");

foreach (var set in selectedSets)
{
    Console.WriteLine($"{{ {string.Join(", ", set)} }}");
}