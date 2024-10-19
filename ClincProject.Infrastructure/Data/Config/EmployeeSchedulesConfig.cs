using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class EmployeeSchedulesConfig : IEntityTypeConfiguration<EmployeeSchedules>
    {
        public void Configure(EntityTypeBuilder<EmployeeSchedules> builder)
        {
            builder.ToTable("EmployeeSchedules");
            builder.HasKey(x => x.EmployeeSchedulesId);
            builder.Property(x => x.EmployeeSchedulesId).HasColumnName("Id").ValueGeneratedOnAdd();


            builder.HasOne(x => x.Doctor).WithMany(x => x.EmployeeSchedules).HasForeignKey(x => x.DoctorId);
            builder.HasOne(x => x.ClinicDepartment).WithMany(x => x.EmployeeSchedules).HasForeignKey(x => x.clinicDepartmentId);
            builder.HasMany(x => x.Schedules).WithOne(x => x.EmployeeSchedules).HasForeignKey(x => x.EmployeeSchedulesId);
        }
    }
}