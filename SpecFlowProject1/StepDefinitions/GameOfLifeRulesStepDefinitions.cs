namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class GameOfLifeRulesStepDefinitions : GridScenarioContext
    {
        private Point centre = new(1, 1);

        public GameOfLifeRulesStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"a (.*) cell with (.*) neighbours")]
        public void GivenAStatusCellWithNeighoursNeighbours(string status, int neighbours)
        {
            Grid = TestGrid.BuildWithNeighbours(new Size(3, 3), centre, status == "live", neighbours);
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
