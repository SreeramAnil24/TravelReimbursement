using System;
using Microsoft.AspNetCore.Mvc;
using EmpManage.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmpManage.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmployees); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);
            return View("Thanks", employee); 
        }      
        
         [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(string EmployeeName)
        {
            Repository.delete(EmployeeName);
            return View("deletetionsuccessfull");
        }


        [HttpGet]
         public IActionResult UpdateRecords()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateRecords(Employee employee)
        {
            int result = Repository.update(employee);
            if(result==1)
                return View("success");
            else
                return View("fails");
        } 


    }
}