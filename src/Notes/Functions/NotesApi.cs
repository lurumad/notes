using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Data;
using Notes.Model;
using System;
using System.Threading.Tasks;
using static Notes.Infrastructure.Validations.NotesApi;

namespace Notes
{
    public partial class NotesApi
    {
        private readonly NotesDbContext dbContext;
        private readonly IValidationScope<Note> validationScope;

        public NotesApi(NotesDbContext dbContext, IValidationScope<Note> validationScope)
        {
            this.dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
            this.validationScope = validationScope ?? throw new ArgumentNullException(nameof(validationScope));
        }

        [FunctionName("NotesApi_Get")]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "notes")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(await dbContext.Notes.ToListAsync());
        }

        [FunctionName("NotesApi_GetById")]
        public async Task<IActionResult> GetBy(
            int id,
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "notes/{id:int}")] HttpRequest req,
            ILogger log)
        {
            log.GetByFunctionRequested(id);

            var note = await dbContext.Notes.SingleOrDefaultAsync(note => note.Id == id);
            
            if (note is null) 
            {
                log.CouldNotFoundNoteBy(id);

                return new NotFoundResult();
            }

            return new OkObjectResult(note);
        }

        [FunctionName("NotesApi_Create")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Post), Route = "notes")] Note note,
            HttpRequest req,
            ILogger log)
        {
            return await validationScope.Validate(note, success: async () =>
            {
                dbContext.Notes.Add(note);

                await dbContext.SaveChangesAsync();

                log.NoteAdded(note.Id);

                return new CreatedResult($"{req.Scheme}://{req.Host}/api/notes/{note.Id}", note);
            });
        }

        [FunctionName("NotesApi_Update")]
        public async Task<IActionResult> Update(
            int id,
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Put), Route = "notes/{id:int}")] Note note,
            HttpRequest req,
            ILogger log)
        {
            return await validationScope.Validate(note, success: async () =>
            {
                var currentNote = await dbContext.Notes.SingleOrDefaultAsync(note => note.Id == id);

                if (currentNote is null)
                {
                    log.CouldNotFoundNoteBy(id);

                    return new NotFoundResult();
                }

                currentNote.Content = note.Content;
                currentNote.Important = note.Important;

                await dbContext.SaveChangesAsync();

                return new OkObjectResult(note);
            });
        }
    }
}
