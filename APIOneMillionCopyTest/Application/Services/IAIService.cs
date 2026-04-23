using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Application.Services
{
    public interface IAIService
    {
        Task<string> GenerateSummaryAsync(List<Lead> leads, string prompt);
    }
}
