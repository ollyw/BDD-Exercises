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
            CurrentPage = this;
        }

        protected IWebDriver Driver
        {
            get
            {
                return ScenarioContext.Current.Get<IWebDriver>();
            }
        }

        public static WebDriverPageBase CurrentPage
        {
            get
            {
                return ScenarioContext.Current.Get<WebDriverPageBase>();
            }
            private set
            {
                ScenarioContext.Current.Set<WebDriverPageBase>(value);
            }
        }
    }
}
