using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UmbracoMVC.Tests.SeleniumTests
{
    [TestClass]
    public class SeleniumTest1
    {
        IWebDriver driver;
        [TestInitialize]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\3rdparty");
        }

        [TestMethod]
        public void TestSubmitContact()
        {
            driver.Url = "http://umbraco.vs";
            driver.Manage().Window.Maximize();

            IWebElement contactLink = driver.FindElement(By.XPath("//*[@id='top-menu']/li[3]/a"));
            contactLink.Click();

            IWebElement nameTextBox = driver.FindElement(By.XPath("//*[@id='Name']"));
            nameTextBox.SendKeys("hoàng tâm");
            IWebElement emailTextBox = driver.FindElement(By.XPath("//*[@id='Email']"));
            emailTextBox.SendKeys("hoangtam@gmail.com");
            IWebElement subjectTextBox = driver.FindElement(By.XPath("//*[@id='Subject']"));
            subjectTextBox.SendKeys("Mong muốn hợp tác làm ăn lớn cùng quý công ty");
            IWebElement messageTextBox = driver.FindElement(By.XPath("//*[@id='Message']"));
            messageTextBox.SendKeys("Hãy liên hệ email của tôi để biết thêm chi tiết");

            //IWebElement submitBtn = driver.FindElement(By.XPath("//*[@id='mu-contact']/div/div/div/div/div[2]/div/div[1]/div/form/div/p[5]/input"));
            //submitBtn.Click();
            //IWebElement successMessageContainer = driver.FindElement(By.XPath("//*[@id='mu-contact']/div/div/div/div/div[2]/div/div[1]/div"));
            //Assert.IsTrue(successMessageContainer.Text.Contains("SuccessPublish"));
        }

        [TestMethod]
        public void TestSearchPublishItemByKeyWord()
        {
            driver.Url = "http://umbraco.vs";
        }

        [TestMethod]
        public void TestSearchUnPublishItemByKeyWord()
        {
            driver.Url = "http://umbraco.vs";
        }

        [TestMethod]
        public void TestDateFormat()
        {
            driver.Url = "http://umbraco.vs";
        }

        [TestMethod]
        public void TestThumbnailDimension()
        {
            driver.Url = "http://umbraco.vs";
        }

        [TestCleanup]
        public void closeBrowser()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
