using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace PaperStoneScissors.Test
{
    /// <summary>
    /// To use this binding, you must download the ChromeDriver from http://code.google.com/p/chromedriver/downloads/list
    /// </summary>
    [Binding]
    public class WebDriverBinding
    {
        IWebDriver WebDriver
        {
            get
            {
                return ScenarioContext.Current.Get<IWebDriver>();
            }
            set
            {
                ScenarioContext.Current.Set<IWebDriver>(value);
            }
        }

        [BeforeScenario("web")]
        public void Initialize()
        {
            var assemblyPath = new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location);
            var driverPath = @"C:\Users\valtechuk\Documents\BDD-examples\paper-stone-scissors\dotNet\SpecFlow\lib\Webdriver";

            WebDriver = new ChromeDriver(driverPath, new ChromeOptions(), TimeSpan.FromSeconds(10));
            WebDriver.Url = "http://localhost/PaperStoneScissors.Web";
            WebDriver.Navigate();
        }

        [AfterScenario("web")]
        public void Cleanup()
        {
            try
            {
                WebDriver.Close();
            }
            catch
            {
                // TODO: add some logging
                WebDriver.Dispose();
            }
        }
    }
}
