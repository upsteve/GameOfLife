using System.Drawing;

namespace GameOfLife.CellEnumeration
{
    public class PointEnumerator
    {
        private Size size;

        public PointEnumerator(Size size) { this.size = size; }

        public IEnumerable<Point> Get()
        {
            for (var y = 0; y < size.Height; y++)
            {
                for (var x = 0; x < size.Width; x++)
                {
                    yield return new Point(x, y);
                }
            }
        }
    }
}

