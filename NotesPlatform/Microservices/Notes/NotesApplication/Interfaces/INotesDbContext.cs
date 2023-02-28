using Microsoft.EntityFrameworkCore;
using NotesDomain;

namespace NotesApplication.Interfaces
{
    /// <summary>
    /// Notes db context interface
    /// </summary>
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}