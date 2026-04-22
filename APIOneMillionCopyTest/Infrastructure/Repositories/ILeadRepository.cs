using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Infrastructure.Repositories
{
    public interface ILeadRepository
    {
        Task<(List<Lead>, int)> GetAsync(LeadQueryParams query);
        
        Task<Lead?> GetByIdAsync(int id); 
    }
}
