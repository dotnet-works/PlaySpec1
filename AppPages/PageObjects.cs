using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySpec1.AppPages
{
    public class PageObjects
    {
        private IPage? _page;

        public PageObjects(IPage _page)
        {
            this._page = _page;
        }


        public async Task ClickAppElement(string ElementLocator)
        {
            await _page.ClickAsync(ElementLocator);
        }

        public async Task SendText(string _ele, string textValue)
        {
            await _page.ClickAsync(_ele);
            await _page.FillAsync(_ele, textValue);
        }



    }
}
