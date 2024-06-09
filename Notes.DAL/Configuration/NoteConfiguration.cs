using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Entities;

namespace Notes.DAL.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(x => x.NoteId).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(2000);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Notes)
                .UsingEntity<NoteTag>(
                    l => l.HasOne<Tag>().WithMany().HasForeignKey(x => x.TagId),
                    l => l.HasOne<Note>().WithMany().HasForeignKey(x => x.NoteId)); 
        }
    }
}