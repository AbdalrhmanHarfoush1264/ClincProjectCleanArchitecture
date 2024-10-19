using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class ClinicDepartmentConfig : IEntityTypeConfiguration<ClinicDepartment>
    {
        public void Configure(EntityTypeBuilder<ClinicDepartment> builder)
        {
            builder.ToTable("ClinicDepartments");
            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.DepartmentName).HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
        }
    }
}
