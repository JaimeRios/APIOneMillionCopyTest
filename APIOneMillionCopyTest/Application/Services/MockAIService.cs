using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Application.Services
{
    public class MockAIService : IAIService
    {
        public Task<string> GenerateSummaryAsync(List<Lead> leads,string prompt)
        {
            if (leads == null || !leads.Any())
            {
                return Task.FromResult("No hay leads para analizar.");
            }

            var total = leads.Count;
            var principalFuente = leads
                .GroupBy(l => l.Fuente)
                .OrderByDescending(g => g.Count())
                .First().Key;

            var promedio = leads
                .Where(l => l.Presupuesto.HasValue)
                .Select(l => l.Presupuesto.Value)
                .DefaultIfEmpty(0)
                .Average();

            var resumen = $@"
Resumen Ejecutivo:

- Total de leads: {total}
- Fuente principal: {principalFuente}
- Presupuesto promedio: {promedio:F2} USD

Recomendaciones:
- Enfocar inversión en {principalFuente}
- Optimizar campañas en fuentes con menor conversión
- Analizar leads recientes para detectar tendencias
";

            return Task.FromResult(resumen);
        }
    }
}
