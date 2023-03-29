using System;
using System.Collections;
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


        public static IEnumerable<object> dashBoard(string employeeID)
        {   
            Console.WriteLine(employeeID+"travel");
            List<object> itemList = new List<object>();
            string? empID=employeeID;
            try{
                using(SqlConnection connection=new SqlConnection(getConnection())){
                    SqlCommand command1=new SqlCommand($"select toDestination from travelsTable where employeeID='{empID}'",connection);
                    SqlCommand command2=new SqlCommand($"select mediumofTravel from travelsTable where employeeID='{empID}'",connection);
                    SqlCommand command3=new SqlCommand($"select dateofTravel from travelsTable where employeeID='{empID}'",connection);
                    SqlCommand command4=new SqlCommand($"select count(*) from expenseTable",connection);
                    SqlCommand command5=new SqlCommand($"select COUNT(*) from expenseTable where approval='approved'",connection);
                    SqlCommand command6=new SqlCommand($"select COUNT(*) from expenseTable where approval='rejected'",connection);
                    connection.Open();
                    itemList.Add(Convert.ToString(command1.ExecuteScalar()));
                    itemList.Add(Convert.ToString(command2.ExecuteScalar()));
                    itemList.Add(Convert.ToString(command3.ExecuteScalar()));
                    itemList.Add(Convert.ToString(command4.ExecuteScalar()));
                    itemList.Add(Convert.ToString(command5.ExecuteScalar()));
                    itemList.Add(Convert.ToString(command6.ExecuteScalar()));
                    // int noOfFoodItems=Convert.ToInt32(command1.ExecuteScalar());
                    // int noOfOrders=Convert.ToInt32(command2.ExecuteScalar());
                    // int noOfPendingOrders=Convert.ToInt32(command3.ExecuteScalar());
                    // int noOfUsers=Convert.ToInt32(command4.ExecuteScalar());
                    // int noOfSalesAmount=Convert.ToInt32(command5.ExecuteScalar());
                    // int noOfFeedBacks=Convert.ToInt32(command1.ExecuteScalar());
                    // int noOfTableBooked=Convert.ToInt32(command1.ExecuteScalar());
                }
            }
            catch(Exception exception){

            }
            return itemList;
    }
        public static void toCreate(NewEmployee employee)
        {
            try{
                using(SqlConnection connection=new SqlConnection(getConnection())){
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
            SqlConnection connection=new SqlConnection(getConnection());
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
            SqlConnection connection=new SqlConnection(getConnection());
            DataTable userdatas=new DataTable();
            try{
                SqlDataAdapter dataadapter=new SqlDataAdapter($"select * from expenseTable where approval!='Rejected'",connection);
                dataadapter.Fill(userdatas);
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
            finally{
                
            }        
            return userdatas;       
        }

        public static DataTable displayApprovedExpenses()
        {
            SqlConnection connection=new SqlConnection(getConnection());
            DataTable userdatas=new DataTable();
            try{
                SqlDataAdapter dataadapter=new SqlDataAdapter($"select * from expenseTable where approval='Approved'",connection);
                dataadapter.Fill(userdatas);
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
            finally{
                
            }        
            return userdatas;       
        }

        public static int displayTotal(string? employeeID)
        {
            SqlConnection connection=new SqlConnection(getConnection());
            int totalAmount=0;
            try{
                SqlCommand sumcommand=new SqlCommand($"select sum(cost) from expenseTable where approval='Approved'",connection);
                connection.Open();
                totalAmount=Convert.ToInt32(sumcommand.ExecuteScalar());
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
            finally{
                
            }  
            return totalAmount;
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

        public static string? isValidAdmin(NewEmployee employee){
            if((employee.employeeID=="A001" || employee.employeeID=="A002"))
                return "admin";
            return "notadmin";
        }

        public static bool isValidID(string? employeeID)
        {      
            SqlConnection connection=new SqlConnection(getConnection());                          
            SqlCommand command=new SqlCommand($"Select count(*) from userRecords1 where employeeID='{employeeID}'",connection);
            connection.Open();
            if(Convert.ToInt32(command.ExecuteScalar())==1)
            {
               connection.Close();
               return true;
            }
            connection.Close();
            return false;           
        }
        




         public static void deleteEmployee(string? employeeID)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command=new SqlCommand($"Delete from userRecords1 where employeeID = '{employeeID}'",connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


        public static void approveReimbursement(string? employeeID)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command=new SqlCommand($"UPDATE expTable SET approval = 'Approved' WHERE employeeID ='{employeeID}'",connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static string? getConnection()
        {
            var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            IConfiguration configuration = build.Build();
            string? connectionString = Convert.ToString(configuration.GetConnectionString("DB1"));
            return connectionString;
        }
        
        //  public static void removeEmployee(string employeeID)
        // {
        //    foreach(NewEmployee x in allEmployees)
        //    {
        //     if(x.employeeName==employeeID)
        //     {
        //         allEmployees.Remove(x);
        //         break;
        //     }
        //    }
        // }

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