using System.Drawing;

namespace GameOfLife.CellEnumeration
{
    public interface IGridEnumerator
    {
        public IEnumerable<Point> NeighboursOf(Point point);
        public IEnumerable<Point> Points();
    }
}

