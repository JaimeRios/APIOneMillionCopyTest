using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Application.Services
{
    public interface ILeadService
    {
        Task<object> GetAsync(LeadQueryParams query);

        Task<Lead?> GetByIdAsync(int id);

    }
}
