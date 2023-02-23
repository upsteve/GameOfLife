using System.Drawing;
using System.Text.RegularExpressions;

namespace GameOfLife.Parsers.Rle
{
    public class RleParser : IGridParser
    {
        private static Size ToSize(Match header)
        {
            return new Size(
                Convert.ToInt32(header.Groups[1].Value),
                Convert.ToInt32(header.Groups[2].Value));
        }

        private static Size GetSizeFromHeader(IEnumerable<string> lines)
        {
            var header = RleHeader.FindHeader(lines);
            return ToSize(header);
        }

        private static IEnumerable<string> SplitLines(string rle) => rle.ToLower().Split(Environment.NewLine);

        public Grid FromString(string value)
        {
            var lines = SplitLines(value);
            var size = GetSizeFromHeader(lines);
            var cells = RleString.LinesToCells(lines, size);
            return GridBuilder.FromSizeWithCells(size, cells.ToArray());
        }
    }
}
