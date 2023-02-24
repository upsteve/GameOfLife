using GameOfLife.Enumerators;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace SpecFlowProject1.StepDefinitions
{
    public static class TestGrid
    {
        public static Grid BuildWithNeighbours(Size size, Point point, bool status, int count)
        {
            var grid = new Grid(size, Generator.Default(size));
            foreach (var neighbour in new NeighbourEnumerator(grid.Size).Of(point).Take(count)) grid[neighbour] = true;
            grid[point] = status;
            return grid;
        }
    }
}
