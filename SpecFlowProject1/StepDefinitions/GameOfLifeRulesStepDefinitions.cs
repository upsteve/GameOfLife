using System.Drawing;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class GameOfLifeRulesStepDefinitions : GridScenarioContext
    {
        private readonly int centre = 4;
        private readonly int[] neighbourOffsets = { 0, 1, 2, 3, 5, 6, 7, 8 };

        public GameOfLifeRulesStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"a (.*) cell with (.*) neighbours")]
        public void GivenAStatusCellWithNeighoursNeighbours(string status, int neighbours)
        {
            var size = new Size(3, 3);
            Grid = new Grid(size, Generator.Default(size));
            for (int i = 0; i < neighbours; i++)
            {
                Grid[neighbourOffsets[i]] = true;
            }
            Grid[centre] = status == "live";
        }

        [When(@"the next generation is calculated")]
        public void WhenTheNextGenerationIsCalculated()
        {
            Grid = Grid.NextGeneration();
        }

        [Then(@"the cell is (.*)")]
        public void ThenTheCellIsNow(string now)
        {
            Grid[centre].Should().Be(now == "live");
        }
    }
}
