using HRSupportApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSupportApi.Application.Interfaces
{
    public interface ILeaveService
    {
        Task<int> CreateAsync(LeaveRequestDto dto);
        Task<LeaveRequestDto> GetByIdAsync(int id);
        Task<IEnumerable<LeaveRequestDto>> GetAllAsync();
        Task<int> UpdateAsync(LeaveRequestDto dto);
        Task<int> DeleteAsync(int id);
    }
}
