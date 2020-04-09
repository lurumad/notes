using Microsoft.Extensions.Logging;

namespace Notes.Infrastructure.Diagnostics
{
    public static class EventIds
    {
        public static readonly int GetByFunctionRequestedId = 5000;
        public static readonly int CouldNotFoundNoteById = 5001;
        public static readonly int NoteAddedId = 5002;
        public static readonly EventId GetByFunctionRequested = new EventId(GetByFunctionRequestedId, nameof(GetByFunctionRequested));
        public static readonly EventId CouldNotFoundNoteBy = new EventId(CouldNotFoundNoteById, nameof(CouldNotFoundNoteBy));
        public static readonly EventId NoteAdded = new EventId(NoteAddedId, nameof(NoteAdded));
    }
}
