using System.Drawing;

namespace GameOfLife.Enumerators
{
    public class NeighbourEnumerator
    {
        private static readonly Size[] neighbourOffsets = { new(-1, -1), new(0, -1), new(1, -1), new(-1, 0), new(1, 0), new(-1, 1), new(0, 1), new(1, 1) };
        private Size size;

        public NeighbourEnumerator(Size size) { this.size = size; }

        private bool InRange(Point point) => point.X >= 0 && point.X < size.Width && point.Y >= 0 && point.Y < size.Height;

        public IEnumerable<Point> Of(Point point)
        {
            foreach (var offset in neighbourOffsets)
            {
                var next = Point.Add(point, offset);
                if (InRange(next)) yield return next;
            }
        }
    }
}

