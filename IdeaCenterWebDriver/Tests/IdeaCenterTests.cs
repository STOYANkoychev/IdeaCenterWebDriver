

namespace IdeaCenterWebDriver.Tests
{
    public class IdeaCenterTests : BaseTest
    {
        public string lastCreatedIdeaTitle;
        public string lastCreatedIdeaDescription;




        [Test, Order(1)]

        public void CreateIdeaWithInvalidData()
        {

            createIdeaPage.OpenPage();
            createIdeaPage.CreateIdea("", "", "");

            createIdeaPage.AssertMessageErrors();


        }

        [Test, Order(2)]

        public void CreateIdeaWithValidData()
        {
            lastCreatedIdeaTitle = "^Title" + GenerateRandomString();
            lastCreatedIdeaDescription = "Description" + GenerateRandomString();

            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "" , lastCreatedIdeaDescription);



            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Url is not corect ");
            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Descriptions not match");

        }

        [Test, Order(3)]

        public void ViewLastCreatedIdea()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.ViewButtonLastIdea.Click();


            Assert.That(readIdeasPage.IdeaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle), "IdeaTittle not match");
            Assert.That(readIdeasPage.IdeaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "IdeaDescription mot match");

        }

        [Test ,Order(4)]
        public void EditedLastIdea() 
        {
            myIdeasPage.OpenPage();

            myIdeasPage.EditButtonLastIdea.Click();

            string updateTitle = "Change title" + lastCreatedIdeaTitle;

            editIdeasPage.TitleInput.Clear();
            editIdeasPage.TitleInput.SendKeys(updateTitle);

            editIdeasPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "the page is not as expected");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(readIdeasPage.IdeaTitle.Text.Trim(), Is.EqualTo(updateTitle), "The title is not as expected");



        }
    }
}
