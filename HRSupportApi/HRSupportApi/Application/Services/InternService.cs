using HRSupportApi.Application.DTOs;
using HRSupportApi.Application.Interfaces;
using HRSupportApi.Domain.Entities;
using HRSupportApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSupportApi.Application.Services
{
    public class InternService : IInternService
    {
        private readonly IInternRepository _repository;

        public InternService(IInternRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(InternDto dto)
        {
            var entity = new Intern
            {
                EmployeeId = dto.EmployeeId,
                University = dto.University,
                Department = dto.Department,
                Grade = dto.Grade,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                MentorId = dto.MentorId,
                Notes = dto.Notes
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<InternDto> GetByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return null;
            return new InternDto
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                University = e.University,
                Department = e.Department,
                Grade = e.Grade,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                MentorId = e.MentorId,
                Notes = e.Notes
            };
        }

        public async Task<IEnumerable<InternDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(e => new InternDto
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                University = e.University,
                Department = e.Department,
                Grade = e.Grade,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                MentorId = e.MentorId,
                Notes = e.Notes
            });
        }

        public async Task<int> UpdateAsync(InternDto dto)
        {
            var entity = new Intern
            {
                Id = dto.Id,
                EmployeeId = dto.EmployeeId,
                University = dto.University,
                Department = dto.Department,
                Grade = dto.Grade,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                MentorId = dto.MentorId,
                Notes = dto.Notes
            };

            return await _repository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
