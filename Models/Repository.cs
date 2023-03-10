using System;
using System.Data.SqlClient;
using System.Data;

namespace EmpManage.Models
{
    public class Repository
    {
        private static List<NewEmployee> allEmployees=new List<NewEmployee>();
        public static IEnumerable<NewEmployee> AllEmployees
        {
            get
            {
                return allEmployees;
            }
        }

        public static void toCreate(NewEmployee employee)
        {
            try{
                using(SqlConnection connection=new SqlConnection("Data Source=ASPIRE1879\\SQLEXPRESS;Initial Catalog=userDetails;Integrated Security=SSPI")){
                    SqlCommand command=new SqlCommand($"insert into userRecords1 values('{Convert.ToString(employee.employeeID)}','{Convert.ToString(employee.employeeName)}','{Convert.ToString(employee.password)}','{Convert.ToString(employee.age)}','{Convert.ToString(employee.salary)}','{Convert.ToString(employee.department)}')",connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
        }

        public static int validationLogin(NewEmployee employee)
        {
            DataTable userdatas=displayUserDetails();
            foreach(DataRow datarow in userdatas.Rows)
            {
                if(employee.employeeID==Convert.ToString(datarow[0]))
                    return 1;
            }
            return 0;
            
        }
        public static DataTable displayUserDetails()
        {
            SqlConnection connection=new SqlConnection("Data Source=ASPIRE1879\\SQLEXPRESS;Initial Catalog=userDetails;Integrated Security=SSPI");
            DataTable userdatas=new DataTable();
            try{
                SqlDataAdapter dataadapter=new SqlDataAdapter($"select * from userRecords1",connection);
                dataadapter.Fill(userdatas);
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
            finally{
                
            }        
            return userdatas;       
        }
        
           public static DataTable displayExpenseDetails()
        {
            SqlConnection connection=new SqlConnection("Data Source=ASPIRE1879\\SQLEXPRESS;Initial Catalog=userDetails;Integrated Security=SSPI");
            DataTable userdatas=new DataTable();
            try{
                SqlDataAdapter dataadapter=new SqlDataAdapter($"select * from expenseTable",connection);
                dataadapter.Fill(userdatas);
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
            finally{
                
            }        
            return userdatas;       
        }

        public static string? isValidUser(NewEmployee employee){
            DataTable userdatas=displayUserDetails();
            foreach(DataRow datarow in userdatas.Rows)
            {
                if((employee.employeeID==Convert.ToString(datarow[0])) && (employee.password==Convert.ToString(datarow[2])))
                    return Convert.ToString(datarow[1]);
            }
            return "novalue";
        }
        


         public static void delete(string employeeName)
        {
           foreach(NewEmployee x in allEmployees)
           {
            if(x.employeeName==employeeName)
            {
                allEmployees.Remove(x);
                break;
            }
           }
        }

        //  public static int update(NewEmployee employee)
        // {
        //     for(int i=0; i<allEmployees.Count;i++)
        //     {
        //         if(allEmployees[i].employeeID==employee.employeeID)
        //         {
        //             allEmployees[i].employeeName=employee.employeeName;
        //             allEmployees[i].department=employee.department;
        //             allEmployees[i].salary=employee.salary;
        //             allEmployees[i].age = employee.age;
        //             return 1;
        //         }
        //     }
        //     return 0;
        // }
        

    
    }
}