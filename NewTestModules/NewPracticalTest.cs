namespace Day2AutomationTest.NewTestModules
{
    public class NewPracticalTest : BasePage
    { 
        //Inhemritance 
        //Creating the object of the class
        //Dependency injection during Page Object Model (POM)
    
        [Test]
        public void NewPracticalTest01() 
        {
            //Inhemritance example below
            //Actions Example
            var inputElements = driver.FindElements(By.XPath("//input"));
            Actions action = new Actions(driver); //Object of Ijavascript
            action.Click(inputElements[4]).Build().Perform();
            action.Click(inputElements[6]).Perform();

            var firstName = driver.FindElement(By.CssSelector("input[ng-model=\"FirstName\"]"));

            Actions actions = new Actions(driver);
            action
                .Click(firstName)
                .SendKeys("Frankie Frankies")
                .Build()
                .Perform();

            Thread.Sleep(5000);
            driver.Quit();
        }
    }

    public class NewPracticalTest2 
    {
        [Test]
        public void NewPracticalTest001()
        {
            //Creating object of basepage class example below
            BasePage basePage = new BasePage();
            basePage.Start();

            var inputElements = basePage.driver.FindElements(By.XPath("//input"));
            Actions action = new Actions(basePage.driver); //Object of Ijavascript
            action.Click(inputElements[5]).Build().Perform();
            action.Click(inputElements[8]).Perform();

            var firstName = basePage.driver.FindElement(
                By.CssSelector("input[ng-model=\"FirstName\"]"));

            Actions actions = new Actions(basePage.driver);
            action
                .Click(firstName)
                .SendKeys("Frankie Frankies")
                .Build()
                .Perform();

            Thread.Sleep(5000);
            basePage.End();
        }
    }

}
