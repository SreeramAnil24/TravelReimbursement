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
                    SqlCommand command=new SqlCommand($"insert into travelTable values('{Convert.ToString(travel.travelNo)}','{Convert.ToString(travel.toDestination)}','{Convert.ToString(travel.mediumofTravel)}','{Convert.ToString(travel.dateofTravel)}','{Convert.ToString(travel.noofDays)}')",connection);
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
            try{
                using(SqlConnection connection=new SqlConnection("Data Source=ASPIRE1879\\SQLEXPRESS;Initial Catalog=userDetails;Integrated Security=SSPI"))
                {
                    SqlCommand command=new SqlCommand($"insert into expenseTable values('{Convert.ToString(travel.expNo)}','{Convert.ToString(travel.expense)}','{Convert.ToString(travel.expdate)}','{Convert.ToString(travel.cost)}','{Convert.ToString(travel.currency)}')",connection);
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