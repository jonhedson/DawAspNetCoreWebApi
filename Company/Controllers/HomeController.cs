using Company.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class HomeController : Controller
    {
        private CompanyContext context;

        public HomeController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Index1()
        {

            var dept = new Department()
            {
                Name = "Designing"
            };

            context.Entry(dept).State = EntityState.Added;
            context.SaveChanges();

            return "Record";
        }

        public string Info()
        {
            var info = new Information()
            {
                Name = "Infnet",
                License = "XXYY",
                Revenue = 1000,
                Established = Convert.ToDateTime("2020/06/24")
            };
            context.Information.Add(info);
            context.SaveChanges();

            return "Record Inserted";
        }



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
