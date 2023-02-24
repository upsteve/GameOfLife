using GameOfLife.CellEnumeration;
using System.Text.RegularExpressions;

namespace GameOfLife.Parsers.Rle
{
    public static class RleRow
    {
        private static readonly Regex Pattern = new(@"\d*[bo]");

        private static string MatchToTag(Match match) => match.Value;

        public static IEnumerable<bool> ConvertToCells(string row, int count) => Pattern.Matches(row).Select(MatchToTag).SelectMany(RleTag.ConvertToCells).Pad(count, false);
    }
}