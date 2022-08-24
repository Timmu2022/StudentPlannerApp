using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentPlannerApp.Models;

namespace StudentPlannerApp.Services
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(UserInfo userInfo);
        Task<bool> DeleteUserAsync(int id);
        Task<UserInfo> GetUserAsync(int id);
        Task<IEnumerable<UserInfo>> GetUserAsync(); 
    }
}
