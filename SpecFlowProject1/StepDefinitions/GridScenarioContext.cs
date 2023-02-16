using System.Text;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class GridScenarioContext
    {
        private readonly ScenarioContext scenarioContext;

        protected Grid Grid
        {
            get => scenarioContext.Get<Grid>("grid");
            set => scenarioContext["grid"] = value;
        }

        protected GridScenarioContext(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        protected static string ConvertTableToString(Table table)
        {
            var sb = new StringBuilder();
            foreach (var row in table.Rows)
            {
                sb.AppendLine(row.Values.First());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
