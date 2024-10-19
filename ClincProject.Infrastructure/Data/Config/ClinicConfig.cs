using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class ClinicConfig : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("Clinics");
            builder.HasKey(x => x.ClinicId);
            builder.Property(x => x.ClinicId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Address).HasColumnType("varchar").HasMaxLength(700).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(500).IsRequired(false);

            builder.HasMany(x => x.ClinicDepartments).WithOne(x => x.Clinic).HasForeignKey(x => x.ClinicId);
        }
    }
}