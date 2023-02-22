using GameOfLife.Parsers.Rle;
using GameOfLife.Parsers.Txt;

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
    }
}
