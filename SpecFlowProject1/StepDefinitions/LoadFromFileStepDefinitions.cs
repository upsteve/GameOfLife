namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LoadFromFileStepDefinitions : GridScenarioContext
    {
        public LoadFromFileStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"the (.+\.rle) file")]
        public void GivenTheGlider_RleFile(string filename)
        {
            Grid = GridBuilder.FromRleFile(filename);
        }

        [Given(@"the (.+\.txt) file")]
        public void GivenTheGlider_TxtFile(string filename)
        {
            Grid = GridBuilder.FromTxtFile(filename);
        }
    }
}
