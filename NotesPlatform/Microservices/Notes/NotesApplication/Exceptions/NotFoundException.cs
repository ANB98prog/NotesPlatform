namespace NotesApplication.Exceptions
{
    /// <summary>
    /// Not found exceptions
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes class instance of <see cref="NotFoundException"/>
        /// </summary>
        /// <param name="name">Entity name</param>
        /// <param name="key">Entity key</param>
        public NotFoundException(string name, object key) :
            base($"Note \"{name}\" ({key}) not found.")
        { }
    }
}
