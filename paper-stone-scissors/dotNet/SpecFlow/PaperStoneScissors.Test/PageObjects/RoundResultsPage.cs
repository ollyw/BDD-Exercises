using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PaperStoneScissors.Test.PageObjects
{
    public class RoundResultsPage : WebDriverPageBase
    {
        [FindsBy(How = How.CssSelector, Using = "a")]
        private IWebElement ContinueButton { get; set; }

        public RoundSelectionPage Continue()
        {
            ContinueButton.Click();
            return new RoundSelectionPage();
        }
    }
}
