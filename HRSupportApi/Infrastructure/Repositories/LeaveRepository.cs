using Dapper;
using HRSupportApi.Domain.Entities;
using HRSupportApi.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSupportApi.Infrastructure.Repositories
{
    public interface ILeaveRepository
    {
        Task<int> AddAsync(LeaveRequest leave);
        Task<LeaveRequest> GetByIdAsync(int id);
        Task<IEnumerable<LeaveRequest>> GetAllAsync();
        Task<int> UpdateAsync(LeaveRequest leave);
        Task<int> DeleteAsync(int id);
    }

    public class LeaveRepository : ILeaveRepository
    {
        private readonly DapperContext _context;

        public LeaveRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(LeaveRequest leave)
        {
            var sql = @"INSERT INTO LeaveRequests (EmployeeId, LeaveType, StartDate, EndDate, Description, Status, CreatedDate, ProcessDate, RejectionReason)
                        VALUES (@EmployeeId, @LeaveType, @StartDate, @EndDate, @Description, @Status, @CreatedDate, @ProcessDate, @RejectionReason);
                        SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(sql, leave);
            return id;
        }

        public async Task<LeaveRequest> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM LeaveRequests WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<LeaveRequest>(sql, new { Id = id });
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            var sql = "SELECT * FROM LeaveRequests";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<LeaveRequest>(sql);
        }

        public async Task<int> UpdateAsync(LeaveRequest leave)
        {
            var sql = @"UPDATE LeaveRequests SET EmployeeId = @EmployeeId, LeaveType = @LeaveType, StartDate = @StartDate, EndDate = @EndDate,
                            Description = @Description, Status = @Status, CreatedDate = @CreatedDate, ProcessDate = @ProcessDate, RejectionReason = @RejectionReason
                         WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, leave);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM LeaveRequests WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
