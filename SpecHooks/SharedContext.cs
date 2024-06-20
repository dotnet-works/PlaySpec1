using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaySpec1.SpecHooks
{
    [Binding]
    public sealed class SharedContext
    {
        public IPage SharedPageContext { get; set; }

        public TestData StepData { get; set; }

        public string USERDATA { get; set; }

        public string NEWUSEREMAIL { get; set; }

    }
}