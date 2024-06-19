using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaySpec1.StepDef
{
    [Binding]
    public sealed class SharedContext
    {
        public IPage SharedPageContext { get; set; }
    }
}