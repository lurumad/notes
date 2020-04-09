using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Infrastructure.Validations
{
    public partial class NotesApi
    {
        public class FunctionValidationScope<TModel> : IValidationScope<TModel>
        {
            private readonly IEnumerable<IValidator<TModel>> validators;

            public FunctionValidationScope(IEnumerable<IValidator<TModel>> validators)
            {
                this.validators = validators;
            }

            public async Task<IActionResult> Validate(TModel model, Func<Task<IActionResult>> success)
            {
                var failures = validators
                    .Select(validator => validator.Validate(model))
                    .SelectMany(result => result.Errors)
                    .Where(error => error != null)
                    .ToList();

                if (failures.Any())
                {
                    return new BadRequestObjectResult(
                        new FluentValidationProblemDetails(failures)
                    );
                }

                return await success();
            }
        }
    }
}
