namespace GameOfLife
{
    interface IGridParser
    {
        Grid FromString(string value);
    }
}
