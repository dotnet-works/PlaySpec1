using BoDi;
using Microsoft.Playwright;
using PlaySpec1.AppPages;
using PlaySpec1.SpecHooks;
using PlaySpec1.StepDef;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow.CommonModels;
using TechTalk.SpecFlow.Configuration.JsonConfig;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace PlaySpec1.StepDefs3
{
    [Binding]
    public class SocialNetSteps1
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly SharedContext _sharedContext;
        private IPage _page;
        //private readonly IPage _page;
        private readonly DemoPage _demoPage;
        private readonly LoginPage _loginPage;
        //private readonly Config? _config;

 


        public SocialNetSteps1(ScenarioContext scenarioContext, SharedContext sharedContext)
        {
            _scenarioContext = scenarioContext;
            _sharedContext = sharedContext;
            _page = WebHooks.Page!;

            _demoPage = new DemoPage(_page);
            _loginPage = new LoginPage(_page);
            //_config = Hooks.Hooks.Config!;
        }


        [Given(@"user navigates to ""([^""]*)""")]
        [When(@"user navigates to ""([^""]*)""")]
        public async Task navStep1(string url)
        {

            await _page.GotoAsync(url);
            Thread.Sleep(2000);
        }

        [When(@"navigate to socialnetwork page")]
        public async Task s1()
        {
            Thread.Sleep(2000);
            await _demoPage.ClickFrontDemoBTN();
            //await _page.Locator("//a[contains(text(),'Frontend Demo')]").ClickAsync();
            Thread.Sleep(2000);

            //var tabs = _page.Context.Pages; //.Browser;
            //Console.WriteLine($"Total Tabs: {tabs.Count}"); 

            var x = _page.Context;
            Console.WriteLine(x);
            Console.WriteLine(await _page.TitleAsync());


            // //IReadOnlyList<IPage> tabs = _page.Context.Pages;
            //  await SwitchTabs("Open Source Social Network", _page.Context.Pages);
            // //Thread.Sleep(2000);

            // _page = _page.Context.Pages[1];

            //// await _page.Context.Pages[1].BringToFrontAsync();

            // await _page.Locator("[name=\"birthdate\"]").ClickAsync();
            // await _page.Locator("//*[@class='ui-datepicker-month']").ClickAsync();




        }

        [When(@"click on '(.*)' form feild and select year '(.*)'")]
        public async Task selectDoB(string fieldName, string year)
        {
            //IReadOnlyList<IPage> tabs = this._page.Context.Pages;
            //"Welcome : Open Source Social Network"
            _page = await SwitchTabs("Welcome :", _page.Context);
            Thread.Sleep(2000);

            if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
            {
                await _page.Locator("[name=\"birthdate\"]").ClickAsync();


            }
            await _page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { "2000" });


            //Thread.Sleep(200);
            //await _page.Locator("//*[@class='ui-datepicker-year']").ClickAsync();

            //IReadOnlyList<ILocator> MonthOpts = await _page.Locator("select.ui-datepicker-year>option").AllAsync();


            Thread.Sleep(2000);

            //await MonthOpts[10].S            //.ScrollIntoViewIfNeededAsync(new(){ Timeout = 500 });
            //await MonthOpts[10].ClickAsync();


        }


        [When(@"open new tab and navigate to ""([^""]*)""")]
        public async Task OpenTab(string newURL)
        {
            _page = _sharedContext.SharedPageContext;
            var newTab = await _page.Context.NewPageAsync();
            await newTab.GotoAsync(newURL);
            _sharedContext.SharedPageContext = newTab;
        }


        [When(@"^(?i)Switch to new tab")]
        public async Task tabSwitch()
        {
            _page = await SwitchTabs("Welcome :", _page.Context);
            _sharedContext.SharedPageContext = _page;
        }

        [When(@"click on '(.*)' form feild and select month '(.*)'")]
        public async Task selectDoB2(string fieldName, string month)
        {
            _page = await SwitchTabs("Welcome :", _page.Context);
            //IReadOnlyList<IPage> tabs = this._page.Context.Pages;
            //"Welcome : Open Source Social Network"
            //_page = await SwitchTabs("Welcome :", _page.Context);
            //Thread.Sleep(2000);

            if (!await _page.Locator("div#ui-datepicker-div").IsVisibleAsync())
            {
                await _page.Locator("[name=\"birthdate\"]").ClickAsync();


            }


            //await _page.Locator("[name=\"birthdate\"]").ClickAsync();
            //Thread.Sleep(200);
            //await _page.Locator("//*[@class='ui-datepicker-month']").ClickAsync();

            //IReadOnlyList<ILocator> MonthOpts = await _page.Locator("select.ui-datepicker-month>option").AllAsync();

            await _page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { "Jan." });
            Thread.Sleep(2000);

            //var culture = CultureInfo.GetCultureInfo("en-US");
            //var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);

            //foreach (string name in dateTimeInfo.AbbreviatedMonthNames)
            //{
            //    Console.WriteLine(name);
            //}


            var todayNum = DateTime.Today.Day; //.Now.ToString("d");
            string _dayLocator = $"//td/a[@data-date='{todayNum}']";
            await _page.Locator(_dayLocator).ClickAsync();
            Thread.Sleep(1500);

        }

        [Then(@"verify birthdate should be in dd/mm/yyyy format")]
        public async Task ValidFormat()
        {
            string birthvalue = await _page.Locator(_loginPage._TXTLoc_BirthDate).InputValueAsync();  // await _page.Locator("[name=\"birthdate\"]").InputValueAsync();
            Console.WriteLine(birthvalue);

            string validFormat = @"\d{2}/\d{2}/\d{4}";
            bool isMatch3 = Regex.IsMatch(birthvalue, validFormat);
            isMatch3.Should().BeTrue($"String {birthvalue} is in correct format of dd/MM/yyyy");
            Console.WriteLine($"String {birthvalue} is in correct format of dd/MM/yyyy");

            ////DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
            //DateTime userDate = DateTime.ParseExact(birthvalue, "dd/MM/yyyy", null);
            //DateTime userDate1 = DateTime.ParseExact(birthvalue, "dd/MM/yyyy", null);

            //DateTime dt = DateTime.Parse("09/12/2009");

            //Console.WriteLine(dt.ToString("dd/MM/yyyy"));

            ////DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
            //string x = string.Format("{0:dd/MM/yyyy}", birthvalue);
            //Console.WriteLine($"Format1: {x}");

            //Console.WriteLine($"Parsed: {birthvalue} DateTime1: {userDate}");
            //string.Equals(birthvalue, x);
            //if (string.Compare(birthvalue, x) == 0)
            //{
            //    Console.WriteLine("strings are valid");
            //}
        }

        [When(@"enter user firstname")]
        public async Task enterdata1()
        {
           // _page=_sharedContext.SharedPageContext;
            await _page.Locator(_loginPage.TXTLoc_FirstName).ClickAsync();
            await _page.Locator(_loginPage.TXTLoc_FirstName).FillAsync("Zumbaaaaaaa");
            await _page.Locator(_loginPage.TXTLoc_LastName).FillAsync("Laaast");
            await _page.Locator(_loginPage.TXTLoc_Email).FillAsync("zoya1122@yopmail.com");
            await _page.Locator(_loginPage.TXTLoc_ReEmail).FillAsync("zoya1122@yopmail.com");
            await _page.Locator(_loginPage.TXTLoc_UserName).FillAsync("zoya1122");
            await _page.Locator(_loginPage.TXTLoc_Password).FillAsync("Test@1234");
            await _page.Locator(_loginPage.RDLoc_Gender).ClickAsync();
            await _page.Locator(_loginPage.CKLoc_Agree).ClickAsync();
            await _page.Locator(_loginPage.BTNLoc_Submit).ClickAsync();


            Thread.Sleep(2000);
        }

        [When("verify email confirmation")]
        public async Task verifyMail()
        {

        }

        



        public async Task<IPage> SwitchTabs(string tabTitle, IBrowserContext BrowserCTX)
        {
            IPage? _page = null;
            foreach (var tab in BrowserCTX.Pages)
            {
                await tab.BringToFrontAsync();
                string _tabTitle = await tab.TitleAsync();
                Thread.Sleep(1000);
                if (_tabTitle.StartsWith(tabTitle, StringComparison.OrdinalIgnoreCase))
                {
                    _page = tab;
                }
            }


            return _page!;
        }




    }
}