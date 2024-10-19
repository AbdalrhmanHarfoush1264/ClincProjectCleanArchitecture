namespace ClincProject.Data.Entities
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public ICollection<Document>? Documents { get; set; } = new HashSet<Document>();
    }
}
