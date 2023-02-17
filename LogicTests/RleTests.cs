namespace LogicTests
{
    [TestClass]
    public class RleTests
    {
        [TestMethod]
        public void Size_be_loaded_from_an_RLE_header()
        {
            const string rle = "x = 3, y = 5";

            var grid = GridBuilder.FromRleString(rle);

            grid.Size.Width.Should().Be(3);
            grid.Size.Height.Should().Be(5);
        }

        [TestMethod]
        public void Size_be_loaded_from_an_RLE_header_ignoring_spaces()
        {
            const string rle = @" x= 3,y =5 ";

            var grid = GridBuilder.FromRleString(rle);

            grid.Size.Width.Should().Be(3);
            grid.Size.Height.Should().Be(5);
        }


        [TestMethod]
        public void Single_cells_of_b_and_o_should_be_dead_and_live()
        {
            const string rle = @"x = 1,y = 3
b$o$b!";

            var grid = GridBuilder.FromRleString(rle);

            grid[0].Should().Be(false);
            grid[1].Should().Be(true);
            grid[2].Should().Be(false);
        }

        [TestMethod]
        public void Multiple_cells_of_b_and_o_should_be_dead_and_live()
        {
            const string rle = @"x = 3, y = 3
bob$obo$boo!";

            var grid = GridBuilder.FromRleString(rle);

            grid[0].Should().Be(false);
            grid[1].Should().Be(true);
            grid[2].Should().Be(false);
            grid[3].Should().Be(true);
            grid[4].Should().Be(false);
            grid[5].Should().Be(true);
            grid[6].Should().Be(false);
            grid[7].Should().Be(true);
            grid[8].Should().Be(true);
        }

        [TestMethod]
        public void Incomplete_rows_should_be_completed_with_dead_cells()
        {
            const string rle = @"x = 3, y = 3
$o$bo!";

            var grid = GridBuilder.FromRleString(rle);

            grid[0].Should().Be(false);
            grid[1].Should().Be(false);
            grid[2].Should().Be(false);
            grid[3].Should().Be(true);
            grid[4].Should().Be(false);
            grid[5].Should().Be(false);
            grid[6].Should().Be(false);
            grid[7].Should().Be(true);
            grid[8].Should().Be(false);
        }

        [TestMethod]
        public void Number_prefixes_should_create_strings_of_cells()
        {
            const string rle = @"x = 3, y = 3
1o$2o$3o!";

            var grid = GridBuilder.FromRleString(rle);

            grid[0].Should().Be(true);
            grid[1].Should().Be(false);
            grid[2].Should().Be(false);
            grid[3].Should().Be(true);
            grid[4].Should().Be(true);
            grid[5].Should().Be(false);
            grid[6].Should().Be(true);
            grid[7].Should().Be(true);
            grid[8].Should().Be(true);
        }
   }
}