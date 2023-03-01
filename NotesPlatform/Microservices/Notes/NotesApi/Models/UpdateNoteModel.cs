namespace NotesApi.Models
{
    /// <summary>
    /// Update note model
    /// </summary>
    public record UpdateNoteModel : NoteModel
    {
        public UpdateNoteModel(string Title, string Content) : base(Title, Content){}
    }
}
