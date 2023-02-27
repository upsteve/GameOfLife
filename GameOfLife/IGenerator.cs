namespace GameOfLife
{
    public interface IGenerator
    {
        public Grid Next(Grid seed);
    }
}
