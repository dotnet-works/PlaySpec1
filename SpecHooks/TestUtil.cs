using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySpec1.SpecHooks
{
    public class TestUtil
    {
        public static string ProjectPath   // property
        {
            get { return Directory.GetCurrentDirectory().Split("bin")[0]; }   // get method
        }

        public static string ReportPath   // property
        {
            get { return ProjectPath + "Reports"; }   // get method
        }

        public static string ScreenShotPath
        {
            get { return ProjectPath + "Reports/screenshots/"; }
        }

        public async Task screenshot(IPage page,string name=null)
        {
            await page.ScreenshotAsync(new()
                          {
                             Path = $"{ScreenShotPath}+{name}"
                          });
            //return null;
        }

    }
}
