namespace APIOneMillionCopyTest.Application.DTOs
{
    public class LeadQueryParams
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;

        public string? Fuente { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
