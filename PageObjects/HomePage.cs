﻿using Day2AutomationTest.UsefulMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2AutomationTest.PageObjects
{
    public class HomePage : Hooks
    {
        CustomMethods customMethods; 
        public HomePage(IWebDriver _driver) : base(_driver)
        {
            customMethods = new CustomMethods();
        }

        IWebElement contactUs => driver.FindElement(By.LinkText("Contact us"));

        public void NavigateToHomePage() => driver.Navigate().GoToUrl(Environments.POMUrl);
        //public void ClickContactUs()=> contactUs.Click();
        public ContactUsPage ClickContactUs()
        
        {
           contactUs.Click();
            customMethods.WaitForElementBy(driver, By.CssSelector("input[name=name]"));
           return new ContactUsPage(driver);
        } 

    }
}
