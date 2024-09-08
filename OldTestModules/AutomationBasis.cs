using Day2AutomationTest.PageObjects;
using Day2AutomationTest.UsefulMethods;
using OpenQA.Selenium.DevTools.V125.ServiceWorker;
using SeleniumExtras.WaitHelpers;
using System.ComponentModel.DataAnnotations;

namespace Day2AutomationTest.TestModules
{
    public class AutomationBasis : BasePage
    {
        //PART OF GLOBALISATION FOLLOWUP CODE BELOW 
        //ALTERNATIVE DOB OPTION (GLOBALISATION)
        SelectElement selectdropdown(IWebElement elem) =>
                new SelectElement(elem);


        [Test]
        public void TestAutomation101()
        {
            //var myurl = driver.Url;

            //Assert.That(driver.Url, Is.EqualTo(Environments.AutomationUrl));
            //Console.WriteLine(driver.Title);

            Assert.That(driver.Url, Is.EqualTo(Environments.AutomationUrl));
            driver.Url.Should().Be(Environments.AutomationUrl);
            Console.WriteLine(driver.Title);
            driver.FindElement(
                By.XPath("//label[text()='Password']//following-sibling::div/input")).SendKeys("password");

            var password = driver.FindElement(By.Id("firstpassword"));
            password.SendKeys("Password");

            var InputFields = driver.FindElements(By.TagName("input"));
            IWebElement result(int num) => InputFields.Count() > 1
                ? InputFields[num]
                : throw new Exception("Element count is less");
            result(0).SendKeys("Frank");
            result(1).SendKeys("Eronmo");

            Thread.Sleep(5000);
            driver.Quit();

            ////Single line of code to click the consent button Xpath
            //driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
            //driver.FindElement(By.CssSelector("button.fc-button.fc-cta-consent.fc-primary-button")).Click();

        }

        //DATA DRIVEN TESTCASE EXAMPLE
        //[Test, TestCaseSource(nameof(TestCaseData))]
        [Test, TestCaseSource(typeof(BasePage), "MyTestData")]

        public void TestAutomation102(string fname, string lname, string add, string mobile)
        {
            driver.Navigate().GoToUrl(Environments.AutomationUrl);
            var firstName = driver.FindElement(By.CssSelector("input[ng-model=\"FirstName\"]"));
            firstName.SendKeys(fname);

            var lastName = driver.FindElement(By.XPath("//*[@id=\"basicBootstrapForm\"]/div[1]/div[2]/input"));
            lastName.SendKeys(lname);

            var address = driver.FindElement(By.XPath("//textarea[contains(@class, 'form-control')]"));
            address.SendKeys(add);

            driver.FindElements(By.TagName("input"))[2].
                SendKeys("myemail@gmail.com");

            var phoneno = driver.FindElement(By.XPath("//input[@type='tel']"));
            phoneno.SendKeys(mobile);

            var inputElements = driver.FindElements(By.XPath("//input"));
            inputElements[5].Click();
            inputElements[6].Click();
            inputElements[7].Click();
            inputElements[8].Click();

            var year = driver.FindElement(By.Id("yearbox")); // Combined dropdown code
            selectdropdown(year).SelectByIndex(2); // Adjusted to 2 lines by combining and omitting braces

            var month = driver.FindElement(By.CssSelector("[ng-model='monthbox']"));
            selectdropdown(month).SelectByIndex(4); // Still concise and fits within the line constraints

            var day = driver.FindElement(By.Id("daybox"));
            selectdropdown(day).SelectByIndex(6);

            var password = driver.FindElement(By.Id("firstpassword"));
            password.SendKeys("Password");
            var cpassword = driver.FindElement(By.Id("secondpassword"));
            cpassword.SendKeys("Password");
            Thread.Sleep(5000);
            driver.Quit();
        }

        //[Test]
        //public void IJavaScriptExamples()
        //{
        //    //Javascript example
        //    var inputElements = driver.FindElements(By.XPath("//input"));
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver; //Object of Ijavascript
        //    js.ExecuteScript("arguments[0].click()", inputElements[5]);
        //    js.ExecuteScript("arguments[0].click()", inputElements[8]);

        //    var firstName = driver.FindElement(By.CssSelector("input[ng-model=\"FirstName\"]"));
        //    firstName.SendKeys("Dr Sele");

        //    var lastName = driver.FindElement(By.CssSelector("input[ng-model=\"LastName\"]"));
        //    lastName.SendKeys("Eronmo");

        //    Thread.Sleep(5000);
        //    driver.Quit();
        //}

        [Test]
        public void IjavaScriptActionsExample()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Environments.AutomationUrl);
            driver.FindElement(By.CssSelector("button.fc-button.fc-cta-consent.fc-primary-button")).Click();

            //JAVASCRIPT EXAMPLE
            var inputElements = driver.FindElements(By.XPath("//input"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; //Object of Ijavascript
            js.ExecuteScript("arguments[0].click()", inputElements[5]);
            js.ExecuteScript("arguments[0].click()", inputElements[6]);
            js.ExecuteScript("arguments[0].click()", inputElements[7]);
            js.ExecuteScript("arguments[0].click()", inputElements[8]);

            var firstName = driver.FindElement(By.CssSelector("input[ng-model=\"FirstName\"]"));
            js.ExecuteScript("arguments[0].value = 'Mr Frank'", firstName);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]

        public void ActionsExample()
        {
            //ACTIONS EXAMPLE
            var inputElements = driver.FindElements(By.XPath("//input"));
            Actions action = new Actions(driver); //Object of Ijavascript
            action.Click(inputElements[4]).Perform();
            action.Click(inputElements[8]).Perform();

            var firstName = driver.FindElement(
                By.CssSelector("input[ng-model='FirstName']"));

            action
                .Click(firstName)
                .SendKeys("Frank")
                .Build()
                .Perform();

            var year = driver.FindElement(By.Id("yearbox"));
            var month = driver.FindElement(By.CssSelector("[ng-model='monthbox']"));
            var day = driver.FindElement(By.Id("daybox"));

            selectdropdown(year).SelectByIndex(1);
            selectdropdown(month).SelectByIndex(1);
            selectdropdown(day).SelectByIndex(1);

            var headerTxt = driver.FindElement(By.XPath("//h2")).Text;
            Console.WriteLine(headerTxt);
            Assert.That(headerTxt, Is. EqualTo("Register"));
            var image = driver.FindElement(By.CssSelector("#imagesrc"));
            var filePath = Directory.GetCurrentDirectory() + "\\TextData\\TrainingTextFile.txt";

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void SwitchTabTest()
        {
            //SWITCH TAB ETC
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Environments.DemoqaUrl);

            var tabs = driver.WindowHandles;
            driver.FindElement(By.Id("tabButton")).Click();
            var tab = driver.WindowHandles;
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Console.WriteLine(driver.FindElement(By.Id("sampleHeading")).Text);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.Id("windowButton")).Click();

            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void CrossBrowserTest()
        {
            driver.Navigate().GoToUrl(Environments.AutomationUrl);
            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void ImplicitAndExplicitWaitTest()
        {
            // IMPLICIT AND EXPLICIT WAIT
            driver.Navigate().GoToUrl(Environments.DemoqaUrlAlertPage);
            driver.FindElement(By.Id("timerAlertButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Id("confirmButton")).Click();
            //driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Dismiss();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("confirmResult")));
            Console.WriteLine(driver.FindElement(By.Id("confirmResult")).Text);
        }

        [Test]
        public void ExplicitWaitTestRefactored()
        {
            // EXPLICIT WAIT REFACTORED
            driver.Navigate().GoToUrl(Environments.DemoqaUrlAlertPage);
            driver.FindElement(By.Id("timerAlertButton")).Click();
            CustomMethods custom = new CustomMethods();
            custom.WaitForAlertBy(driver);
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Id("confirmButton")).Click();
            driver.SwitchTo().Alert().Dismiss();
            custom.WaitForElementBy(driver, By.Id("confirmResult"));
            Console.WriteLine(driver.FindElement(By.Id("confirmResult")).Text);
        }

        //CUSTOM METHODS
        //CUSTOM STATEMENTS

        //PAGE OBJECT(DIFFERENT TYPES/ DIFFERENT STRATEGIES)
        [Test]
        public void POMTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            driver.FindElement(
                By.CssSelector(".fc-button-label")).Click();

            homePage.ClickContactUs();

            ContactUsPage contactUsPage = new ContactUsPage(driver);
            contactUsPage.FillContactUsForm("Frank", "frank@abc.com", "Delivery feedback",
                "Your parcel is ready for pickup");

            GetIntouchPage getIntouchPage = new GetIntouchPage(driver);
            Assert.That(getIntouchPage.IsSuccessMsgDisplayed());
        }

        [Test]
        public void POMTest2()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            driver.FindElement(
                By.CssSelector(".fc-button-label")).Click();

            ContactUsPage contactUsPage = homePage.ClickContactUs();

            GetIntouchPage getIntouchPage = contactUsPage.FillContactUsForm("Frank", "frank@abc.com", "Delivery feedback",
                "Your parcel is ready for pickup");

            Assert.That(getIntouchPage.IsSuccessMsgDisplayed());
        }
        //GIT
    }

}
