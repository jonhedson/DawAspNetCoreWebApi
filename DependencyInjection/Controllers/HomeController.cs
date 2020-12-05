using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        //private ProductSum productSum;

        public HomeController(IRepository repo)
        {
            repository = repo;
            //productSum = psum;
        }

        public IActionResult Index([FromServices] ProductSum productSum)
        {
            ViewBag.Total = productSum.Total;

            ViewBag.HomeControllerGuid = repository.ToString();
            ViewBag.TotalGuid = productSum.Repository.ToString();

            return View(repository.Products);
        }

        #region Until Action Injection with FromServices 
        //public IActionResult Index()
        //{
        //    ViewBag.Total = productSum.Total;
        //    ViewBag.HomeControllerGuid = repository.ToString();
        //    ViewBag.TotalGuid = productSum.Repository.ToString();

        //    return View(repository.Products);
        //}
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
