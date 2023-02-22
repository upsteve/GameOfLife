namespace GameOfLife.Parsers
{
    interface IGridParser
    {
        Grid FromString(string value);
    }
}
