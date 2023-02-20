using System.Drawing;

namespace GameOfLife
{
    public class GridEnumerator
    {
        private static readonly Size[] neighbourOffsets = {
            new(-1, -1), new(0, -1), new(1, -1), new(-1, 0),
            new(1, 0), new(-1, 1), new(0, 1), new(1, 1) };

        private Size size;

        public GridEnumerator(Size size) { this.size = size; }

        private bool InRange(Point point) => point.X >= 0 && point.X < size.Width
            && point.Y >= 0 && point.Y < size.Height;

        public IEnumerable<Point> Neighbours(Point point)
        {
            foreach (var offset in neighbourOffsets)
            {
                var next = Point.Add(point, offset);
                if (InRange(next)) yield return next;
            }
            yield break;
        }

        public IEnumerable<Point> Points()
        {
            for (var y = 0; y < size.Height; y++)
            {
                for (var x = 0; x < size.Width; x++)
                {
                    yield return new Point(x, y);
                }
            }
            yield break;
        }
    }
}

