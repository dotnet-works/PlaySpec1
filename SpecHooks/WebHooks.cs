using BoDi;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace PlaySpec1.SpecHooks
{
    [Binding]
    public sealed class WebHooks
    {
        private static IBrowser? _browser;
        private IBrowserContext? _context;
        public static IPage? Page;
        private readonly IObjectContainer _container;
        //public IPage? Page;
        //public static Config? Config;

        public WebHooks(IObjectContainer container)
        {
            _container = container;
        }



        [BeforeTestRun]
        public static Task BeforeAll()
        {
            //string projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "../../../");
            //string filePath = Path.Combine(projectRoot, "config.json");
            //string jsonContent = File.ReadAllText(filePath);

            //Config = JsonConvert.DeserializeObject<Config>(jsonContent)!;
            //_browser = new Driver(Config.browser!).Browser;
            _browser = new Driver("chromium").Browser;
            return Task.CompletedTask;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            if (_browser != null)
            {
                _context = await _browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = ViewportSize.NoViewport
                });

                Page = await _context.NewPageAsync();
                _container.RegisterInstanceAs<IPage>(Page);
                
            }
            else
            {
                throw new NullReferenceException("The browser is not initialized.");
            }
        }

        //[AfterScenario]
        //public async Task AfterScenario(ScenarioContext context)
        //{
        //    if (Page != null)
        //    {
        //        await Page.CloseAsync();
        //    }
        //    else
        //    {
        //        throw new NullReferenceException("The page is not initialized.");
        //    }

        //    if (_context != null)
        //    {
        //        await _context.CloseAsync();
        //    }
        //    else
        //    {
        //        throw new NullReferenceException("The context is not initialized.");
        //    }

        //}

        [AfterTestRun]
        public static async Task AfterAll()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
            else
            {
                throw new NullReferenceException("The browser is not initialized.");
            }

        }
    }
}