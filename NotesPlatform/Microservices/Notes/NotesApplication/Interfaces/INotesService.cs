using NotesDomain;

namespace NotesApplication.Interfaces
{
    /// <summary>
    /// Notes service interface
    /// </summary>
    public interface INotesService
    {
        /// <summary>
        /// Create new note
        /// </summary>
        /// <param name="title">Note title</param>
        /// <param name="content">Note content</param>
        /// <returns>Created note</returns>
        public Task<Note> CreateNoteAsync(string title, string content);

        /// <summary>
        /// Updates existing note
        /// </summary>
        /// <param name="id">Note id</param>
        /// <param name="title">Note title</param>
        /// <param name="content">Note content</param>
        /// <returns>Updated note</returns>
        public Task<Note> UpdateNoteAsync(Guid id, string title, string content);

        /// <summary>
        /// Deletes note
        /// </summary>
        /// <param name="id">Note id</param>
        /// <returns>None</returns>
        public Task DeleteNoteAsync(Guid id);

        /// <summary>
        /// Get note by id
        /// </summary>
        /// <param name="id">Note id</param>
        /// <returns>Note</returns>
        public Task<Note> GetNoteByIdAsync(Guid id);

        /// <summary>
        /// Gets all notes
        /// </summary>
        /// <returns>List of notes</returns>
        public Task<IEnumerable<Note>> GetNotesListAsync();
    }
}
