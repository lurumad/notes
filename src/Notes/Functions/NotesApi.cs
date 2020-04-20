using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Authentication;
using Notes.Infrastructure.Data;
using Notes.Infrastructure.Exceptions;
using Notes.Model;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Notes
{
    public partial class NotesApi
    {
        private readonly NotesDbContext dbContext;
        private readonly IValidator<Note> validator;
        private readonly IAccessTokenValidator accessTokenValidator;

        public NotesApi(
            NotesDbContext dbContext,
            IValidator<Note> validator,
            IAccessTokenValidator accessTokenValidator)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.accessTokenValidator = accessTokenValidator ?? throw new ArgumentNullException(nameof(accessTokenValidator));
        }

        [FunctionName("NotesApi_Get")]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "notes")] HttpRequest req,
            ILogger log)
        {
            var user = await accessTokenValidator.Validate(req);

            if (!user.Identity.IsAuthenticated)
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult(await dbContext.Notes.Where(note => note.UserId == user.GetSubjectId()).ToListAsync());
        }

        [FunctionName("NotesApi_GetById")]
        public async Task<IActionResult> GetBy(
            int id,
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "notes/{id:int}")] HttpRequest req,
            ILogger log)
        {
            var user = await accessTokenValidator.Validate(req);

            if (!user.Identity.IsAuthenticated)
            {
                return new UnauthorizedResult();
            }

            log.GetByFunctionRequested(id);

            var note = await dbContext.Notes.SingleOrDefaultAsync(note => note.Id == id && note.UserId == user.GetSubjectId());

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
            var user = await accessTokenValidator.Validate(req);

            if (!user.Identity.IsAuthenticated)
            {
                return new UnauthorizedResult();
            }

            var validation = validator.Validate(note);

            if (!validation.IsValid)
            {
                return new BadRequestObjectResult(
                    new FluentValidationProblemDetails(validation.Errors));
            }

            note.UserId = user.GetSubjectId();
            dbContext.Notes.Add(note);

            await dbContext.SaveChangesAsync();

            log.NoteAdded(note.Id);

            return new CreatedResult($"{req.Scheme}://{req.Host}/api/notes/{note.Id}", note);
        }

        [FunctionName("NotesApi_Update")]
        public async Task<IActionResult> Update(
            int id,
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Put), Route = "notes/{id:int}")] Note note,
            HttpRequest req,
            ILogger log)
        {
            var user = await accessTokenValidator.Validate(req);

            if (!user.Identity.IsAuthenticated)
            {
                return new UnauthorizedResult();
            }

            var validation = validator.Validate(note);

            if (!validation.IsValid)
            {
                return new BadRequestObjectResult(
                    new FluentValidationProblemDetails(validation.Errors));
            }

            var currentNote = await dbContext.Notes.SingleOrDefaultAsync(note => note.Id == id);

            if (currentNote is null)
            {
                log.CouldNotFoundNoteBy(id);

                return new NotFoundResult();
            }

            currentNote.Content = note.Content;
            currentNote.Important = note.Important;
            currentNote.UserId = user.GetSubjectId();

            await dbContext.SaveChangesAsync();

            return new OkObjectResult(note);
        }

        [FunctionName("NotesApi_Delete")]
        public async Task<IActionResult> Delete(
            int id,
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Delete), Route = "notes/{id:int}")] HttpRequest req,
            ILogger log)
        {
            var user = await accessTokenValidator.Validate(req);

            if (!user.Identity.IsAuthenticated)
            {
                return new UnauthorizedResult();
            }

            var note = await dbContext.Notes.SingleOrDefaultAsync(note => note.Id == id);

            if (note is null)
            {
                log.CouldNotFoundNoteBy(id);

                return new NotFoundResult();
            }

            dbContext.Remove(note);
            await dbContext.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
