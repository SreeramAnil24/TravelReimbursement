using System;

namespace EmpManage.Models
{
    public class Repository
    {
        private static List<Employee> allEmployees=new List<Employee>();
        public static IEnumerable<Employee> AllEmployees
        {
            get
            {
                return allEmployees;
            }
        }

        public static void Create(Employee employee)
        {
            allEmployees.Add(employee);
        }


         public static void delete(string EmployeeName)
        {
           foreach(Employee x in allEmployees)
           {
            if(x.EmployeeName==EmployeeName)
            {
                allEmployees.Remove(x);
                break;
            }
           }
        }

         public static int update(Employee employee)
        {
            for(int i=0; i<allEmployees.Count;i++)
            {
                if(allEmployees[i].EmployeeID==employee.EmployeeID)
                {
                    allEmployees[i].EmployeeName=employee.EmployeeName;
                    allEmployees[i].Department=employee.Department;
                    allEmployees[i].Salary=employee.Salary;
                    allEmployees[i].Age = employee.Age;
                    return 1;
                }
            }
            return 0;
        }
        
    }
}