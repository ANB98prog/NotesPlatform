using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesDomain;

namespace NotesPersistence.EntityTypeConfigurations
{
    /// <summary>
    /// Note entity configuration
    /// </summary>
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title)
                .HasMaxLength(250)
                    .IsRequired(false);
            builder.Property(note => note.Content)
                .HasMaxLength(1024)
                    .IsRequired(false);
        }
    }
}