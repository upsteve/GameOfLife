using GameOfLife.CellEnumeration;
using System.Data;
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

        public RleString TruncateAtTerminator()
        {
            var terminator = value.IndexOf('!');
            return new RleString(terminator != -1 ? value[..terminator] : value);
        }

        public RleString RemoveWhitespace() => new(Regex.Replace(value, @"\s+", ""));

        public IEnumerable<string> ToRows(int count) => value.Split('$').Pad(count, "");

    }
}