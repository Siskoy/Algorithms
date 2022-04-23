namespace SetCover;

public class Solution
{
    public static IEnumerable<int[]> ChooseSets(IList<int[]> sets, IList<int> universeInput)
    {
        List<int[]> result = new();
        var universe = new HashSet<int>(universeInput);

        while (universe.Count > 0)
        {
            var currentSet = sets
                .OrderByDescending(x => x.Count(universe.Contains))
                .First();

            result.Add(currentSet);
            sets.Remove(currentSet);

            foreach (var element in currentSet)
            {
                universe.Remove(element);
            }
        }

        return result;
    }
}
