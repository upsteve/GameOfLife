using System.Drawing;

namespace SpecFlowProject1.StepDefinitions
{
    public static class TestGrid
    {
        private static Size size = new(3, 3);
        public static readonly int Centre = 4;
        private static readonly int[] neighbourOffsets = { 0, 1, 2, 3, 5, 6, 7, 8 };

        public static Grid BuildWithNeighbours(bool status, int neighbours)
        {
            var grid = new Grid(size, Generator.Default(size));
            for (int i = 0; i < neighbours; i++) grid[neighbourOffsets[i]] = true;
            grid[Centre] = status;
            return grid;
        }
    }
}
