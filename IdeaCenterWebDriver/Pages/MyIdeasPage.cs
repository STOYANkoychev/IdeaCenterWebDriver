

using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IdeaCenterWebDriver.Pages
{
    public class MyIdeasPage : BasePage
    {
        public MyIdeasPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Ideas/MyIdeas";

        public ReadOnlyCollection <IWebElement> IdeasCards => driver.FindElements(By.XPath("//div[@class = 'card mb-4 box-shadow']"));

        public IWebElement ViewButtonLastIdea => IdeasCards.Last().FindElement(By.XPath(".//a[contains(text(),'View')]"));//с relative path -(добавяме(.)пред пътя за да ни го закачи)
        public IWebElement EditButtonLastIdea => IdeasCards.Last().FindElement(By.XPath(".//a[contains(text(),'Edit')]"));
        public IWebElement DeleteButtonLastIdea => IdeasCards.Last().FindElement(By.XPath(".//a[contains(text(),'Delete')]"));
        public IWebElement DescriptionLastIdea => IdeasCards.Last().FindElement(By.XPath(".//p[@class = 'card-text']"));



        public void OpenPage() 
        {
          driver.Navigate().GoToUrl(Url);
        
        }




    }
}
