using System.Drawing;

namespace GameOfLife.Parsers.Txt
{
    public class TxtParser : IGridParser
    {
        private static ICollection<string> SplitLines(string plainText) => plainText.ToUpper().Trim().Split(Environment.NewLine);

        private static bool[] LinesToCells(ICollection<string> lines) => lines.SelectMany(line => line).Select(c => c == 'O').ToArray();

        public Grid FromString(string value)
        {
            var lines = SplitLines(value);
            var size = new Size(lines.First().Length, lines.Count);
            return new Grid(size, Generator.Default(size), LinesToCells(lines));
        }
    }
}
