using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;
using APIOneMillionCopyTest.Infrastructure.Repositories;

namespace APIOneMillionCopyTest.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }
        public async Task<object> GetAsync(LeadQueryParams query)
        {
            query.Page = query.Page < 1 ? 1 : query.Page;
            query.Limit = query.Limit > 50 ? 50 : query.Limit;

            var (data, total) = await _leadRepository.GetAsync(query);

            return new
            {
                total,
                page = query.Page,
                limit = query.Limit,
                totalPages = (int)Math.Ceiling(total / (double)query.Limit),
                data
            };
        }

        public Task<Lead?> GetByIdAsync(int id)
        {
            return _leadRepository.GetByIdAsync(id);
        }
    }
}
