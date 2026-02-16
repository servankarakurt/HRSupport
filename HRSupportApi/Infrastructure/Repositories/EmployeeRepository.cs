using Dapper;
using HRSupportApi.Domain.Entities;
using HRSupportApi.Infrastructure.Context;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HRSupportApi.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<int> AddAsync(Employee employee);
        Task<Employee> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<int> UpdateAsync(Employee employee);
        Task<int> DeleteAsync(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context) { _context = context; }
        {
            _context = context;
        }

        public async Task<int> AddAsync(Employee employee)
        {
            var sql = @"INSERT INTO Employees (FirstName, LastName, Email, Phone, Department, Position, HireDate, IsActive, Type, PasswordHash)
                        VALUES (@FirstName, @LastName, @Email, @Phone, @Department, @Position, @HireDate, @IsActive, @Type, @PasswordHash);
                        SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(sql, employee);
            return id;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Employees WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var sql = "SELECT * FROM Employees";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Employee>(sql);
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            var sql = @"UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone,
                            Department = @Department, Position = @Position, HireDate = @HireDate, IsActive = @IsActive, Type = @Type, PasswordHash = @PasswordHash
                         WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, employee);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
