using HRSupportApi.Application.DTOs;
using HRSupportApi.Application.Interfaces;
using HRSupportApi.Domain.Entities;
using HRSupportApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSupportApi.Application.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _repository;

        public LeaveService(ILeaveRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(LeaveRequestDto dto)
        {
            var entity = new LeaveRequest
            {
                EmployeeId = dto.EmployeeId,
                LeaveType = dto.LeaveType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                Status = dto.Status,
                CreatedDate = dto.CreatedDate,
                ProcessDate = dto.ProcessDate,
                RejectionReason = dto.RejectionReason
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<LeaveRequestDto> GetByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return null;
            return new LeaveRequestDto
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                LeaveType = e.LeaveType,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
                Status = e.Status,
                CreatedDate = e.CreatedDate,
                ProcessDate = e.ProcessDate,
                RejectionReason = e.RejectionReason
            };
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(e => new LeaveRequestDto
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                LeaveType = e.LeaveType,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
                Status = e.Status,
                CreatedDate = e.CreatedDate,
                ProcessDate = e.ProcessDate,
                RejectionReason = e.RejectionReason
            });
        }

        public async Task<int> UpdateAsync(LeaveRequestDto dto)
        {
            var entity = new LeaveRequest
            {
                Id = dto.Id,
                EmployeeId = dto.EmployeeId,
                LeaveType = dto.LeaveType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                Status = dto.Status,
                CreatedDate = dto.CreatedDate,
                ProcessDate = dto.ProcessDate,
                RejectionReason = dto.RejectionReason
            };

            return await _repository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
