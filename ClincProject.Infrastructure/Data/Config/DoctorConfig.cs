using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(x => x.DoctorId);
            builder.Property(x => x.DoctorId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnType("varchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(20).IsRequired(false);

        }
    }
}
