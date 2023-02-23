namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class CalculateGenerationsStepDefinitions : GridScenarioContext
    {
        public CalculateGenerationsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [When(@"the next (.*) generations are calculated")]
        public void WhenTheNextGenerationsAreCalculated(int generations)
        {
            this.Grid = this.Grid.NextGeneration(generations);
        }
    }
}
