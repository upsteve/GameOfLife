using System.Drawing;

namespace GameOfLife
{
    public class Grid
    {
        public Size Size { get; }
        private readonly bool[] cells;
        private readonly IGenerator generator;

        public Grid(int width, int height, bool[]? cells = null, IGenerator? generator = null)
        {
            Size = new Size(width, height);
            this.cells = cells ?? new bool[width * height];
            this.generator = generator ?? Generator.Default(Size);
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

        public Grid NextGeneration(int generations = 1)
        {
            Grid grid = this;
            while (generations-- > 0) grid = generator.Next(grid);
            return grid;
        }

        public override string ToString() => GridSerializer.ToString(cells, Size.Width);

        public override bool Equals(object? obj) => obj?.ToString() == ToString();
    }
}
