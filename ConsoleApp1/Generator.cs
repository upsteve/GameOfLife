using GameOfLife.CellEnumeration;
using System.Data;
using System.Drawing;

namespace GameOfLife
{
    public class Generator : IGenerator
    {
        private readonly IGridEnumerator gridEnumerator;

        public Generator(IGridEnumerator gridEnumerator)
        {
            this.gridEnumerator = gridEnumerator;
        }

        private bool IsAlive(Grid seed, Point point)
        {
            var neighbours = gridEnumerator.NeighboursOf(point).Count(neighbour => seed[neighbour]);
            return seed[point] ? neighbours == 2 || neighbours == 3 : neighbours == 3;
        }

        public Grid Next(Grid seed)
        {
            var next = new Grid(seed.Size.Width, seed.Size.Height, generator: this);
            foreach (var point in gridEnumerator.Points().Where(point => IsAlive(seed, point)))
            {
                next[point] = true;
            }
            return next;
        }

        public static IGenerator Default(Size size) => new Generator(new GridEnumerator(size));
    }
}
