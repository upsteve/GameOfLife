namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class GridScenarioStepDefinitions : GridScenarioContext
    {
        protected GridScenarioStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"an initial grid of")]
        public void GivenAnInitialGridOf(Table table)
        {
            var plainText = ConvertTableToString(table);
            this.Grid = GridBuilder.FromString(plainText);
        }

        [Then(@"the grid is")]
        public void ThenTheGridIs(Table table)
        {
            var plainText = ConvertTableToString(table);
            var expectedGrid = GridBuilder.FromString(plainText);
            this.Grid.Should().Be(expectedGrid);
        }
    }
}
