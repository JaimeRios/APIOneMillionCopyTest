using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Application.Services
{
    public interface ILeadService
    {
        Task<PagedResult<Lead>> GetAsync(LeadQueryParams query);

        Task<Lead?> GetByIdAsync(int id);

        Task<bool> UpdateAsync(int id, UpdateLeadDto dto);

    }
}
