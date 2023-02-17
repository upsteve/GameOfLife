using System.Security.Principal;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public static class RleTag
    {
        public static readonly Regex Pattern = new(@"\d*[bo]");
        private static readonly char[] bAndO = { 'b', 'o' };

        public static bool GetCell(Match match) => match.Value.Last() == 'o';

        public static int GetCount(Match match) => match.Value.Length > 1 ? Convert.ToInt32(match.Value.TrimEnd(bAndO)) : 1;

        public static IEnumerable<bool> ConvertMatchToCells(Match match)
        {
            return Enumerable.Repeat<bool>(GetCell(match), GetCount(match));
        }
    }
}