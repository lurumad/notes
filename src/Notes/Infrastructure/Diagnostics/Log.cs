using Notes.Infrastructure.Diagnostics;
using System;

namespace Microsoft.Extensions.Logging
{
    public static class Log
    {
        private static readonly Action<ILogger, int, Exception> _getFunctionByRequested;
        private static readonly Action<ILogger, int, Exception> _couldNotFoundNoteBy;
        private static readonly Action<ILogger, int, Exception> _noteAdded;

        static Log()
        {
            _getFunctionByRequested = LoggerMessage.Define<int>(
                LogLevel.Information,
                EventIds.GetByFunctionRequestedId,
                "Finding note by id({id}).");

            _couldNotFoundNoteBy = LoggerMessage.Define<int>(
                LogLevel.Information,
                EventIds.CouldNotFoundNoteById,
                "Could not found note by id({id}).");

            _noteAdded = LoggerMessage.Define<int>(
                LogLevel.Information,
                EventIds.NoteAdded,
                "A new note with id({id}) was added.");
        }

        public static void GetByFunctionRequested(this ILogger logger, int id)
        {
            _getFunctionByRequested(logger, id, null);
        }

        public static void CouldNotFoundNoteBy(this ILogger logger, int id)
        {
            _couldNotFoundNoteBy(logger, id, null);
        }

        public static void NoteAdded(this ILogger logger, int id)
        {
            _noteAdded(logger, id, null);
        }
    }
}
