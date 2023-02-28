using System.ComponentModel.DataAnnotations.Schema;

namespace NotesDomain
{
    /// <summary>
    /// Note entity
    /// </summary>
    [Table("Notes")]
    public class Note
    {
        /// <summary>
        /// Note id
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Note title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Note text
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Edit date
        /// </summary>
        public DateTime? EditDate { get; set; }
    }
}