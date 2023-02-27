using System.Data;
using System.Text;

namespace GameOfLife
{
    public static class GridSerializer
    {
        private static char CellToChar(bool cell) => cell ? 'O' : '.';

        private static string CharArrayToString(char[] chars) => new(chars);

        public static string ToString(bool[] cells, int width)
        {
            var lines = cells.Select(CellToChar).Chunk(width).Select(CharArrayToString);
            return new StringBuilder().AppendJoin(Environment.NewLine, lines).ToString();
        }
    }
}
