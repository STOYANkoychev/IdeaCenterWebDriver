using OpenQA.Selenium;


namespace IdeaCenterWebDriver.Pages
{
    public class EditIdeasPage : BasePage
    {
        public EditIdeasPage(IWebDriver driver) : base(driver)
        {
        }

        public readonly static string Url = BaseUrl + "/Ideas/Edit";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name ='Title']"));

       

        public IWebElement DescribeIdeaInput => driver.FindElement(By.XPath("//textarea[@name ='Description']"));

        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class = 'btn btn-primary btn-lg' and contains(text(),'Edit') ]"));



    }
}
