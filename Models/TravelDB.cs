using System;
using System.Data.SqlClient;
using System.Data;

namespace EmpManage.Models
{
    public class TravelDB
    {
        private static List<NewEmployee> allEmployees=new List<NewEmployee>();
        public static IEnumerable<NewEmployee> AllEmployees
        {
            get
            {
                return allEmployees;
            }
        }


        public static void addTravel(NewEmployee travel)
        {   
            try{
                using(SqlConnection connection=new SqlConnection("Data Source=ASPIRE1879\\SQLEXPRESS;Initial Catalog=userDetails;Integrated Security=SSPI")){
                    SqlCommand command=new SqlCommand($"insert into travelsTable values('{Convert.ToString(travel.employeeID)}','{Convert.ToString(travel.toDestination)}','{Convert.ToString(travel.mediumofTravel)}','{Convert.ToString(travel.dateofTravel)}','{Convert.ToString(travel.returnDate)}','{Convert.ToString(travel.projectName)}')",connection); 
                    connection.Open();
                    command.ExecuteNonQuery();                }
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
        }

        public static void addExpense(NewEmployee travel)
        {
            if(Convert.ToString(travel.expense)!=null){
                try{
                    
                    using(SqlConnection connection=new SqlConnection("Data Source=ASPIRE1879\\SQLEXPRESS;Initial Catalog=userDetails;Integrated Security=SSPI"))
                    {
                        SqlCommand command=new SqlCommand($"insert into expsTable values('{Convert.ToString(travel.expense)}','{Convert.ToString(travel.expdate)}','{Convert.ToString(travel.cost)}','{Convert.ToString(travel.currency)}',@value, 'pending')",connection);
                        command.Parameters.AddWithValue("@value",travel.imageUrl);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch(Exception exception){
                    Console.WriteLine(exception.Message);
                }
            }
        }
        
        public static void changeApproval(string? approvalstatus, string? exp_number)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command=new SqlCommand($"UPDATE expsTable SET approval='{approvalstatus}' WHERE exp_no='{exp_number}'",connection);
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
    
    }
}