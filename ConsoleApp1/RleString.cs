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
        private static readonly Regex tag = new(@"\d*[bo]");
        private static readonly char[] bAndO = { 'b', 'o' };

        private static bool GetCell(Match match) => match.Value.Last() == 'o';

        private static int GetCount(Match match) => match.Value.Length > 1 ? Convert.ToInt32(match.Value.TrimEnd(bAndO)) : 1;

        private static IEnumerable<bool> ConvertMatchToCells(Match match) => Enumerable.Repeat<bool>(GetCell(match), GetCount(match));

        private static IEnumerable<bool> RowsToCells(string row, int count) => tag.Matches(row).SelectMany(ConvertMatchToCells).Pad(count, false);

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