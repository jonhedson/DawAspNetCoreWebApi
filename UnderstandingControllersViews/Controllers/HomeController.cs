using Microsoft.AspNetCore.Mvc;

namespace UnderstandingControllersViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReceivedDataByRequest()
        {
            string name = Request.Form["name"];
            string sex = Request.Form["sex"];

            return View("ReceivedDataByRequest", $"{name} sex is {sex}");
        }

        public IActionResult CallSharedView()
        {
            return View();
        }

        public IActionResult TestLayout()
        {
            ViewBag.Title = "Welcome to TestLayout";
            return View();
        }


    }
}
