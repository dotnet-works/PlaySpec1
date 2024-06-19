using Microsoft.Playwright;

namespace PlaySpec1.Sample3
{
    public class PlaywrightBase3 : IDisposable
    {

        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _browserContext;
        private readonly List<IPage> _pages = new List<IPage>();

        //public async Task<IBrowser> InitializeBrowserAsync()
        //{
        //    _playwright = await Playwright.CreateAsync();
        //    _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //    {
        //        Headless = false
        //    });
           
        //    return _browser;
        //}

        public async Task<IBrowserContext> InitailizeBrowserContexts()
        {

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            _browserContext = await _browser.NewContextAsync();
            return _browserContext;
        }


        public async Task<IPage> NewPageAsync()
        {

            _browserContext = await _browser.NewContextAsync();
            var page = await _browserContext.NewPageAsync();


            //var page = await _browser.NewPageAsync();
            _pages.Add(page);
            return page;
        }

        public async Task CloseAllPagesAsync()
        {
            foreach (var page in _pages)
            {
                await page.CloseAsync();
            }
            _pages.Clear();
        }

        public async Task CloseBrowserAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
                _browser = null;
            }
        }

        public void Dispose()
        {
            CloseAllPagesAsync().GetAwaiter().GetResult();
            CloseBrowserAsync().GetAwaiter().GetResult();
            _playwright?.Dispose();
        }
    }
}
