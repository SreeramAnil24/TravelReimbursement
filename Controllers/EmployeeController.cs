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

        public IActionResult Dashboard(NewEmployee employee){
            IEnumerable<object> dashBoardlist=Repository.dashBoard(employee);
            return View(dashBoardlist);
        }

        [HttpPost]
        public IActionResult toCreate(NewEmployee employee)
        {
            Repository.toCreate(employee);
            return View("Destination", employee); 
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
                HttpContext.Session.SetString("employeeId",employee.employeeID);
                ViewBag.message=a;
                return RedirectToAction("Dashboard","Employee");
            }
                
            else
                return View("toLogin"); 
        }      
        
        public IActionResult DoApprovals(string approvalstatus, string exp_number)
        {
            TravelDB.changeApproval(approvalstatus,exp_number);
            DataTable expenseDetails=Repository.displayExpenseDetails();
            return View("ApproveReimbursements", expenseDetails);

        }

          [HttpGet]
        public IActionResult AdminLogin()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult AdminLogin(NewEmployee employee)
        {   
            string?  a = Repository.isValidAdmin(employee);
            if(a=="notadmin")
            {   
                return View("AdminLogin");  
            }
            else
                return RedirectToAction("AdminDashboard", employee);
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

        [HttpPost]
        public IActionResult ApproveReimbursements(NewEmployee expense)
        {   
            foreach (var file in Request.Form.Files)
            {
                MemoryStream memoryStream=new MemoryStream();
                file.CopyTo(memoryStream);
                expense.imageUrl=memoryStream.ToArray();
            }
            TravelDB.addExpense(expense);
            DataTable expensedatas=Repository.displayExpenseDetails();
            return View("ApproveReimbursements",expensedatas);
        }

        // public IActionResult ApprovedReimbursement(string employeeID)
        // {   
        //     DataTable employeedetails=Repository.approveReimbursement(employeeID);
        //     employeedetails=Repository.displayExpenseDetails();
        //     return View("ApprovedReimbursement",employeedetails);
        // }



        

        [HttpGet]
        public IActionResult Destination()
        {   
            ViewBag.userSession=HttpContext.Session.GetString("employeeId");
            return View(); 
        }

        [HttpPost]
        public IActionResult Destination(NewEmployee travel)
        {   
            TravelDB.addTravel(travel);
            return RedirectToAction("Reimbursement","Employee"); 
            
        }      

        [HttpGet]
        public IActionResult Reimbursement()
        {   
            DataTable temp=Repository.displayExpenseDetails();
            ViewBag.userSession=HttpContext.Session.GetString("employeeId");
            return View("Reimbursement",temp);
        }
        
        [HttpPost]
        public IActionResult Reimbursement(NewEmployee travel)
        {   
            ViewBag.userSession=HttpContext.Session.GetString("employeeId");
            foreach (var file in Request.Form.Files)
            {
                MemoryStream memoryStream=new MemoryStream();
                file.CopyTo(memoryStream);
                travel.imageUrl=memoryStream.ToArray();
            }
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
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(NewEmployee employee)
        {
            bool temp=Repository.isValidID(Convert.ToString(employee.employeeID));
            if(temp){
            Repository.deleteEmployee(Convert.ToString(employee.employeeID));
            return View("Deletetionsuccessfull");}
            else{
                ViewBag.Message="Invalid ID";
                return View();}
        }



    //     [HttpGet]
    //     public IActionResult toDelete()
    //     {
    //         return View();
    //     }

    //     [HttpPost]
    //    public IActionResult toDelete(string EmployeeName)
    //     {
    //         Repository.delete(EmployeeName);
    //         return View("deletetionsuccessfull");
    //     }

        // [HttpPost]
        // public ActionResult UploadImage()
        // {
        //     var file = Request.Files["image"];
        //     if (file != null && file.ContentLength > 0)
        //     {
        //         var fileName = Path.GetFileName(file.FileName);
        //         var path = Path.Combine(Server.MapPath("~/wwwroot/image"), fileName);
        //         file.SaveAs(path);
        //         return RedirectToAction("Index");
        //     }
        //     return View();
        // }

        // public ActionResult ViewImages()
        // {
        //     var images = Directory.GetFiles(Server.MapPath("~/wwwroot/image")).Select(x => Path.GetFileName(x));
        //     return View(images);
        // }

    


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