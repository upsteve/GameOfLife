using System.Drawing;

namespace GameOfLife.CellEnumeration
{
    public class GridEnumerator : IGridEnumerator
    {
        private readonly PointEnumerator points;
        private readonly NeighbourEnumerator neighbours;

        public GridEnumerator(Size size)
        {
            points = new PointEnumerator(size);
            neighbours = new NeighbourEnumerator(size);
        }

        public IEnumerable<Point> NeighboursOf(Point point) => neighbours.Of(point);
        public IEnumerable<Point> Points() => points.Get();
    }
}

