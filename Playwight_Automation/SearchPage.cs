using CsvHelper;
using Microsoft.Playwright.NUnit;

namespace Playwight_Automation
{
    public class SearchPage : BasePage
    {
        public async Task Search()
        {
            // Read data from the CSV file
            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "search.csv")))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))            
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    //await Page.GotoAsync("https://adactinhotelapp.com/");
                    //Page.FillAsync("[name='username']", (string)record.username).Wait();
                    //Page.FillAsync("[name='password']", (string)record.password).Wait();
                    //await Page.ClickAsync("#login");
                    Page.TypeAsync("[name='location']",(string)record.location).Wait();
                    Page.TypeAsync("#hotels", (string)record.hotels).Wait();
                    Page.TypeAsync("#room_type", (string)record.room_type).Wait(); 
                    Page.TypeAsync("#room_nos", (string)record.room_nos).Wait();
                    Page.FillAsync("#datepick_in", (string)record.datepick_in).Wait();
                    Page.FillAsync("#datepick_out", (string)record.datepick_out).Wait();
                    Page.TypeAsync("#adult_room", (string)record.adult_room).Wait();
                    Page.TypeAsync("#child_room", (string)record.child_room).Wait(); ;
                    await Page.ClickAsync("#Submit");
                }
            }

                
            //}
            //Search Hotel
            //await Page.GotoAsync("https://adactinhotelapp.com/SearchHotel.php");
            
            ////Select Hotel
            //await Page.ClickAsync("#radiobutton_0");
            //await Page.ClickAsync("#continue");
            ////Book Hotel
            //await Page.FillAsync("#first_name", "Syed Taimoor");
            //await Page.FillAsync("#last_name", "Ali");
            //await Page.FillAsync("#address", "Karachi, Pakistan");
            //await Page.FillAsync("#cc_num", "5590524126324522");
            //await Page.TypeAsync("#cc_type", "Master Card");
            //await Page.TypeAsync("#cc_exp_month", "August");
            //await Page.TypeAsync("#cc_exp_year", "2022");
            //await Page.FillAsync("#cc_cvv", "542");
            //await Page.ClickAsync("#book_now");
            //Thread.Sleep(7000);
            ////Book
            //await Page.GotoAsync("https://adactinhotelapp.com/BookedItinerary.php");
            //Thread.Sleep(3000);
            //await Page.ClickAsync("#check_all");
            //await Page.ClickAsync("#cancelall");
            //Thread.Sleep(7000);
            //await Page.ClickAsync("#logout");
            //await Page.CloseAsync();
        }
    }
}