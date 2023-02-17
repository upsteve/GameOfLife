using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class RleString
    {
        private static readonly Regex whitespace = new(@"\s+");
        private readonly string value;

        private RleString(string dataLine)
        {
            value = dataLine;
        }

        private static bool IsDataLine(string line) => !line.Contains('#') && !line.Contains('x');

        private static RleString FromDataLines(IEnumerable<string> lines) => new(string.Join("", lines.Where(IsDataLine)));

        private RleString RemoveWhitespace() => new(whitespace.Replace(value, ""));

        private IEnumerable<string> ToRows(int count) => value.Split('$').Pad(count, "");

        private RleString TruncateAtTerminator()
        {
            var terminator = value.IndexOf('!');
            return new RleString(terminator != -1 ? value[..terminator] : value);
        }

        private static IEnumerable<bool> RowsToCells(string row, int count) => RleTag.Pattern.Matches(row).SelectMany(RleTag.ConvertMatchToCells).Pad(count, false);

        public static IEnumerable<bool> LinesToCells(IEnumerable<string> lines, Size size)
        {
            return FromDataLines(lines)
                .TruncateAtTerminator()
                .RemoveWhitespace()
                .ToRows(size.Height)
                .SelectMany(row => RowsToCells(row, size.Width));
        }
    }
}