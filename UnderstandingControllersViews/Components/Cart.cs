using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.Http.Headers;
using UnderstandingControllersViews.Models;

namespace UnderstandingControllersViews.Components
{
    public class Cart : ViewComponent
    {
        // String
        /*public string Invoke()
        {
            return "This is from View Component";
        }*/

        /*public IViewComponentResult Invoke()
        {
            return Content("This is from View Component <h2>View Component</h2>");
        }*/

        /*public IViewComponentResult Invoke()
        {
            return  new HtmlContentViewComponentResult(new HtmlString("This is from <h2>View Component</h2>"));
        }*/

        public IViewComponentResult Invoke()
        {
            Product[] products = new Product[] {
                new Product() {name = "Women Show", price = 99},
                new Product() { name = "Mens Shirts", price = 59 },
                new Product() { name = "Children Belts", price = 19 },
                new Product() { name = "Girls Socks", price = 9 }
            };

            return View(products);
        }



    }
}
