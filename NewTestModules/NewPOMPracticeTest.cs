using Day2AutomationTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2AutomationTest.NewTestModules
{
    public class NewPOMPracticeTest : BasePage
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private new IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        HomePage homePage;
        ContactUsPage contactUsPage;
        GetIntouchPage getIntouchPage;

        public NewPOMPracticeTest()
        {
            driver = InitialisedDriver();
            homePage = new HomePage(driver);
            contactUsPage = new ContactUsPage(driver);  
            getIntouchPage = new GetIntouchPage(driver);
        }

        [Test]

        public void POMTest3()
        {
            homePage.NavigateToHomePage();
            driver.FindElement(By.CssSelector(".fc-button-label")).Click();

            homePage.ClickContactUs();

            contactUsPage.FillContactUsForm("Frank", "frank@abc.com", "Delivery feedback", "Your parcel is ready for pickup");

            Assert.That(getIntouchPage.IsSuccessMsgDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit(); // Close the browser
                driver.Dispose(); // Dispose of the driver
                driver = null; // Set the driver to null
            }
        }
    }
}
