using System;

namespace EmpManage.Models
{
    public class Employee
    {
        public int EmployeeID{get; set;}
        public string? EmployeeName{get; set;}
        public int Age{get; set;}
        public decimal Salary{get; set;}
        public string? Department{get; set;}
    }
}