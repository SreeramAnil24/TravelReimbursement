using System;

namespace EmpManage.Models
{
    public class NewEmployee
    {
        public string? employeeID{get; set;}
        public string? employeeName{get; set;}
        public string? password{get; set;}
        public int age{get; set;}
        public decimal salary{get; set;}
        public string? department{get; set;}


        public string? toDestination{get; set;} 
        public string? mediumofTravel{get; set;}
        public int travelNo{get; set;}
        public string? dateofTravel{get; set;}
        public int noofDays{get; set;}



        public int expNo{get; set;}
        public string? expense{get; set;}
        
        public string?expdate{get; set;}

        public int cost{get; set;}

        public string? currency{get; set;}

     


        

    }
}