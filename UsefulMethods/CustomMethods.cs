using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2AutomationTest.UsefulMethods
{
    public class CustomMethods
    {
        public void WaitForAlertBy(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.AlertIsPresent());

        }

        public void WaitForElementBy(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(by));

        }

        public static void WaitForElementByWithoutSelenniumExtras(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(by));
            //if (driver.FindElement(by).Displayed)
            //{
            //    wait.Until(mo => mo.FindElement(by));
            //}
        }

        public void SelectFromDropDownByText(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.DeselectByIndex(index);
        }

        public void SelectFromDropDownByValue(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.DeselectByValue(value);
        }
    }

    public static class CustomMethodsWithStatic
    {
        public static void WaitForAlertBy(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.AlertIsPresent());

        }

        public static void WaitForElementBy(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(by));

        }

        public static void WaitForElementByWithoutSelenniumExtras(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(by));
            //if (driver.FindElement(by).Displayed)
            //{
            //    wait.Until(mo => mo.FindElement(by));
            //}
        }

        public static void SelectFromDropDownByText(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.DeselectByIndex(index);
        }

        public static void SelectFromDropDownByValue(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.DeselectByValue(value);
        }
    }

}
