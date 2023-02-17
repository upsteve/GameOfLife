namespace GameOfLife
{
    public static class PadEnumerableExtension
    {
        public static IEnumerable<T> Pad<T>(this IEnumerable<T> source, int count, T value)
        {
            var enumerator = source.GetEnumerator();
            while (count-- > 0) yield return enumerator.MoveNext() ? enumerator.Current : value;
            yield break;
        }
    }
}
