using HRSupportApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSupportApi.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(EmployeeDto dto);
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<int> UpdateAsync(EmployeeDto dto);
        Task<int> DeleteAsync(int id);
    }
}
