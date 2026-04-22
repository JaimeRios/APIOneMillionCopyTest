using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Infrastructure.Repositories
{
    public interface ILeadRepository
    {
        Task Delete(Lead lead);
        Task<(List<Lead>, int)> GetAsync(LeadQueryParams query);

        Task<Lead?> GetByEmailAsync(string email);

        Task<Lead?> GetByIdAsync(int id);

        Task Update(Lead lead);
    }
}
