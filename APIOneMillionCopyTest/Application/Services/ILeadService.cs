using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Application.Services
{
    public interface ILeadService
    {
        Task<bool> DeleteAsync(int id);
        Task<PagedResult<Lead>> GetAsync(LeadQueryParams query);

        Task<Lead?> GetByIdAsync(int id);

        Task<bool> UpdateAsync(int id, UpdateLeadDto dto);

        Task<LeadStats> GetLeadStatsAsync();

        Task<string> GetAISummaryAsync(string? fuente, DateTime? from, DateTime? to);

    }
}
