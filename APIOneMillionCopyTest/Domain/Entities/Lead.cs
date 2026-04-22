namespace APIOneMillionCopyTest.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Fuente { get; set; } = null!;
        public string? ProductoInteres { get; set; }
        public decimal? Presupuesto { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
