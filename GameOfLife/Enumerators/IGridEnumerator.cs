using System.Drawing;

namespace GameOfLife.Enumerators
{
    public interface IGridEnumerator
    {
        public IEnumerable<Point> NeighboursOf(Point point);
        public IEnumerable<Point> Points();
    }
}

