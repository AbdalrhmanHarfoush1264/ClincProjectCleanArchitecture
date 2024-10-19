using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class DocumentConfig : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            builder.HasKey(x => x.DocumentId);
            builder.Property(x => x.DocumentId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.DocumentName).HasColumnType("varchar").HasMaxLength(200).IsRequired();


            builder.HasOne(x => x.DocumentType).WithMany(x => x.Documents).HasForeignKey(x => x.DocumentTypeId);
            builder.HasOne(x => x.Appointment).WithMany(x => x.Documents).HasForeignKey(x => x.AppointmentId);
        }
    }
}
