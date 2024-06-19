using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySpec1.AppPages
{
    public class DemoPage : PageObjects
    {
        public DemoPage(IPage _page) : base(_page)
        {
        }

        private readonly string _BTN_FrontEndDemo = "//a[contains(text(),'Frontend Demo')]";
        
        public async Task ClickFrontDemoBTN()
        {
            await ClickAppElement(_BTN_FrontEndDemo);
        }








    }
}
