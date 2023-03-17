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
            // Console.WriteLine("before");
            try{
                using(SqlConnection connection=new SqlConnection("Data Source=ASPIRE1879\\SQLEXPRESS;Initial Catalog=userDetails;Integrated Security=SSPI")){
                    SqlCommand command=new SqlCommand($"insert into travelsTable values('{Convert.ToString(travel.employeeID)}','{Convert.ToString(travel.toDestination)}','{Convert.ToString(travel.mediumofTravel)}','{Convert.ToString(travel.dateofTravel)}','{Convert.ToString(travel.returnDate)}','{Convert.ToString(travel.projectName)}')",connection);
                    // Console.WriteLine("after");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
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
        


    
    }
}