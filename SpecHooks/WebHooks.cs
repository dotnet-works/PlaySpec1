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
           
            if (System.Environment.GetEnvironmentVariable("PIPERUN")=="True")
            {
                _browser = new Driver("chromium", true).Browser;
            }
            else
            {
                _browser = new Driver("chromium", false).Browser;
            }
            
            return Task.CompletedTask;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            if (_browser != null)
            {
                _context = await _browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = ViewportSize.NoViewport,
                    RecordVideoDir="../../../videos",
                    
                    //ViewportSize = new ViewportSize() { Width = 1280, Height = 1024 }
                    

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