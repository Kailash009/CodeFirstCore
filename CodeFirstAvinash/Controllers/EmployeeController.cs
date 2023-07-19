using CodeFirstAvinash.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstAvinash.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbContextEmployee _dbEmp;
        public EmployeeController(DbContextEmployee dbEmp)
        {
            _dbEmp = dbEmp;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await(from m in _dbEmp.Employees.Where(m => m.is_Del == false)select m).ToListAsync();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee empObj)
        {
            if (ModelState.IsValid)
            {
               _dbEmp.Employees.Add(empObj);
               int n =await _dbEmp.SaveChangesAsync();
                if(n!=0)
                {
                    TempData["insert"] = "<script>alert('Employee Added SuccessFully!')</script>";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["insert"] = "<script>alert('Employee Failed!!')</script>";
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _dbEmp.Employees.Where(m => m.Eid == id).FirstOrDefaultAsync();
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee empObj)
        {
            if (ModelState.IsValid)
            {
                _dbEmp.Entry(empObj).State = EntityState.Modified;
                int n = await _dbEmp.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["update"] = "<script>alert('Employee Updated SuccessFully!')</script>";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["update"] = "<script>alert('Employee Failed!!')</script>";
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        { 
            var emp = await _dbEmp.Employees.Where(m => m.Eid == id).FirstOrDefaultAsync();
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Delete (int id)
        {
            var emp = await _dbEmp.Employees.Where(m => m.Eid == id).FirstOrDefaultAsync();
            if (emp != null)
            {
                emp.is_Del = true;
                _dbEmp.Entry(emp).State = EntityState.Modified;
                int n = await _dbEmp.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["delete"] = "<script>alert('Employee Deleted SuccessFully!')</script>";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["delete"] = "<script>alert('Employee Failed!!')</script>";
            }
            return RedirectToAction("Index");
        }
    }
}





