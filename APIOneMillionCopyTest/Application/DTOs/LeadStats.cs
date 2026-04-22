using APIOneMillionCopyTest.Domain.Entities;

namespace APIOneMillionCopyTest.Application.DTOs
{
    public class LeadStats
    {
        public int TotalLeads {  get; set; }
        public required Dictionary<string, int> LeadsPorFuente { get; set; }
        public decimal PromedioPresupuesto { get; set; }

        public required List<Lead> LeadsUltimos7Dias { get; set; }
    }
}
