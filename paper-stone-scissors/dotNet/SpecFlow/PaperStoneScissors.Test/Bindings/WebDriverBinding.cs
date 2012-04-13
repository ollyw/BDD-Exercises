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
        IWebDriver webdriver;

        [BeforeScenario("web")]
        public void Initialize()
        {
            var assemblyPath = new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location);
            var driverPath = @"C:\Users\valtechuk\Documents\BDD-examples\paper-stone-scissors\dotNet\SpecFlow\lib\Webdriver";

            webdriver = new ChromeDriver(driverPath, new ChromeOptions(), TimeSpan.FromSeconds(10));
        }

        [AfterScenario("web")]
        public void Cleanup()
        {
            try
            {
                webdriver.Close();
            }
            catch
            {
                // TODO: add some logging
                webdriver.Dispose();
            }
        }
    }
}
