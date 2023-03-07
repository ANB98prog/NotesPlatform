using ApiExceptions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using NotesApplication.Interfaces;
using NotesDomain;
using NotesApplication.Models;

namespace NotesApplication.Services
{
    /// <summary>
    /// Notes service
    /// </summary>
    public class NotesService : INotesService
    {
        /// <summary>
        /// Logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Notes db context
        /// </summary>
        private INotesDbContext _notes;

        /// <summary>
        /// Initializes class instance of <see cref="NotesService"/>
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="context">Notes db context</param>
        public NotesService(ILogger logger, INotesDbContext context)
        {
            _logger = logger;
            _notes = context;
        }

        /// <inheritdoc/>
        public async Task<Note> CreateNoteAsync(string title, string content)
        {
            try
            {
                _logger.Information("Try to create new note.");

                var note = new Note(title, content);

                await _notes.Notes.AddAsync(note);
                await _notes.SaveChangesAsync(CancellationToken.None);

                _logger.Information($"Note created: {title} with id: {note.Id}");

                return note;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured while note creation.");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task DeleteNoteAsync(Guid id)
        {
            try
            {
                _logger.Information($"Try to delete note with id {id}.");

                var note = await _notes.Notes
                    .FindAsync(new object[] { id });

                if (note == null)
                {
                    throw new NotFoundException(nameof(Note), id);
                }

                _notes.Notes.Remove(note);
                await _notes.SaveChangesAsync(CancellationToken.None);

                _logger.Information($"Note deleted: {id}");

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured while note removing.");
                throw;
            }
        }

        public async Task DeleteNotesListAsync(Guid[] ids)
        {
            try
            {
                _logger.Information($"Try to delete list of notes. Count: {ids.Length}");

                var notes = await _notes.Notes.Where(n => ids.Contains(n.Id)).ToListAsync();

                if (notes.Any())
                {
                    _notes.Notes.RemoveRange(notes);
                    await _notes.SaveChangesAsync(CancellationToken.None); 
                }

                _logger.Information($"Notes deleted: {notes.Count}");

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured while list of notes removing.");
                throw;
            }
        }

        public async Task<IEnumerable<Note>> GetNotesListAsync(GetNotesListQuery query)
        {
            try
            {
                _logger.Information($"Try to get list notes.");

                var from = query.PageNumber * query.PageSize;
                var take = query.PageSize;

                var notes = await _notes.Notes
                                    .Skip(from)
                                        .Take(take)
                                            .ToListAsync();

                _logger.Information($"Notes successfully got. Count {notes.Count}");

                return notes;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured while get notes list.");
                throw;
            }
        }

        public async Task<Note> GetNoteByIdAsync(Guid id)
        {
            try
            {
                _logger.Information($"Try to get note by id {id}.");

                var note = await _notes.Notes
                    .FindAsync(new object[] { id });

                if (note == null)
                {
                    throw new NotFoundException(nameof(Note), id);
                }

                _logger.Information($"Note successfully got.");

                return note;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured while getting note by id.");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<Note> UpdateNoteAsync(Guid id, string title, string content)
        {
            try
            {
                _logger.Information("Try to update existing note.");

                var note = await _notes.Notes
                    .FindAsync(new object[] { id });

                if (note == null)
                {
                    throw new NotFoundException(nameof(Note), id);
                }

                note.Title = title;
                note.Content = content;
                note.EditDate = DateTime.UtcNow;

                _notes.Notes.Update(note);
                await _notes.SaveChangesAsync(CancellationToken.None);

                _logger.Information($"Note updated {note.Id}");

                return note;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured while note updating.");
                throw;
            }
        }
    }
}
