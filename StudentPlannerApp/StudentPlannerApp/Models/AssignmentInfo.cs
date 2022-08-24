using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPlannerApp.Models
{
    public class AssignmentInfo
    {
        [PrimaryKey, AutoIncrement]
        public int AssignmentID { get; set; }
        public string AssignmentName { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string AssignmentNotes { get; set; } 
    }
}
