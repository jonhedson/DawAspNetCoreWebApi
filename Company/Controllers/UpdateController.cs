using Company.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Controllers
{
    public class UpdateController : Controller
    {
        private CompanyContext context;

        public UpdateController(CompanyContext cc)
        {
            context = cc;
        }

        public async Task<IActionResult> Update()
        {

            var dept = new Department()
            {
                Id = 2,
                Name = "Marketing"
            };

            context.Update(dept);
            await context.SaveChangesAsync();
            return View("Common");
        }

        public async Task<IActionResult> UpdateMultiple()
        {

            var dept1 = new Department()
            {
                Id = 2,
                Name = "Designing"
            };
            var dept2 = new Department()
            {
                Id = 3,
                Name = "Marketing"
            };
            var dept3 = new Department()
            {
                Id = 4,
                Name = "Marketing"
            };

            List<Department> modifiedDept = new List<Department>() { dept1, dept2, dept3 };

            context.UpdateRange(modifiedDept);
            await context.SaveChangesAsync();

            return View("Common");
        }


        public async Task<IActionResult> UpdateRelated()
        {

            var dept = new Department()
            {
                Id = 8,
                Name = "Admin"
            };

            var emp = new Employee()
            {
                Id = 2,
                Name = "Matt_1",
                Designation = "Head_1",
                Department = dept
            };

            context.Update(emp);
            await context.SaveChangesAsync();

            return View("Common");
        }
    }
}
