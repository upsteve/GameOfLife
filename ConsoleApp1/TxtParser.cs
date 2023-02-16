namespace GameOfLife
{
    public class TxtParser : IGridParser
    {
        private string[] SplitLines(string plainText) => plainText.ToUpper().Trim().Split(Environment.NewLine);

        private static void PopulateGridFromLines(ref Grid grid, string[] lines)
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

        public Grid FromString(string plainText)
        {
            var lines = SplitLines(plainText);
            var grid = new Grid(lines[0].Length, lines.Length);
            PopulateGridFromLines(ref grid, lines);
            return grid;
        }
    }
}
