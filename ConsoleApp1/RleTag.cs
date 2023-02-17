using System.Text.RegularExpressions;

namespace GameOfLife
{
    public static class RleTag
    {
        private static readonly Regex Pattern = new(@"\d*[bo]");
        private static readonly char[] bAndO = { 'b', 'o' };

        private static bool GetCell(Match match) => match.Value.Last() == 'o';

        private static int GetCount(Match match) => match.Value.Length > 1 ? Convert.ToInt32(match.Value.TrimEnd(bAndO)) : 1;

        private static IEnumerable<bool> ConvertMatchToCells(Match match) => Enumerable.Repeat<bool>(GetCell(match), GetCount(match));

        public static IEnumerable<bool> RowsToCells(string row, int count) => Pattern.Matches(row).SelectMany(ConvertMatchToCells).Pad(count, false);

    }
}