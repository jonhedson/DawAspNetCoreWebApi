using Microsoft.AspNetCore.Mvc;

namespace UnderstandingControllersViews.Areas
{
    [Area("Sales")]
    public class AdminController : Controller
    {
        public IActionResult List()
        {
            return View("Show");
        }
    }
}
