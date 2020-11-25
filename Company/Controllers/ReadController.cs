using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    public class ReadController : Controller
    {
        private CompanyContext context;

        public ReadController(CompanyContext cc)
        {
            context = cc;
        }

        public async Task<IActionResult> Index()
        {
            var emp = await context.Employee.ToListAsync();
            var dept = await context.Department.ToListAsync();

            return View("Common");
        }

        public async Task<IActionResult> EagerRead()
        {
            Employee emp;

            emp = await context.Employee.Where(e => e.Name == "Matt")
                                        .Include(s => s.Department)
                                        .FirstOrDefaultAsync();
            
            return View("Common");
        }


    }
}
