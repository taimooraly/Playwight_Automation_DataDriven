using CsvHelper;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Core;

namespace Playwight_Automation
{
    [AllureNUnit]
    [TestFixture]
    public class Tests : BasePage
    {
        [SetUp]
        public async Task Initialization()
        {
            await Initialize();
        }
        [Test]
        public async Task Test1()
        {
            //await Initialize();
            LoginPage loginPage = new LoginPage();
            await loginPage.Login();
            SearchPage searchPage = new SearchPage();
            await searchPage.Search();
        }
    }
}