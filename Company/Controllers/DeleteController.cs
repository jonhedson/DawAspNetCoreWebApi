using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    public class DeleteController : Controller
    {
        private CompanyContext context;

        public DeleteController(CompanyContext cc)
        {
            context = cc;
        }

        public async Task<IActionResult> DeleteSingle()
        {

            var dept = new Department()
            {
                Id = 2
            };

            context.Remove(dept);
            await context.SaveChangesAsync();

            return View("Common");
        }

        public async Task<IActionResult> DeleteMultiple()
        {
            List<Department> dept = new List<Department>()
            {
                new Department(){Id=3},
                new Department(){Id=4},
                new Department(){Id=5}
            };

            context.RemoveRange(dept);
            await context.SaveChangesAsync();


            return View("Common");
        }

        public async Task<IActionResult> DeleteRelated()
        {

            Department dept = context.Department.Where(a => a.Id == 1)
                                    .Include(x => x.Employee)
                                    .FirstOrDefault();
            

            context.Remove(dept);
            await context.SaveChangesAsync();

            return View("Common");
        }
    }
}
