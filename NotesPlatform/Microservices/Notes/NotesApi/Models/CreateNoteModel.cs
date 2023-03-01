namespace NotesApi.Models
{
    /// <summary>
    /// Create note model
    /// </summary>
    public record CreateNoteModel : NoteModel
    {
        public CreateNoteModel(string? Title, string? Content) : base(Title, Content)
        {
        }
    }
}
