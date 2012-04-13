using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace PaperStoneScissors.Test.PageObjects
{
    public class RoundSelectionPage : WebDriverPageBase
    {
        [FindsBy(How = How.Id, Using = "paper")]
        private IWebElement PaperInput { get; set; }

        [FindsBy(How = How.Id, Using = "stone")]
        private IWebElement StoneInput { get; set; }

        [FindsBy(How = How.Id, Using = "scissors")]
        private IWebElement ScissorsInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form")]
        private IWebElement Form { get; set; }

        public void SelectPaper()
        {
            PaperInput.Click();
        }

        public void SelectStone()
        {
            StoneInput.Click();
        }

        public void SelectScissors()
        {
            ScissorsInput.Click();
        }

        public RoundResultsPage Submit()
        {
            Form.Submit();
            return new RoundResultsPage();
        }
    }
}
