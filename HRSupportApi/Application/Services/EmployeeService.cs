using HRSupportApi.Application.DTOs;
using HRSupportApi.Application.Interfaces;
using HRSupportApi.Domain.Entities;
using HRSupportApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSupportApi.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(EmployeeDto dto)
        {
            var entity = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Department = dto.Department,
                Position = dto.Position,
                HireDate = dto.HireDate,
                IsActive = dto.IsActive,
                Type = dto.Type,
                PasswordHash = null
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return null;
            return new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                Department = e.Department,
                Position = e.Position,
                HireDate = e.HireDate,
                IsActive = e.IsActive,
                Type = e.Type
            };
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                Department = e.Department,
                Position = e.Position,
                HireDate = e.HireDate,
                IsActive = e.IsActive,
                Type = e.Type
            });
        }

        public async Task<int> UpdateAsync(EmployeeDto dto)
        {
            var entity = new Employee
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Department = dto.Department,
                Position = dto.Position,
                HireDate = dto.HireDate,
                IsActive = dto.IsActive,
                Type = dto.Type
            };

            return await _repository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
