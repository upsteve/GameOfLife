using GameOfLife.Enumerators;

namespace SpecFlowProject1.StepDefinitions
{
    public static class TestGrid
    {
        public static Grid BuildWithNeighbours(Size size, Point centre, bool status, int count)
        {
            var grid = new Grid(size, Generator.Default(size));
            foreach (var neighbour in new NeighbourEnumerator(grid.Size).Of(centre).Take(count)) grid[neighbour] = true;
            grid[centre] = status;
            return grid;
        }
    }
}
