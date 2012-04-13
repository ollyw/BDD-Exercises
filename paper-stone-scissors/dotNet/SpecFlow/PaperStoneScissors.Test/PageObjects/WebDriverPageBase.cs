using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace PaperStoneScissors.Test.PageObjects
{
    public class WebDriverPageBase
    {
        public WebDriverPageBase()
        {
            PageFactory.InitElements(Driver, this);
        }

        protected IWebDriver Driver
        {
            get
            {
                return ScenarioContext.Current.Get<IWebDriver>();
            }
        }
    }
}
