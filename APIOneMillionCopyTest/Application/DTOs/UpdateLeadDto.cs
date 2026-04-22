namespace APIOneMillionCopyTest.Application.DTOs
{
    public class UpdateLeadDto
    {
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Fuente { get; set; } = null!;
        public string? ProductoInteres { get; set; }
        public decimal? Presupuesto { get; set; }
    }
}
