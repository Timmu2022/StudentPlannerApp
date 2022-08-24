using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentPlannerApp.Models;

namespace StudentPlannerApp.Services
{
    public class UserService : IUserRepository
    {
        public SQLiteAsyncConnection _database;
        public UserService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserInfo>().Wait();
        }

        public async Task<bool> AddUserAsync(UserInfo userInfo)
        {
            if (userInfo.UserID > 0)
            {
                await _database.UpdateAsync(userInfo);
            }
            else
            {
                await _database.InsertAsync(userInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await _database.DeleteAsync<UserInfo>(id);
            return await Task.FromResult(true);
        }

        public async Task<UserInfo> GetUserAsync(int id) 
        {
            return await _database.Table<UserInfo>().Where(p => p.UserID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserInfo>> GetUserAsync()
        {
            return await Task.FromResult(await _database.Table<UserInfo>().ToListAsync());
        }

    }
}
