using ClincProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClincProject.Infrastructure.Data.Config
{
    internal class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(x => x.MessageId);
            builder.Property(x => x.MessageId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(50).IsRequired(false);
        }
    }
}
