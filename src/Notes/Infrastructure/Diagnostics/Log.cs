using Notes.Infrastructure.Diagnostics;
using System;

namespace Microsoft.Extensions.Logging
{
    public static class Log
    {
        private static readonly Action<ILogger, string, Exception> _getNotesByUser;
        private static readonly Action<ILogger, int, Exception> _deleteNotesBy;
        private static readonly Action<ILogger, string, Exception> _deleteNotesByUser;
        private static readonly Action<ILogger, int, Exception> _getNotesBy;
        private static readonly Action<ILogger, int, Exception> _couldNotFoundNoteBy;
        private static readonly Action<ILogger, int, Exception> _noteAdded;

        static Log()
        {
            _getNotesByUser = LoggerMessage.Define<string>(
                LogLevel.Information,
                EventIds.GetNotesByUserId,
                "Get back notes for userid ({userId}).");

            _deleteNotesByUser = LoggerMessage.Define<string>(
                LogLevel.Information,
                EventIds.DeleteNotesByUserId,
                "Delete all notes for userid ({userId}).");

            _getNotesBy = LoggerMessage.Define<int>(
                LogLevel.Information,
                EventIds.GetNotesBy,
                "Finding note by id({id}).");

            _deleteNotesBy = LoggerMessage.Define<int>(
                LogLevel.Information,
                EventIds.DeleteNotesBy,
                "Deleting note by id({id}).");

            _couldNotFoundNoteBy = LoggerMessage.Define<int>(
                LogLevel.Information,
                EventIds.CouldNotFoundNoteById,
                "Could not found note by id({id}).");

            _noteAdded = LoggerMessage.Define<int>(
                LogLevel.Information,
                EventIds.NoteAdded,
                "A new note with id({id}) was added.");
        }

        public static void GetNotesBy(this ILogger logger, int id)
        {
            _getNotesBy(logger, id, null);
        }

        public static void DeleteNotesBy(this ILogger logger, int id)
        {
            _deleteNotesBy(logger, id, null);
        }

        public static void CouldNotFoundNoteBy(this ILogger logger, int id)
        {
            _couldNotFoundNoteBy(logger, id, null);
        }

        public static void NoteAdded(this ILogger logger, int id)
        {
            _noteAdded(logger, id, null);
        }

        public static void GetNotesByUser(this ILogger logger, string userId)
        {
            _getNotesByUser(logger, userId, null);
        }

        public static void DeleteNotesByUser(this ILogger logger, string userId)
        {
            _deleteNotesByUser(logger, userId, null);
        }
    }
}
