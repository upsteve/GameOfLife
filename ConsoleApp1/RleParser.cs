using System.Drawing;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class RleParser : IGridParser
    {
        private static readonly Regex header = new(@"^\s*x\s*=\s*(\d+),\s*y\s*=\s*(\d+)");

        private static Match FindHeader(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var match = header.Match(line);
                if (match.Success) return match;
            }
            throw new ArgumentOutOfRangeException("filename", "File does not contain a valid header of the format x = 3, y = 3");
        }

        private static Size ToSize(Match header)
        {
            return new Size(
                Convert.ToInt32(header.Groups[1].Value),
                Convert.ToInt32(header.Groups[2].Value));
        }

        private static Size GetSizeFromHeader(IEnumerable<string> lines)
        {
            var header = FindHeader(lines);
            return ToSize(header);
        }

        private static IEnumerable<string> SplitLines(string rle) => rle.ToLower().Split(Environment.NewLine);

        public Grid FromString(string rle)
        {
            var lines = SplitLines(rle);
            var size = GetSizeFromHeader(lines);
            var cells = RleString.LinesToCells(lines, size);
            return new Grid(size.Width, size.Height, cells.ToArray());
        }
    }
}
