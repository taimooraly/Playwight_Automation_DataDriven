using Allure.Net.Commons;
using CsvHelper;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

namespace Playwight_Automation
{
    public class BasePage 
    {
        //public static IFrameLocator frameLocator { get; set; }
        public static IPage Page { get; set; }        
        //public static IFrame Frame { get; set; }
        public static IBrowser Browser { get; set; }
        public static IBrowserContext Context { get; set; }
        //public static TestContext testContext { get; set; }
        //public static ILocatorAssertions Expect(ILocator locator) => Assertions.Expect(locator);
        //public static JObject jObject;
        //public static IPageAssertions Expect(IPage page) => Assertions.Expect(page);
        //public static string pathWithFileNameExtension;
        public static async Task Initialize()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 50, Timeout = 80000, });
            Context = await Browser.NewContextAsync(new()
            {
                RecordVideoDir = "videos/",
                RecordVideoSize = new RecordVideoSize() { Width = 1920, Height = 1080 }

            });
            // Start tracing before creating / navigating a page.
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true,
            });

            Page = await Context.NewPageAsync();
            Page.SetDefaultTimeout(5000);
            await Page.SetViewportSizeAsync(1920, 1080);
        }
        //public static void TakeScreenshotAllure(string stepDetail)
        //{
        //    string path = @"\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        //    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //    screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        //    AllureLifecycle.Instance.AddAttachment(stepDetail, "image/png", path);
        //}
        public static async Task Write(string locators, string data)
        {
            //try
            //{
                await Page.FillAsync(locators, data);
                //TakeScreenshotAllure("Write");
            //}
            //catch (Exception ex)
            //{
            //    TakeScreenshotAllure("Write Failed" + ex);
            //}
        }
        public static async Task Click(string locators)
        {
            //try
            //{
                await Page.ClickAsync(locators);
                //TakeScreenshotAllure("Click");
            //}
            //catch (Exception ex)
            //{
            //    TakeScreenshotAllure("Click Failed" + ex);
            //}
        }
        public static async Task Dropdown(string locator, string value)
        {
            //try
            //{
                await Page.SelectOptionAsync(locator, new SelectOptionValue { Value = value });
                //TakeScreenshotAllure("Dropdown");
            //}
            //catch (Exception ex)
            //{
            //    TakeScreenshotAllure("Dropdown Failed" + ex);
            //}
        }
        public static async Task OpenUrl(string url)
        {
            //try
            //{
                await Page.GotoAsync(url);
        //        TakeScreenshotAllure("Open Url");
        //    }
        //    catch (Exception ex)
        //    {
        //        TakeScreenshotAllure("Url Failed to Open" + ex);
        //    }
        }
    }
}