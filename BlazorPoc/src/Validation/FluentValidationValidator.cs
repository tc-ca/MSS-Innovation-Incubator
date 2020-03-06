using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPOC.Validation
{
    public class FluentValidationValidator : ComponentBase
    {
        [CascadingParameter] EditContext CurrentEditContext { get; set; }
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new InvalidOperationException($"{nameof(FluentValidationValidator)} requires a cascading parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(FluentValidationValidator)} inside an {nameof(EditForm)}.");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            CurrentEditContext.AddFluentValidation();
        }
    }
}
