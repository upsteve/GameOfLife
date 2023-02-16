using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class RleString
    {
        private static readonly Regex whitespace = new(@"\s+");
        private readonly string value;

        private static bool IsDataLine(string line) => !line.Contains('#') && !line.Contains('x');

        private RleString(string dataLine)
        {
            value = dataLine;
        }

        private static RleString FromDataLines(string[] lines) => new(string.Join("", lines.Where(IsDataLine)));

        private RleString RemoveWhitespace() => new(whitespace.Replace(value, ""));

        private string[] ToRows() => value.Split('$');

        private RleString TruncateAtTerminator()
        {
            var terminator = value.IndexOf('!');
            return new RleString(terminator != -1 ? value[..terminator] : value);
        }

        private static IEnumerable<RleTag> RowToTags(string row) => RleTag.Pattern.Matches(row).Select(RleTag.FromMatch);

        private static bool[] TagsToCells(IEnumerable<RleTag> tags, int width)
        {
            bool[] cells = new bool[width];
            tags.SelectMany(tag => tag.ToCells()).ToArray().CopyTo(cells, 0);
            return cells;
        }

        public static bool[] LinesToCellArray(string[] lines, Size size)
        {
            return FromDataLines(lines)
                .TruncateAtTerminator()
                .RemoveWhitespace()
                .ToRows()
                .Select(RowToTags)
                .SelectMany(tags => TagsToCells(tags, size.Width))
                .ToArray();
        }
    }
}