using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AssignmentTrackerApp.Models
{
    public class Assignment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string DueDate { get; set; }
        public string StartDate { get; set; }
        public bool AssignmentCategory { get; set; }
        public bool ClassTaskCategory { get; set; }
        public bool RevisionCategory { get; set; }
        public bool LowPriority { get; set; }
        public bool MediumPriority { get; set; }
        public bool HighPriority { get; set; }
        public string Module { get; set; }
        public string Notes { get; set; }
        public bool Incomplete { get; set; }
        public bool InProgress { get; set; }
        public bool Completed { get; set; }
    }
}