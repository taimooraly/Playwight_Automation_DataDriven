using CsvHelper;
using Microsoft.Playwright.NUnit;

namespace Playwight_Automation
{
    
    public class LoginPage : BasePage
    {
        
        public async Task Login()
        {
            // Read data from the CSV file
            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.csv")))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))            
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    //Login
                    await Page.GotoAsync("https://adactinhotelapp.com/");
                    Page.FillAsync("[name='username']", (string)record.username).Wait();
                    Page.FillAsync("[name='password']", (string)record.password).Wait();
                    await Page.ClickAsync("#login");
                    Thread.Sleep(2000);
                }
            }            
        }
    }
}