namespace GameOfLife.Parsers.Txt
{
    public class TxtParser : IGridParser
    {
        private static ICollection<string> SplitLines(string plainText) => plainText.ToUpper().Trim().Split(Environment.NewLine);

        private static void PopulateGridFromLines(ref Grid grid, ICollection<string> lines)
        {
            var i = 0;
            foreach (var line in lines)
            {
                foreach (var c in line)
                {
                    grid[i++] = c == 'O';
                }
            }
        }

        public Grid FromString(string value)
        {
            var lines = SplitLines(value);
            var grid = new Grid(lines.First().Length, lines.Count);
            PopulateGridFromLines(ref grid, lines);
            return grid;
        }
    }
}
