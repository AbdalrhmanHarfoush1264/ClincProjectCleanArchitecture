using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class AppointmentStatusConfig : IEntityTypeConfiguration<AppointmentStatus>
    {
        public void Configure(EntityTypeBuilder<AppointmentStatus> builder)
        {
            builder.ToTable("AppointmentStatuses");
            builder.HasKey(x => x.AppointmentStatusId);
            builder.Property(x => x.AppointmentStatusId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.StatusName).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.StatusHistories).WithOne(x => x.AppointmentStatus).HasForeignKey(x => x.AppointmentStatusID);
        }
    }
}
