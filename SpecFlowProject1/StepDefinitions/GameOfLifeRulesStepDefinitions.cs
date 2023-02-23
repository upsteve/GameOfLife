namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class GameOfLifeRulesStepDefinitions : GridScenarioContext
    {
        public GameOfLifeRulesStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"a (.*) cell with (.*) neighbours")]
        public void GivenAStatusCellWithNeighoursNeighbours(string status, int neighbours)
        {
            Grid = TestGrid.BuildWithNeighbours(status == "live", neighbours);
        }

        [When(@"the next generation is calculated")]
        public void WhenTheNextGenerationIsCalculated()
        {
            Grid = Grid.NextGeneration();
        }

        [Then(@"the cell is (.*)")]
        public void ThenTheCellIsNow(string now)
        {
            Grid[TestGrid.Centre].Should().Be(now == "live");
        }
    }
}
