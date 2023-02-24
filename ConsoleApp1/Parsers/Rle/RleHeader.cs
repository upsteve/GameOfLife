using System.Text.RegularExpressions;

namespace GameOfLife.Parsers.Rle
{
    public static class RleHeader
    {
        private static readonly Regex header = new(@"^\s*x\s*=\s*(\d+),\s*y\s*=\s*(\d+)");
        public static Match FindHeader(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var match = header.Match(line);
                if (match.Success) return match;
            }
            throw new ArgumentOutOfRangeException(nameof(lines), "Provide text does not contain a valid header of the format x = 3, y = 3");
        }
    }
}