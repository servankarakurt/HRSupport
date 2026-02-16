using Dapper;
using HRSupportApi.Domain.Entities;
using HRSupportApi.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSupportApi.Infrastructure.Repositories
{
    public interface IInternRepository
    {
        Task<int> AddAsync(Intern intern);
        Task<Intern> GetByIdAsync(int id);
        Task<IEnumerable<Intern>> GetAllAsync();
        Task<int> UpdateAsync(Intern intern);
        Task<int> DeleteAsync(int id);
    }

    public class InternRepository : IInternRepository
    {
        private readonly DapperContext _context;

        public InternRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Intern intern)
        {
            var sql = @"INSERT INTO Interns (EmployeeId, University, Department, Grade, StartDate, EndDate, MentorId, Notes)
                        VALUES (@EmployeeId, @University, @Department, @Grade, @StartDate, @EndDate, @MentorId, @Notes);
                        SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(sql, intern);
            return id;
        }

        public async Task<Intern> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Interns WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Intern>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Intern>> GetAllAsync()
        {
            var sql = "SELECT * FROM Interns";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Intern>(sql);
        }

        public async Task<int> UpdateAsync(Intern intern)
        {
            var sql = @"UPDATE Interns SET EmployeeId = @EmployeeId, University = @University, Department = @Department,
                            Grade = @Grade, StartDate = @StartDate, EndDate = @EndDate, MentorId = @MentorId, Notes = @Notes
                         WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, intern);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Interns WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
