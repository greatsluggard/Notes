using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Entities;

namespace Notes.DAL.Configuration
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.Property(x => x.ReminderId).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(2000);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Reminders)
                .UsingEntity<ReminderTag>(
                    l => l.HasOne<Tag>().WithMany().HasForeignKey(x => x.TagId),
                    l => l.HasOne<Reminder>().WithMany().HasForeignKey(x => x.ReminderId)); 
        }
    }
}