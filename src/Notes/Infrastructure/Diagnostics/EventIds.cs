using Microsoft.Extensions.Logging;

namespace Notes.Infrastructure.Diagnostics
{
    public static class EventIds
    {
        public static readonly int GetNotesById = 5000;
        public static readonly int CouldNotFoundNoteById = 5001;
        public static readonly int NoteAddedId = 5002;
        public static readonly int GetNotesByUserId = 5003;
        public static readonly int DeleteNotesById = 5004;
        public static readonly int DeleteNotesByUserId = 5005;

        public static readonly EventId GetNotesBy = new EventId(GetNotesById, nameof(GetNotesBy));
        public static readonly EventId CouldNotFoundNoteBy = new EventId(CouldNotFoundNoteById, nameof(CouldNotFoundNoteBy));
        public static readonly EventId NoteAdded = new EventId(NoteAddedId, nameof(NoteAdded));
        public static readonly EventId GetNotesByUser = new EventId(GetNotesByUserId, nameof(GetNotesByUser));
        public static readonly EventId DeleteNotesBy = new EventId(DeleteNotesById, nameof(DeleteNotesBy));
        public static readonly EventId DeleteNotesByUser = new EventId(DeleteNotesByUserId, nameof(DeleteNotesByUser));
    }
}
