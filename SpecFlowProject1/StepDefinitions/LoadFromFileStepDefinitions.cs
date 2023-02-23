namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LoadFromFileStepDefinitions : GridScenarioContext
    {
        public LoadFromFileStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"the (.+\.rle) file")]
        public void GivenTheGlider_RleFile(string filename)
        {
            this.Grid = GridBuilder.FromRleFile(filename);
        }

        [Given(@"the (.+\.txt) file")]
        public void GivenTheGlider_TxtFile(string filename)
        {
            this.Grid = GridBuilder.FromTxtFile(filename);
        }
    }
}
