﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.17379
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PaperStoneScissors.Test.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [MbUnit.Framework.TestFixtureAttribute()]
    [MbUnit.Framework.DescriptionAttribute("In order enjoy a game of paper stone scissors\r\nAs a loner\r\nI want to be able to p" +
        "lay against the computer")]
    public partial class SinglePlayerAgainstTheComputerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SinglePlayer.feature"
#line hidden
        
        [MbUnit.Framework.FixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Single Player against the computer", "In order enjoy a game of paper stone scissors\r\nAs a loner\r\nI want to be able to p" +
                    "lay against the computer", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [MbUnit.Framework.FixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [MbUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [MbUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [MbUnit.Framework.TestAttribute()]
        [MbUnit.Framework.DescriptionAttribute("Single player game")]
        [MbUnit.Framework.CategoryAttribute("web")]
        public virtual void SinglePlayerGame()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Single player game", new string[] {
                        "web"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I choose a single player first to 3 game");
#line 12
 testRunner.When("I make 3 choices");
#line 13
 testRunner.Then("the web game should be complete");
#line 14
 testRunner.And("I should see the winner of the game");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
