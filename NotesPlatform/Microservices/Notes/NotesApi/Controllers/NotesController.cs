using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using NotesApplication.Interfaces;
using NotesDomain;

namespace NotesApi.Controllers
{
    /// <summary>
    /// Controller to work with notes
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NotesController : BaseController
    {
        /// <summary>
        /// Notes service
        /// </summary>
        private INotesService _notesService;

        /// <summary>
        /// Initializes class instance of <see cref="NotesController"/>
        /// </summary>
        /// <param name="notesService">Notes service</param>
        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        /// <summary>
        /// Craetes a new note
        /// </summary>
        /// <returns>Return Note</returns>
        /// <response code="201">Created</response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<Note> CreateNoteAsync([FromBody] CreateNoteModel note)
        {
            return await _notesService.CreateNoteAsync(note.Title, note.Content);
        }

        /// <summary>
        /// Get note by id
        /// </summary>
        /// <returns>Return Note</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Note> GetNoteByIdAsync(Guid id)
        {
            return await _notesService.GetNoteByIdAsync(id);
        }

        /// <summary>
        /// Get notes list
        /// </summary>
        /// <returns>Return list of Note</returns>
        /// <response code="200">Success</response>
        [HttpGet()]
        public async Task<IEnumerable<Note>> GetNotesList()
        {
            return await _notesService.GetNotesListAsync();
        }

        /// <summary>
        /// Removes note by id
        /// </summary>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteNoteByIdAsync(Guid id)
        {
            await _notesService.DeleteNoteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Updates note
        /// </summary>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        [HttpPatch]
        public async Task<IActionResult> UpdateNoteAsync(Guid id, UpdateNoteModel note)
        {
            var (title, content) = note;
            await _notesService.UpdateNoteAsync(id, title, content);

            return NoContent();
        }
    }
}
