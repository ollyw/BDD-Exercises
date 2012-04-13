using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PaperStoneScissors.Test.PageObjects
{
    public class GameResultsPage : WebDriverPageBase
    {
        [FindsBy(How = How.CssSelector, Using = "tbody tr:first-child td:nth-child(2)")]
        private IWebElement WinnerTableRow { get; set; }

        public string WinnerName {
            get
            {
                return WinnerTableRow.Text;
            }
        }
    }
}
