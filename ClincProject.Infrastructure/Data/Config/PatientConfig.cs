using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(x => x.PatientId);
            builder.Property(x => x.PatientId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnType("varchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(20).IsRequired(false);

            builder.HasMany(x => x.PatientCases).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
        }
    }
}