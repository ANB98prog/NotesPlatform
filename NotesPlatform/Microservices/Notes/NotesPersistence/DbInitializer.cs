namespace NotesPersistence
{
    /// <summary>
    /// Database initializer
    /// </summary>
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
