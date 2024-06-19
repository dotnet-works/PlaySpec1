using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaySpec1.Sample1.PlayHooks
{
    [Binding]
    public sealed class PlayWrightHooks
    {
        [Binding]
        public class PlaywrightHooks
        {
            private readonly PlayWrightDriver _playwrightDriver;
            private IPage _page;
            private IBrowserContext _browserContext;



            public PlaywrightHooks(PlayWrightDriver playwrightDriver)
            {
                _playwrightDriver = playwrightDriver;
            }

            [BeforeScenario]
            public async Task BeforeScenarioAsync()
            {
                _page = await _playwrightDriver.InitializeAsync();
            }

            [AfterScenario]
            public async Task AfterScenarioAsync()
            {
                await _playwrightDriver.CloseAsync();
            }

            public IPage Page => _page;
            public IBrowserContext BrowserContext => _browserContext;
        }
    }
}