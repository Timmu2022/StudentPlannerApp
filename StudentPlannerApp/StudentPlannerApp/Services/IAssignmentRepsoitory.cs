using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentPlannerApp.Models;

namespace StudentPlannerApp.Services
{
    public interface IAssignmentRepsoitory
    {
        Task<bool> AddAssignmentAsync(AssignmentInfo assignmentInfo);
        Task<bool> DeleteAssignmentAsync(int id);
        Task<AssignmentInfo> GetAssignmentAsync(int id);
        Task<IEnumerable<AssignmentInfo>> GetAssignmentAsync();
    }
}
