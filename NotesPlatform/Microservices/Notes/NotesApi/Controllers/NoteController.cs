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
    }
}
