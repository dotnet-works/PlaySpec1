using Microsoft.Playwright;


namespace PlaySpec1.Sample1.PlayHooks
{

    public class PlayWrightDriver
    {
        private static IBrowser? _browser;
        private IPage? _page;
        public static IBrowserContext? _browserContext;

        public async Task<IPage> InitializeAsync()
        {
            if (_browser == null)
            {
                var playwright = await Playwright.CreateAsync();
                _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });
            }

            // _page = await _browser.NewPageAsync();
            _browserContext = await _browser.NewContextAsync();
            _page = await _browserContext.NewPageAsync();
            return _page;
        }

        public async Task CloseAsync()
        {
            if (_page != null)
            {
                await _page.CloseAsync();
            }
        }
    }
}