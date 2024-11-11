

using OpenQA.Selenium;

namespace IdeaCenterWebDriver.Pages
{
    public class CreateIdeaPage : BasePage
    {
        public CreateIdeaPage(IWebDriver driver) : base(driver)
        {
        }

        public readonly static string Url = BaseUrl + "/Ideas/Create";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@id = 'form3Example1c']"));

        public IWebElement AddPictureInput => driver.FindElement(By.XPath("//input[@id = 'form3Example3c']"));

        public IWebElement DescribeIdeaInput => driver.FindElement(By.XPath("//textarea[@id = 'form3Example4cd']"));

        public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class = 'btn btn-primary btn-lg']"));

        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//div[@class = 'text-danger validation-summary-errors']//li"));
        public IWebElement TittleErrorMessage => driver.FindElements(By.XPath("//span[@class = 'text-danger field-validation-error']"))[0];
        public IWebElement DescribeErrorMessage => driver.FindElements(By.XPath("//span[@class = 'text-danger field-validation-error']"))[1];



        public void CreateIdea(string title , string imageUrl , string description) 
        {
            TitleInput.SendKeys(title);
            AddPictureInput.SendKeys(imageUrl);
            DescribeIdeaInput.SendKeys(description);
            CreateButton.Click();


        }
        public void AssertMessageErrors() 
        {
            Assert.True(MainErrorMessage.Text.Equals("Unable to create new Idea!"), "Main Message is not as expected");
            Assert.True(TittleErrorMessage.Text.Equals("The Title field is required."), "Tittle Error Message is not as expected");
            Assert.True(DescribeErrorMessage.Text.Equals("The Description field is required."), "Describe Error Message is not as expected");

        
        
        }
        public void OpenPage() 
        {
            driver.Navigate().GoToUrl(Url);
        }

    }
}
