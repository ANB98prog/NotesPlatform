namespace NotesApi.Models
{
    /// <summary>
    /// Create note model
    /// </summary>
    public record CreateNoteModel : NoteModel
    {
        protected CreateNoteModel(NoteModel original) : base(original)
        {
        }
    }
}
