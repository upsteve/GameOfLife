using GameOfLife;

// Note the grid is not infinite, so gliders get stuck on the boundary and stop the gun from repeating.
var grid = GridBuilder.FromRleFile("gosper.rle");
var generations = 31;

while (generations-- > 0)
{
    Console.WriteLine(grid);
    Console.WriteLine();
    grid = grid.NextGeneration();
}

Console.ReadLine();