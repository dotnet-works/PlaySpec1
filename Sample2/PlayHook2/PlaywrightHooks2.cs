using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaySpec1.Sample2.PlayHook2
{
    [Binding]
    public sealed class PlaywrightHooks2
    {
        private readonly PlaywrightBase2 _playwrightBase;
        private IObjectContainer _container;
        private IPage _page;
        

        public PlaywrightHooks2(PlaywrightBase2 _playwrightBase)
        {
            _playwrightBase = _playwrightBase;
        }

        [BeforeTestRun]
        public static async Task BeforeTestRun(PlaywrightBase2 playwrightBase)
        {
            await playwrightBase.InitializeAsync();
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