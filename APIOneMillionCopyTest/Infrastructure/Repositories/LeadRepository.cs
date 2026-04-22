using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Domain.Entities;
using APIOneMillionCopyTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace APIOneMillionCopyTest.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly AppDbContext _context;

        public LeadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Lead lead)
        {
            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<Lead>, int)> GetAsync(LeadQueryParams query)
        {
            var leadsQuery = _context.Leads.AsQueryable();

            // 🔍 Filtro por fuente
            if (!string.IsNullOrEmpty(query.Fuente))
            {
                leadsQuery = leadsQuery.Where(l => l.Fuente == query.Fuente);
            }

            // 📅 Filtro por fechas
            if (query.From.HasValue)
            {
                leadsQuery = leadsQuery.Where(l => l.CreatedAt >= query.From.Value);
            }

            if (query.To.HasValue)
            {
                leadsQuery = leadsQuery.Where(l => l.CreatedAt <= query.To.Value);
            }

            var total = await leadsQuery.CountAsync();

            var data = await leadsQuery
                .OrderByDescending(l => l.CreatedAt)
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit)
                .ToListAsync();

            return (data, total);
        }

        public async Task<Lead?> GetByEmailAsync(string email)
        {
            return await _context.Leads
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Lead?> GetByIdAsync(int id)
        {
            return await _context.Leads
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task Update(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }
    }
}
