using System.Data;
using System.Text;

namespace GameOfLife
{
    public static class GridSerializer
    {
        private static char ToChar(bool cell) => cell ? 'O' : '.';

        private static string ToString(char[] chars) => new(chars);

        public static string ToString(bool[] cells, int width)
        {
            StringBuilder sb = new();
            var lines = cells.Select(ToChar).Chunk(width).Select(ToString);
            sb.AppendJoin(Environment.NewLine, lines);
            return sb.ToString();
        }
    }
}
