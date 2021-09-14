using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ReleaseToWater
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();
        
        
        
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl(" https://stirling.she-development.net/automation");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Login()
        {
            IWebElement user = driver.FindElement(By.Id("username"));
            user.SendKeys("adetonaa");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement password = driver.FindElement(By.Name("password"));
            password.SendKeys("RAN999!");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement loginBtn = driver.FindElement(By.XPath("//button[@id='login']"));
            loginBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Assert.Pass();
        }

        [Test]
        public void NavigateToEnv()
        {
            //Click Module
            IWebElement clkModule = driver.FindElement(By.XPath("//a[contains(text(),'Modules')]"));
            clkModule.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Clicks Environment
            IWebElement clkEnv = driver.FindElement(By.LinkText("Environment"));
            clkEnv.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Clicks Release to Water
            driver.FindElement(By.LinkText("Release To Water")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Click Add new record
            driver.FindElement(By.XPath("//body/div[@id='main-content']/div[@id='site-wrapper']/section[1]/a[1]")).Click();
            //this fills the description field
            driver.FindElement(By.XPath("//textarea[@id='SheReleaseToWater_Description']"))
            .SendKeys("This is just a sample description for the release of water module by Adesola ;)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //this chooses the Sample date field
            IWebElement dateRange = driver.FindElement(By.XPath("//input[@id='SheReleaseToWater_SampleDate']"));
            dateRange.SendKeys("16/09/2021");

            //Click save button and Close button
            IWebElement saveBtn = driver.FindElement(By.XPath("//button[contains(text(),'Save & Close')]"));
            saveBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);


            //Add a new record following the steps above
            driver.FindElement(By.XPath("//body/div[@id='main-content']/div[@id='site-wrapper']/section[1]/a[1]")).Click();
            //this fills the description field
            driver.FindElement(By.XPath("//textarea[@id='SheReleaseToWater_Description']"))
            .SendKeys("This is the second note about a new record just a sample description for the release of water module by Adesola");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //this chooses the Sample date field
            IWebElement dateRanges = driver.FindElement(By.XPath("//input[@id='SheReleaseToWater_SampleDate']"));
            dateRanges.SendKeys("17/09/2021");

            //Click save button and Close button
            IWebElement saveBtns = driver.FindElement(By.XPath("//button[contains(text(),'Save & Close')]"));
            saveBtns.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            //using cog delete the first record created earlier
            driver.FindElement(By.XPath("//body[1]/div[1]/div[3]/section[1]/div[4]/div[2]/div[3]/div[2]/button[1]")).Click();
            driver.FindElement(By.XPath("//body[1]/div[1]/div[3]/section[1]/div[4]/div[2]/div[3]/div[2]/ul[1]/li[4]/a[1]")).Click();
            driver.FindElement(By.XPath("//body[1]/div[17]/div[3]/div[1]/button[1]")).Click();
            //verify record has been deleted
            driver.PageSource.Contains("529");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);


            driver.Quit();
        }

        


    }
}