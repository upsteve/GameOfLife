namespace GameOfLife.Parsers.Rle
{
    public static class RleTag
    {
        private static bool GetCell(string tag) => tag.Last() == 'o';

        private static string TrimCell(string tag) => tag.TrimEnd(new char[] { 'b', 'o' });

        private static int GetCount(string tag) => tag.Length > 1 ? Convert.ToInt32(TrimCell(tag)) : 1;

        public static IEnumerable<bool> ConvertToCells(string tag) => Enumerable.Repeat(GetCell(tag), GetCount(tag));
    }
}