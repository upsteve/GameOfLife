using GameOfLife.CellEnumeration;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace GameOfLife.Parsers.Rle
{
    public class RleString
    {
        private readonly string value;

        private RleString(string value)
        {
            this.value = value;
        }

        public RleString(IEnumerable<string> lines)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            value = string.Join("", lines.Where(IsDataLine));
        }

        private static bool IsDataLine(string line) => !line.Contains('#') && !line.Contains('x');

        private RleString RemoveWhitespace() => new(Regex.Replace(value, @"\s+", ""));

        private IEnumerable<string> ToRows(int count) => value.Split('$').Pad(count, "");

        private RleString TruncateAtTerminator()
        {
            var terminator = value.IndexOf('!');
            return new RleString(terminator != -1 ? value[..terminator] : value);
        }

        public static IEnumerable<bool> LinesToCells(IEnumerable<string> lines, Size size)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));

            return new RleString(lines)
                .TruncateAtTerminator()
                .RemoveWhitespace()
                .ToRows(size.Height)
                .SelectMany(row => RleConverter.RowToCells(row, size.Width));
        }
    }
}