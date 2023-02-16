using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class RleTag
    {
        public static readonly Regex Pattern = new(@"\d*[bo]");
        private static readonly char[] bAndO = { 'b', 'o' };

        public int Count;
        public char Cell;

        public static RleTag FromMatch(Match match) => new()
        {
            Count = match.Value.Length > 1 ? Convert.ToInt32(match.Value.TrimEnd(bAndO)) : 1,
            Cell = match.Value.Last()
        };

        public IEnumerable<bool> ToCells()
        {
            return Enumerable.Repeat<bool>(Cell == 'o', Count);
        }
    }
}