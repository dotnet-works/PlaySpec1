using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySpec1.SpecHooks
{
    public class Driver
    {
        private readonly bool _isHeadless;
        private readonly string _browserType;
        private readonly Task<IBrowser> _browser;
        public IBrowser Browser => _browser.Result;

        public Driver(string browserType, bool isHeadless = false)
        {
            this._browserType = browserType;
            this._isHeadless = isHeadless;
            _browser = Task.Run(InitializePlaywright);
        }

        private async Task<IBrowser> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            IBrowser? taskIBrowser = null;

            switch (this._browserType)
            {
                case "chromium":
                    taskIBrowser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Args = new[] { 
                                       "--start-maximized",
                                       "--disable-gpu",
                                       "--no-sandbox"
                                     },
                        Headless = this._isHeadless
                    });
                    break;
            }
            return taskIBrowser!;
        }
    }
}


