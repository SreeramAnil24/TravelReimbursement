using System;
using Microsoft.AspNetCore.Mvc;
using EmpManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace EmpManage.Controllers
{
    public class EmployeeController : Controller
    {
        // public IActionResult webIndex()
        // {
        //     return View(Repository.AllEmployees);  
        // }

        [HttpGet]
        public IActionResult toCreate()
        {
            return View(); 
        }


        [HttpPost]
        public IActionResult toCreate(NewEmployee employee)
        {
            Repository.toCreate(employee);
            return View("Destination", employee); 
        }      
        

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult AdminLogin(NewEmployee employee)
        {   

            return View("AdminDashboard", employee); 
        }  



        [HttpGet]
        public IActionResult toLogin()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult toLogin(NewEmployee employee)
        {
            string?  a = Repository.isValidUser(employee);
            if(a!="novalue")
            {
                ViewBag.message=a;
                // HttpContext.Session.SetString("employeeID",employee.employeeID);
                return View("Destination");
            }
                
            else
                return View("toLogin"); 
        }      
        

        
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View(); 
        }
        
        public IActionResult EmployeeDetails()
        {   
            DataTable employeedetails=Repository.displayUserDetails();
            return View("EmployeeDetails",employeedetails);
        }

        public IActionResult ApproveReimbursements()
        {   
            DataTable employeedetails=Repository.displayExpenseDetails();
            return View("ApproveReimbursements",employeedetails);
        }


        [HttpGet]
        public IActionResult Dashboard()
        {   
            return View(); 
        }

        [HttpPost]
        public IActionResult Dashboard(NewEmployee employee)
        {   

            return View("Documents", employee); 
        }      
        

        [HttpGet]
        public IActionResult Destination()
        {   
            
            return View(); 
        }

        [HttpPost]
        public IActionResult Destination(NewEmployee travel)
        {   
            TravelDB.addTravel(travel);
            return View("Reimbursement"); 
            
        }      

        [HttpGet]
        public IActionResult Reimbursement()
        {   
            DataTable temp=Repository.displayExpenseDetails();
            
            return View("Reimbursement",temp);
        }
        
        [HttpPost]
        public IActionResult Reimbursement(NewEmployee travel)
        {   
            TravelDB.addExpense(travel);
            DataTable temp=Repository.displayExpenseDetails();
            
            return View("Reimbursement",temp);
        } 



        [HttpGet]
        public IActionResult NewTravel()
        {   
            return View(); 
        }

       
       










        [HttpGet]
        public IActionResult Index()
        {   
            return View(); 
        }
        

        [HttpGet]
        public IActionResult toDelete()
        {
            return View();
        }

        [HttpPost]
       public IActionResult toDelete(string EmployeeName)
        {
            Repository.delete(EmployeeName);
            return View("deletetionsuccessfull");
        }

    //     [HttpGet]
    //      public IActionResult toUpdateRecords()
    //     {
    //         return View();
    //     }
    //     [HttpPost]
    //     public IActionResult toUpdateRecords(NewEmployee employee)
    //     {
    //         int result = Repository.update(employee);
    //         if(result==1)
    //             return View("success");
    //         else
    //             return View("fails");
    //     }

        /*[HttpGet]
        public IActionResult selectDestination()
        {
            return View();
        }
        [HttpPost]
       public IActionResult selectDestination(string toDestination)
        {
            Repository.delete(EmployeeName);
            return View("deletetionsuccessfull");
        }*/

    }
}