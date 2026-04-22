using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;
using APIOneMillionCopyTest.Domain.Enums;
using APIOneMillionCopyTest.Domain.Exceptions;
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

        public async Task<bool> DeleteAsync(int id)
        {
            var lead = await _leadRepository.GetByIdAsync(id);

            if (lead == null)
                return false;

            await _leadRepository.Delete(lead);

            return true;
        }

        public async Task<PagedResult<Lead>> GetAsync(LeadQueryParams query)
        {
            query.Page = query.Page < 1 ? 1 : query.Page;
            query.Limit = query.Limit > 50 ? 50 : query.Limit;

            var (data, total) = await _leadRepository.GetAsync(query);

            return new PagedResult<Lead>
            {
                Total = total,
                Page = query.Page,
                Limit = query.Limit,
                TotalPages = (int)Math.Ceiling(total / (double)query.Limit),
                Data = data
            };
        }

        public Task<Lead?> GetByIdAsync(int id)
        {
            return _leadRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateLeadDto dto)
        {

            var lead = await _leadRepository.GetByIdAsync(id);

            if (lead == null)
                return false;

            if (!string.IsNullOrEmpty(dto.Email))
            {
                var duplicateEmail = await _leadRepository.GetByEmailAsync(dto.Email);

                if (duplicateEmail != null && duplicateEmail.Id != id)
                    throw new EmailAlreadyExistsException(dto.Email);

                lead.Email = dto.Email;
            }

            if (!string.IsNullOrEmpty(dto.Fuente))
            {
                if (!Enum.TryParse<Fuente>(dto.Fuente, true, out var fuenteEnum))
                    throw new FuenteNoValidException(dto.Fuente);

                lead.Fuente = fuenteEnum.ToString().ToLower();
            }
            
            if(!string.IsNullOrEmpty(dto.Nombre))
                lead.Nombre = dto.Nombre;

            if (!string.IsNullOrEmpty(dto.ProductoInteres))
                lead.Nombre = dto.ProductoInteres;

            lead.CreatedAt = DateTime.SpecifyKind(lead.CreatedAt, DateTimeKind.Utc);
            lead.UpdatedAt = DateTime.UtcNow;

            await _leadRepository.Update(lead);

            return true;

        }

        public async Task<LeadStats> GetLeadStatsAsync()
        {
            return await _leadRepository.GetStatsAsync();
        }
    }
}
