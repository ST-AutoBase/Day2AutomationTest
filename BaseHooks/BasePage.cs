using OpenQA.Selenium.Chromium;
using System.Security.Cryptography.X509Certificates;

namespace Day2AutomationTest.BaseHooks
{
    public enum Btype
    {
        Chrome,
        Firefox,
        Edge,
        Chromium
    }
    public class BasePage
    {
        // DECLARE THE DRIVER AS NULLABLE TO AVOID CS8618 WARNING
        public IWebDriver? driver;

        [SetUp] // Alternative SetUp
        public void Start()
        {
            //ChooseWithTanery(Btype.Chromium, getChromiumOptions());

            //ChooseWithTanery(Btype.Chromium,getChromiumOptions());

            //ChooseWithSwitch(Btype.Chromium, getChromiumOptions());

            // BELOW CODE RESOLVED ERROR ISSUE
            ChooseDriver("FireFox");  // Or "Chrome", "Edge" based on your preference

            driver = InitialisedDriver();
            
            //driver.Navigate().GoToUrl(Environments.AutomationUrl);

        }

        public void ChooseWithTanery(Btype browserType,
            ChromeOptions? coption = null,
            FirefoxOptions? foptions = null,
            EdgeOptions? eoptions = null)
        {
            var browsers = browserType == Btype.Chrome
                ? driver = new ChromeDriver(coption)
                : browserType == Btype.Firefox
                ? driver = new FirefoxDriver(foptions)
                : browserType == Btype.Edge
                ? driver = new EdgeDriver(eoptions)
                : browserType == Btype.Chromium
                ? driver = new ChromeDriver(coption)
                : throw new NoSuchDriverException("Check browser exist");
        }

        public IWebDriver ChooseWithSwitch(Btype type,
            ChromeOptions? coption = null,
            FirefoxOptions? foptions = null,
            EdgeOptions? eoptions = null
            ) => type switch
            {
                Btype.Chrome => driver = new ChromeDriver(coption),
                Btype.Firefox => driver = new FirefoxDriver(foptions),
                Btype.Edge => driver = new EdgeDriver(eoptions),
                Btype.Chromium => driver = new ChromeDriver(coption),
                _ => throw new Exception("No such browser")
            };

        public IWebDriver InitialisedDriver()
        {
            if (driver == null)
            {
                ChooseWithSwitch(Btype.Chrome, getCoptions());
            }
            return driver;
        }

        public ChromeOptions getCoptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            options.AddArguments("disable-inforbars");
            options.AddExcludedArgument("enable-automation");
            return options;
        }
        public FirefoxOptions getFoptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("--width=1920", "--height=1080");
            options.AddArguments("disable-inforbars");
            //options.AddExcludedArgument("enable-automation");
            return options;
        }
        public EdgeOptions getEoptions()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArguments("start-maximized", "incognito");
            options.AddArguments("disable-inforbars");
            options.AddExcludedArgument("enable-automation");
            return options;
        }
        public ChromeOptions getChromiumOptions()
        {
            ChromeOptions options = new ChromeOptions();
            //options.BinaryLocation = @"C:\Users\myuni\Downloads\chromedriver_win32\chromedriver.exe";
            options.AddArguments("disable-inforbars");
            options.AddExcludedArgument("enable-automation");
            return options;
        }
        public void ChooseDriver(string browserType)
        {
            if (browserType == "Chrome")
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("start-maximized", "incognito");
                options.AddArguments("disable-infobars");
                driver = new ChromeDriver(options);
            }
            else if (browserType == "FireFox")
            {
                driver = new FirefoxDriver();
            }
            else if (browserType == "Edge")
            {
                driver = new EdgeDriver();
            }
            //else if (browserType == "Chromium")
            //{
            //    ChromiumOptions chromiumOptions = new ChromiumOptions();
            //    driver = new ChromiumDriver(chromiumOptions);
            //}
            //else
            //{
            //    throw new ArgumentException("Invalid browser type specified");
            //}

            // COMMON ACTIONS AFTER INITIALIZING THE DRIVER
            //driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Environments.AutomationUrl);

            // EXAMPLE OF CLICKING THE CONSENT BUTTON, ONLY IF PRESENT
            try
            {
                driver.FindElement(By.CssSelector("button.fc-button.fc-cta-consent.fc-primary-button")).Click();
            }
            catch (NoSuchElementException)
            {
                // Ignore if the element is not found
            }
        }
        private static IEnumerable<TestCaseData> MyTestData()
        {
            string[] datas = { "Frank", "Eronmo", "abc is my address", "07768452033" };
            yield return new TestCaseData(datas).
            SetName("TestAutomation102");
        }

        [TearDown]
        public void End()
        {
            // PROPERLY DISPOSE OF THE DRIVER
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();  // Explicitly dispose of the driver
                driver = null;
            }
        }
    }
}