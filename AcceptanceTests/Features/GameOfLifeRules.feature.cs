// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GameOfLifeRulesFeature : object, Xunit.IClassFixture<GameOfLifeRulesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GameOfLifeRules.feature"
#line hidden
        
        public GameOfLifeRulesFeature(GameOfLifeRulesFeature.FixtureData fixtureData, AcceptanceTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Game of Life Rules", @"![GameOfLifeRules](./Game_of_life_glider_gun.svg)

Determine whather a cell is alive or dead after each iteration,
based on the cell's current state and the count of its living neighbours.

***Further read***: **[Learn more about Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)**", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="The rules of game of life")]
        [Xunit.TraitAttribute("FeatureTitle", "Game of Life Rules")]
        [Xunit.TraitAttribute("Description", "The rules of game of life")]
        [Xunit.TraitAttribute("Category", "rules")]
        [Xunit.InlineDataAttribute("live", "0", "dead", "lower limit", new string[0])]
        [Xunit.InlineDataAttribute("live", "1", "dead", "below threshold for life", new string[0])]
        [Xunit.InlineDataAttribute("live", "2", "live", "stable population", new string[0])]
        [Xunit.InlineDataAttribute("live", "3", "live", "stable population", new string[0])]
        [Xunit.InlineDataAttribute("live", "4", "dead", "above threshold for life", new string[0])]
        [Xunit.InlineDataAttribute("live", "8", "dead", "upper limit", new string[0])]
        [Xunit.InlineDataAttribute("dead", "0", "dead", "lower limit", new string[0])]
        [Xunit.InlineDataAttribute("dead", "2", "dead", "below threshold for life", new string[0])]
        [Xunit.InlineDataAttribute("dead", "3", "live", "perfect for new life", new string[0])]
        [Xunit.InlineDataAttribute("dead", "4", "dead", "above threshold for life", new string[0])]
        [Xunit.InlineDataAttribute("dead", "8", "dead", "upper limit", new string[0])]
        public virtual void TheRulesOfGameOfLife(string status, string neighours, string now, string notes, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "rules"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("status", status);
            argumentsOfScenario.Add("neighours", neighours);
            argumentsOfScenario.Add("now", now);
            argumentsOfScenario.Add("notes", notes);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The rules of game of life", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
 testRunner.Given(string.Format("a {0} cell with {1} neighbours", status, neighours), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 13
 testRunner.When("the next generation is calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 14
 testRunner.Then(string.Format("the cell is {0}", now), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GameOfLifeRulesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GameOfLifeRulesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
