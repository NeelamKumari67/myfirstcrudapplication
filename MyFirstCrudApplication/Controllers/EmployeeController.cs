using Microsoft.AspNetCore.Mvc;
using MyFirstCrudApplication.Data;
using MyFirstCrudApplication.Models;
using System.Reflection;

namespace MyFirstCrudApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;
        public EmployeeController(ApplicationContext context)
        {
         this.context = context;
        }
        public IActionResult Index()
        {
            var result =context.EmployeeData.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {

                    Employee_Name = model.Employee_Name,
                    Employee_PhoneNumber = model.Employee_PhoneNumber,
                    Employee_Email = model.Employee_Email,
                    Hire_Date = model.Hire_Date,
                    Status = model.Status,
                    Title = model.Title
                };
                context.EmployeeData.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Empty Field can't submit";
                return View(model); 
            }

           
        }
        [HttpDelete]
        public IActionResult Delete(int Employee_id)
        {
            var emp = context.EmployeeData.SingleOrDefault(e => e.Employee_Id == Employee_id);
            context.EmployeeData.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Employee_Id)
        {
            var emp = context.EmployeeData.SingleOrDefault(e => e.Employee_Id == Employee_Id);
            var result = new Employee()
            {
                Employee_Name = emp.Employee_Name,
                Employee_PhoneNumber = emp.Employee_PhoneNumber,
                Employee_Email = emp.Employee_Email,
                Hire_Date = emp.Hire_Date,
                Status = emp.Status,
                Title = emp.Title

            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {

            var emp = new Employee()
            {

                Employee_Name = model.Employee_Name,
                Employee_PhoneNumber = model.Employee_PhoneNumber,
                Employee_Email = model.Employee_Email,
                Hire_Date = model.Hire_Date,
                Status = model.Status,
                Title = model.Title
            };
            context.EmployeeData.Update(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
