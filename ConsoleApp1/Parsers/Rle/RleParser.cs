using System.Drawing;

namespace GameOfLife.Parsers.Rle
{
    public class RleParser : IGridParser
    {
        private static Size GetSizeFromHeader(IEnumerable<string> lines)
        {
            var header = RleHeader.FindHeader(lines);
            return new Size(
                Convert.ToInt32(header.Groups[1].Value),
                Convert.ToInt32(header.Groups[2].Value));
        }

        private static IEnumerable<string> SplitLines(string rle) => rle.ToLower().Split(Environment.NewLine);

        private static IEnumerable<bool> LinesToCells(IEnumerable<string> lines, Size size)
        {
            return new RleString(lines)
                .TruncateAtTerminator()
                .RemoveWhitespace()
                .ToRows(size.Height)
                .SelectMany(row => RleRow.ConvertToCells(row, size.Width));
        }

        public Grid FromString(string value)
        {
            var lines = SplitLines(value);
            var size = GetSizeFromHeader(lines);
            return new Grid(size, Generator.Default(size), LinesToCells(lines, size).ToArray());
        }
    }
}
