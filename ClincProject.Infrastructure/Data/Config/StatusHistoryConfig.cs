using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    public class StatusHistoryConfig : IEntityTypeConfiguration<StatusHistory>
    {
        public void Configure(EntityTypeBuilder<StatusHistory> builder)
        {
            builder.ToTable("StatusHistories");
            builder.HasKey(x => x.StatusHistoryId);
            builder.Property(x => x.StatusHistoryId).HasColumnName("Id").ValueGeneratedOnAdd();

        }
    }
}
