using DemoValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoValidation.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(JobApplication jobApplication)
        {
            if (string.IsNullOrEmpty(jobApplication.Name))
                ModelState.AddModelError(nameof(jobApplication.Name), "Please enter your name");
            else if (jobApplication.Name == "Trump")
                ModelState.AddModelError("", "Você não pode aplicar para esse Emprego");
            
            if (jobApplication.Experience.ToString() == "Select")
                ModelState.AddModelError(nameof(jobApplication.Experience),
                "Please select your experience");
            
            if (!jobApplication.TermsAccepted)
                ModelState.AddModelError(nameof(jobApplication.TermsAccepted),
                "You must accept the Terms");

            if (ModelState.IsValid)
                return View("Accepted", jobApplication);
            else
                return View();

        }
    }
}
