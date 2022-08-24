using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPlannerApp.Models
{
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; } 
        public string Forename { get; set; }  
        public string Surname { get; set; } 
        public DateTime DOB { get; set; } 
    }
}
