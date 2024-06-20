using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySpec1.SpecHooks.Config
{
    public class TestConfig
    {
            public string? BrowserName { get; set; }
            public ChromiumOptions? ChromiumOptions { get; set; }
            public List<object>? FirefoxOptions { get; set; }
            public bool? HeadLess { get; set; }
    }

    public class ChromiumOptions
    {
        public string? options1 { get; set; }
        public string? options2 { get; set; }
        public string? options3 { get; set; }
    }

    public class ProjectDirPaths
    {
        public string Reports => ProjectPath + "Reports";

        public static string ProjectPath   
        {
            get { return Directory.GetCurrentDirectory().Split("bin")[0]; }  
        }

        public static string ReportPath 
        {
            get { return ProjectPath + "Reports"; }  
        }

        public static string ScreenShotPath
        {
            get { return ProjectPath + "Reports/screenshots/"; }
        }
    }



}
