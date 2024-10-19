using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentTypes");
            builder.HasKey(x => x.DocumentTypeId);
            builder.Property(x => x.DocumentTypeId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.TypeName).HasColumnType("varchar").HasMaxLength(100).IsRequired();

        }
    }
}