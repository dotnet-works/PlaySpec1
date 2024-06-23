using Microsoft.Playwright;
using PlaySpec1.AppPages;
using PlaySpec1.SpecHooks;
using PlaySpec1.SpecHooks.Config;
using TechTalk.SpecFlow;

namespace PlaySpec1.StepDef
{
    [Binding]
    public class PlayActionDemoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SharedContext _sharedContext;
        private IPage _page;
       
        public PlayActionDemoSteps(ScenarioContext scenarioContext, SharedContext sharedContext)
        {
            _scenarioContext = scenarioContext;
            _sharedContext = sharedContext;
            _page = WebHooks.Page!;
        }

        [When(@"Enter data in ""([^""]*)"" label Textbox using ""([^""]*)"" method")]
        public async Task demoStep1(string labelName,string methodName)
        {
            await _page.Locator("[id=\"name\"]").ClearAsync();
            Console.WriteLine(ProjectDirPaths.ReportPath);
            Console.WriteLine(ProjectDirPaths.ScreenShotPath);
            switch (methodName.ToLower())
            {
                case "fill":
                    await _page.Locator("[id=\"name\"]").FillAsync("RandomData");
                    Thread.Sleep(900);
                    break;
                case "type":
                    await _page.Locator("[id=\"name\"]").PressSequentiallyAsync("RandomData", new() { Delay=50});
                    break;
            }
        }

        [When(@"press key combo ctrl and A")]
        public async Task presscombo()
        {
            await _page.Locator("[id=\"name\"]").PressAsync("Control+A");
            Thread.Sleep(600);
            await _page.Locator("[id=\"name\"]").PressAsync("ArrowLeft");
            Thread.Sleep(600);
            await _page.Locator("[id=\"name\"]").PressAsync("Control+A");
            await _page.Locator("[id=\"name\"]").PressAsync("Delete");
            Thread.Sleep(600);
        }

        [When(@"Scroll To element")]
        public async Task scrollToEle()
        {
            var DragEle = _page.Locator("div#draggable");
            await DragEle.ScrollIntoViewIfNeededAsync(new() { Timeout = 1000 });
            Thread.Sleep(2000);
        }



        [When(@"perform drag and drop operation")]
        public async Task dragNdrop()
        {
            var DragEle = _page.Locator("div#draggable");
            //await DragEle.ScrollIntoViewIfNeededAsync(new() { Timeout=1000});
            //Thread.Sleep(5000);
            
            await _page.DragAndDropAsync("div#draggable", "div#droppable");
            Thread.Sleep(5000);

        }

        [When("Get element diamension")]
        public async Task getDiamension()
        {
            var DragEle = await _page.Locator("div#draggable").BoundingBoxAsync();
            Console.WriteLine("Diamension of Element");
            Console.WriteLine($"X: {DragEle.X} Y:{DragEle.Y} width:{DragEle.Width} height:{DragEle.Height}");

        }

        [When(@"scroll mouse forward (.*) pixel verticalliy")]
        public async Task scrollby(int px)
        {
            var DropEle = _page.Locator("div#droppable");
            await _page.Mouse.WheelAsync(0, px);   //.mouse.wheel(delta_x, delta_y)
            Thread.Sleep(2000);
        }

        [When(@"select multi elements in selectbox using option")]
        public async Task select_mullti()
        {
            await _page.Locator("[id=\"colors\"]").SelectOptionAsync(new[] { "Red","Yellow" });
            //await _page.Locator("[id=\"colors\"]").SelectTextAsync(new[] { "", "" });
        }

        [When(@"select single elements in selectbox using text value")]
        public async Task select_by_value()
        {
            await _page.Locator("[id=\"colors\"]").SelectOptionAsync(new[] { "yellow"});
        }

        [When(@"refresh the page")]
        public async Task refreshPage()
        {
            await _page.ReloadAsync(new() { WaitUntil = WaitUntilState.Load});
        
        }

        [When(@"click link using javascript with (.*) secs delay")]
        public async Task clickUsingJs(int delay)
        {
            var ele = _page.Locator("[id=\"email\"]");

            ILocator lin = _page.Locator("//a[contains(text(),'orange HRM')]");

            string linkString = "//a[contains(text(),'orange HRM')]";
            string linkTxt = "orange HRM";
            var x =$"document.querySelector('{linkString}').click();";
            Console.WriteLine(x);
            //await _page.EvaluateAsync($"document.querySelector('orange HRM').click();");
            //await _page.EvaluateAsync($"document.evaluate(\"//*[text()='{linkTxt}']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();");


            await _page.EvaluateAsync($"document.evaluate(\"{linkString}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();");
            await _page.WaitForNavigationAsync();
            Thread.Sleep(delay*1000);
            var HRMUserName = "//input[@name='username']";
            await _page.EvaluateAsync($"document.evaluate(\"{HRMUserName}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.value='Admin';");
        }

        [When(@"highlight and click element")]
        public async Task highlightAndclick()
        {
            var HRMUserName = "//input[@name='username']";
            await _page.Locator(HRMUserName).HighlightAsync();
            await _page.Locator(HRMUserName).ClickAsync();
        }

        [When(@"wait for (.*) secs")]
        public async Task wait_for(int x)
        {
            Thread.Sleep(x*1000);
        }
        [When(@"click alert button")]
        public async Task WhenClickAlertButton()
        {
            //await _page.Locator("//button[text()='Alert']").ClickAsync();
        }

        [When(@"click on ""([^""]*)"" button")]
        public async Task DialogAlertButton(string alertbuttonName)
        {

            
            Console.WriteLine("Activate browser alert Handler");

            /*
             '+=' : This operator is used to subscribe a method to the event. 
                    When the event occurs, the subscribed method(s) are invoked.
            */
            var dialogMessage = new TaskCompletionSource<string>();
            _page.Dialog += async (_, dialog) =>
                 {
                     
                     Console.WriteLine(dialog.Type);
                   if (dialog.Message.Contains("I am an alert box!"))
                   {
                      Console.WriteLine("I am an alert box!");
                      await dialog.AcceptAsync();
                      dialogMessage.TrySetResult(dialog.Message);
                     }
                  
                   
                   if (dialog.Message.Contains("press a button!"))
                   {
                     Console.WriteLine("press a button!");
                     await dialog.AcceptAsync();
                     dialogMessage.TrySetResult(dialog.Message);
                     }

                   if (dialog.Message.Contains("Please enter your name:"))
                   {
                     Console.WriteLine("Please enter your name:");
                     await dialog.AcceptAsync();
                     dialogMessage.TrySetResult(dialog.Message);
                   }
            };


            //_page.Dialog += (_, dialog) =>
            //{
            //    dialog.AcceptAsync();
            //    dialogMessage.TrySetResult(dialog.Message);
            //};
            switch (alertbuttonName.ToLower())
            {
                case "alert":
                    await _page.Locator("//button[text()='Alert']").ClickAsync();
                    break;
                case "confirm box":
                    await _page.Locator("//button[contains(text(),'Confirm Box')]").ClickAsync();
                    break;
                case "prompt":
                    await _page.Locator("//button[text()='Prompt']").ClickAsync();
                    break;
            }
            
            //await _page.Locator("//button[text()='Alert']").ClickAsync();
            //await _page.Locator("//button[normalize-space()='Confirm Box']").ClickAsync();
            string _msg = await dialogMessage.Task;
            Console.WriteLine("Dailog Message:" + _msg);
            Thread.Sleep(1000);




        }



    }
}