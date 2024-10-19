namespace ClincProject.Data.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; } = null!;
        public DateOnly TimeCreated { get; set; }
        public string? Details { get; set; }


        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; } = null!;

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

    }
}
