using BoDi;
using Microsoft.Playwright;
using PlaySpec1.Sample3;
using TechTalk.SpecFlow;

namespace PlaySpec1.Sample2.PlayHook2
{
    [Binding]
    public sealed class PlaywrightHooks3
    {
        
        private readonly IObjectContainer _container;
        private PlaywrightBase3 _playwrightBase;
        private IPage _page;
        private IBrowserContext _browserContext;
        

        public PlaywrightHooks3(IObjectContainer _container)
        {
           _container = _container; 
        }

        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            
        }

        [BeforeScenario]
        public async Task beforeScenario()
        {
            _playwrightBase = new PlaywrightBase3();
            _browserContext = await _playwrightBase.InitailizeBrowserContexts();


            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            _browserContext = await _browser.NewContextAsync();



            _page = await _browserContext.NewPageAsync();
            _container.RegisterInstanceAs(_page);
        }


        [AfterTestRun]
        public static void AfterTestRun(PlaywrightBase2 playwrightBase)
        {
            playwrightBase.Dispose();
        }

        [AfterScenario]
        public async Task AfterScenarioAsync()
        {
            await _playwrightBase.CloseAllPagesAsync();
        }
    }
}