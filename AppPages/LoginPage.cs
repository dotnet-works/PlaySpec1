using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySpec1.AppPages
{
    public class LoginPage : PageObjects
    {
        IPage _page;
        public LoginPage(IPage _page) : base(_page)
        {
           this._page = _page;
        }

        public readonly string _TXTLoc_BirthDate = "[name=\"birthdate\"]";

        public readonly string TXTLoc_FirstName = "[name=\"firstname\"]";

        public readonly string TXTLoc_LastName = "[name=\"lastname\"]";

        public readonly string TXTLoc_Email = "[name=\"email\"]";
        public readonly string TXTLoc_ReEmail = "[name=\"email_re\"]";
        public readonly string TXTLoc_UserName = "[name=\"username\"]";
        public readonly string TXTLoc_Password = "[name=\"password\"]";
        public readonly string RDLoc_Gender = "//input[@name='gender'and @value='male']";
        public readonly string CKLoc_Agree = "[name=\"gdpr_agree\"]";
        public readonly string BTNLoc_Submit = "input#ossn-submit-button";

        public readonly string BTNLoc_Login = "a.btn.btn-primary.btn-sm";
        public readonly string BTNLoc_ResetPassword = "a.btn.btn-warning.btn-sm";
        public readonly string TXTLoc_NewUserName = "[name=\"username\"]";
        public readonly string TXTLoc_NewUserPassword = "[name=\"password\"]";
        public readonly string BTNLoc_NewUserLogin = "input.btn.btn-primary.btn-sm";
        




    }
}
