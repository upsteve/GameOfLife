using System.Drawing;

namespace GameOfLife
{
    public class GridEnumerator
    {
        private readonly PointEnumerator points;
        private readonly NeighbourEnumerator neighbours;

        public GridEnumerator(Size size) {
            points = new PointEnumerator(size);
            neighbours = new NeighbourEnumerator(size);
        }

        public IEnumerable<Point> Points() => points.Get();
        public IEnumerable<Point> NeighboursOf(Point point) => neighbours.Of(point);
    }
}

