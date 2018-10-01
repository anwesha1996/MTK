using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.flipkart.com/?affid=shoppakka");
            webDriver.Manage().Window.Maximize();
            // Thread.Sleep(5000);
            //webDriver.FindElement(By.XPath("//*[@id='lst - ib']"));
            // webDriver.FindElement(By.Id("lst - ib")).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/button")).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            webDriver.FindElement(By.XPath("//*[@id='container']/div/header/div[1]/div/div/div/div[1]/form/div/div[1]/div/input")).SendKeys("Apple");
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            webDriver.FindElement(By.XPath("//button[@class='vh79eN']")).Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            webDriver.FindElement(By.XPath("//*[@id='container']/div/div[1]/div/div[2]/div/div[2]/div/div[3]/div[1]/div/div[1]/div/a/div[3]/div[1]/div[1]")).Click();
            webDriver.Quit();
        }
    }
}
