using System.Text.RegularExpressions;

namespace GameOfLife.Parsers.Rle
{
    public static class RleTag
    {
        private static bool GetCell(Match match) => match.Value.Last() == 'o';

        private static string TrimCell(Match match) => match.Value.TrimEnd(new char[] { 'b', 'o' });

        private static int GetCount(Match match) => match.Value.Length > 1 ? Convert.ToInt32(TrimCell(match)) : 1;

        public static IEnumerable<bool> ConvertMatchToCells(Match match) => Enumerable.Repeat(GetCell(match), GetCount(match));
    }
}