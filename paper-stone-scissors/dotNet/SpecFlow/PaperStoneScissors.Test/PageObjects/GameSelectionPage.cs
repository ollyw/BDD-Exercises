using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace PaperStoneScissors.Test.PageObjects
{
    public class GameSelectionPage : WebDriverPageBase
    {
        [FindsBy(How = How.Name, Using = "playerName")]
        private IWebElement NumberOfGamesTextbox { get; set; }

        public void SetNumberOfGames(int i)
        {
            NumberOfGamesTextbox.SendKeys("1");
        }

        public RoundSelectionPage Submit()
        {
            NumberOfGamesTextbox.Submit();
            return new RoundSelectionPage();
        }
    }
}
