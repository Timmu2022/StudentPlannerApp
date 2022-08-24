using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentPlannerApp.Models;

namespace StudentPlannerApp.Services
{
    public class AssignmentService : IAssignmentRepsoitory
    {
        public SQLiteAsyncConnection _database;
        public AssignmentService(string dbPath) 
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AssignmentInfo>().Wait();
        }

        //Insert & Update
        public async Task<bool> AddAssignmentAsync(AssignmentInfo assignmentInfo)
        {
            if(assignmentInfo.AssignmentID > 0)
            {
                await _database.UpdateAsync(assignmentInfo);
            }
            else
            {
                await _database.InsertAsync(assignmentInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            await _database.DeleteAsync<AssignmentInfo>(id);
            return await Task.FromResult(true);
        }

        public async Task<AssignmentInfo> GetAssignmentAsync(int id)
        {
            return await _database.Table<AssignmentInfo>().Where(p => p.AssignmentID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AssignmentInfo>> GetAssignmentAsync()
        {
            return await Task.FromResult(await _database.Table<AssignmentInfo>().ToListAsync());
        }
    }
}
