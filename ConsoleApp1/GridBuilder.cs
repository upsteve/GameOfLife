using GameOfLife.Parsers.Rle;
using GameOfLife.Parsers.Txt;
using System.Drawing;

namespace GameOfLife
{
    public static class GridBuilder
    {
        public static Grid FromString(string plainText)
        {
            return new TxtParser().FromString(plainText);
        }

        public static Grid FromTxtFile(string filename)
        {
            var contents = File.ReadAllText(filename);
            return FromString(contents);
        }

        public static Grid FromRleString(string rle)
        {
            return new RleParser().FromString(rle);
        }

        public static Grid FromRleFile(string filename)
        {
            var contents = File.ReadAllText(filename);
            return FromRleString(contents);
        }

        public static Grid FromDimensions(int width, int height)
        {
            Size size = new(width, height);
            return new Grid(size, Generator.Default(size));
        }

        public static Grid FromSizeWithCells(Size size, bool[] cells)
        {
            return new Grid(size, Generator.Default(size), cells);
        }

        public static Grid FromSizeWithGenerator(Size size, IGenerator generator)
        {
            return new Grid(size, generator);
        }
    }
}
