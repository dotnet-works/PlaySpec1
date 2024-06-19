using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySpec1.Sample2.PlayHook2
{
    public class PlaywrightBase2:IDisposable
    {

        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _browserContext;
        private readonly List<IPage> _pages = new List<IPage>();

        public async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

        }

        public async Task<IBrowserContext> GetBrowserContexts()
        {
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
