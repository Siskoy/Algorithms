namespace Common
{
    using System.Text.RegularExpressions;

    public static class Validator
    {
        private static readonly Regex NumberRegex = new(@"^-?\d*(\.\d+)?$");

        public static bool IsNumber(string input) => NumberRegex.IsMatch(input);
    }
}
