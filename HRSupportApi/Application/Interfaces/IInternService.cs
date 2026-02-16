using HRSupportApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSupportApi.Application.Interfaces
{
    public interface IInternService
    {
        Task<int> CreateAsync(InternDto dto);
        Task<InternDto> GetByIdAsync(int id);
        Task<IEnumerable<InternDto>> GetAllAsync();
        Task<int> UpdateAsync(InternDto dto);
        Task<int> DeleteAsync(int id);
    }
}
