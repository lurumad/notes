using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Infrastructure.Exceptions
{
    public class FluentValidationProblemDetails : ProblemDetails
    {
        public FluentValidationProblemDetails(IList<ValidationFailure> validationFailures)
        {
            Errors = validationFailures
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(failure => GetErrorMessage(failure)).ToArray());
        }

        private string GetErrorMessage(ValidationFailure error)
        {
            return String.IsNullOrWhiteSpace(error.ErrorMessage) ?
                "The input was not valid." :
                error.ErrorMessage;
        }

        [JsonProperty(PropertyName = "errors")]
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>(StringComparer.Ordinal);
    }
}
