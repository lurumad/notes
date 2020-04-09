using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Notes.Infrastructure.Validations
{
    public partial class NotesApi
    {
        public interface IValidationScope<TModel>
        {
            Task<IActionResult> Validate(TModel model, Func<Task<IActionResult>> success);
        }
    }
}
