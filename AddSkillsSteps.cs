using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkillsSteps
    {
        public string Skill { get; private set; }

        [Given(@"I have cliked on profoel tab and add new skill tab")]
        public void GivenIHaveClikedOnProfoelTabAndAddNewSkillTab()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //Click on skills button
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Skills')]")).Click();
            Thread.Sleep(1000);


            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//div[(text()='Add New' and @class='ui teal button')]")).Click();
        }
        
        [When(@"I enter skill details (.*) and (.*)")]
        public void WhenIEnterSkillDetailsAnd(string Skill, string Level)
        {
            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Skill']")).SendKeys(Skill);
            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();

            //Choose the Skill level
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//option[@value='Beginner']")).Click();
        }
        
        [When(@"I click add button")]
        public void WhenIClickAddButton()
        {
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@type='button' and @value='Add']")).Click();
        }
        
        [Then(@"skill should be added to profiel")]
        public void ThenSkillShouldBeAddedToProfiel()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Skills");

                Thread.Sleep(1000);
                string ExpectedValue = Skill;
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()=Skill]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}
