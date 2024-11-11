using IdeaCenterWebDriver.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace IdeaCenterWebDriver.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage loginPage; 
        public CreateIdeaPage createIdeaPage;
        public MyIdeasPage myIdeasPage;
        public ReadIdeasPage readIdeasPage;
        public EditIdeasPage editIdeasPage;


        [OneTimeSetUp ]
        public void OneTimeSetUp() 
        {
           var chromeOptions = new ChromeOptions();
           chromeOptions.AddUserProfilePreference("profile.password_manager_enabled",false); //премахва изкачащите съобщения от браузера за слаби пароли
           chromeOptions.AddArgument("--disable-search-engine-choice-screen");

         // забраним искачането POPUP кой search engine да избере браузера 
           
            
           driver = new ChromeDriver(chromeOptions);
           driver.Manage().Window.Maximize();
           driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(10);

           loginPage = new LoginPage(driver);
           createIdeaPage = new CreateIdeaPage(driver);
           myIdeasPage = new MyIdeasPage(driver);
           readIdeasPage = new ReadIdeasPage(driver);
           editIdeasPage = new EditIdeasPage(driver);


           loginPage.OpenPage();
           loginPage.Login("tan@abv.bg","123456");
          

        }
        [OneTimeTearDown]
        public void OneTimeTearDown() 
        
        { 
          driver.Quit();
          driver.Dispose();
        }

        public string GenerateRandomString()  // генериране на random string
        {
            var random = new Random();

            return "#" + random.Next(1000, 10000);

        }
    }
}
