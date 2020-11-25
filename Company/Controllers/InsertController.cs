using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    public class InsertController : Controller
    {
        private CompanyContext context;

        public InsertController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult InsertSingle()
        {
            var dept = new Department()
            {
                Name = "Designing"
            };

            //context.Entry(dept).State = EntityState.Added;
            context.Add(dept);
            context.SaveChanges();

            return View("Common");
        }

        public async Task<IActionResult> InsertSingleAsyn()
        {
            var dept = new Department()
            {
                Name = "Designing"
            };
            context.Add(dept);
            await context.SaveChangesAsync();
            return View(" Common ");
        }

        public async Task<IActionResult> InsertMultiple()
        {
            var dept1 = new Department() { Name = "Development" };
            var dept2 = new Department() { Name = "HR" };
            var dept3 = new Department() { Name = "Marketing" };

            var depts = new List<Department>() { dept1, dept2, dept3 };


            //context.AddRange(dept1,dept2,dept3);
            context.AddRange(depts);
            await context.SaveChangesAsync();

            return View("Common");
        }

        public async Task<IActionResult> InsertRelated()
        {
            var dept = new Department()
            {
                Name = "Asp.net"
            };

            var emp = new Employee()
            {
                Name = "Matt",
                Designation = "Head",
                Department = dept
            };


            context.Add(emp);
            await context.SaveChangesAsync();
            
            return View("Common");
        }


    }
}
