using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.HasKey(x => x.AppointmentId);
            builder.Property(x => x.AppointmentId).HasColumnName("Id").ValueGeneratedOnAdd();


            builder.HasOne(x => x.PatientCase).WithMany(x => x.Appointments).HasForeignKey(x => x.PatientCaseId);
            builder.HasOne(x => x.Doctor).WithMany(x => x.Appointments).HasForeignKey(x => x.DoctorId);
            builder.HasOne(x => x.AppointmentStatus).WithMany(x => x.Appointments).HasForeignKey(x => x.AppointmentStatusId);
            builder.HasMany(x => x.StatusHistories).WithOne(x => x.Appointment).HasForeignKey(x => x.AppointmentId);
        }
    }
}
