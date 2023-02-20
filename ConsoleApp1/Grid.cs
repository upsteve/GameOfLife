using System.Data;
using System.Drawing;

namespace GameOfLife
{
    public class Grid : ICloneable
    {
        public Size Size { get; }
        private readonly bool[] cells;
        private readonly GridEnumerator gridEnumerator;

        public Grid(int width, int height) : this(width, height, new bool[width * height]) { }

        public Grid(int width, int height, bool[] cells)
        {
            Size = new Size(width, height);
            gridEnumerator = new GridEnumerator(Size);
            this.cells = cells;
        }

        public bool this[int index]
        {
            get => cells[index];
            set => cells[index] = value;
        }

        public bool this[Point point]
        {
            get => cells[point.Y * Size.Width + point.X];
            set => cells[point.Y * Size.Width + point.X] = value;
        }

        public object Clone() => new Grid(Size.Width, Size.Height, (bool[])cells.Clone());
        private int CountOfNeighours(Point point) => gridEnumerator.NeighboursOf(point).Count(neighbour => this[neighbour]);

        private void UpdateCell(Point point, int neighbours)
        {
            if (neighbours < 2 || neighbours > 3) this[point] = false;
            if (neighbours == 3) this[point] = true;
        }

        private Grid NextGeneration()
        {
            var next = (Grid)this.Clone();
            foreach (var point in gridEnumerator.Points())
            {
                next.UpdateCell(point, CountOfNeighours(point));
            }
            return next;
        }

        public Grid NextGeneration(int generations = 1)
        {
            Grid grid = this;
            while (generations-- > 0) grid = grid.NextGeneration();
            return grid;
        }

        private static char ToChar(bool cell) => cell ? 'O' : '.';

        public override string ToString()
        {
            var lines = cells.Select(ToChar).Chunk(Size.Width).Select(chars => new string(chars));
            return string.Join(Environment.NewLine, lines);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return this.ToString() == obj.ToString();
        }
    }
}
