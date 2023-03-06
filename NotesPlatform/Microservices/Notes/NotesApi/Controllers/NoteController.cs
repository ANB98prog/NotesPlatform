using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using NotesApplication.Interfaces;
using NotesDomain;

namespace NotesApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {
        private INotesService _notesService;

        public NoteController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpPost("create")]
        public async Task<Note> CreateNoteAsync([FromBody] CreateNoteModel note)
        {
            return await _notesService.CreateNoteAsync(note.Title, note.Content);
        }

        [HttpGet("{id}")]
        public async Task<Note> GetNoteByIdAsync(Guid id)
        {
            return await _notesService.GetNoteByIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteByIdAsync(Guid id)
        {
            await _notesService.DeleteNoteAsync(id);

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateNoteAsync(Guid id, UpdateNoteModel note)
        {
            var (title, content) = note;
            await _notesService.UpdateNoteAsync(id, title, content);

            return NoContent();

        }


        [HttpGet("list")]
        public async Task<IEnumerable<Note>> GetNotesList()
        {
            return await _notesService.GetNotesListAsync();
        }
    }
}
