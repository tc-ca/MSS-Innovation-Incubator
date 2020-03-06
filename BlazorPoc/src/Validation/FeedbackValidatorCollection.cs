using BlazorPOC.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPOC.Validation
{
    public class FeedbackValidatorCollection : AbstractValidator<FeedbackEntry>
    {
        public FeedbackValidatorCollection()
        {
            RuleFor(fb => fb.GivenName).NotEmpty().WithMessage("You must enter your Given Name");
            RuleFor(fb => fb.GivenName).MaximumLength(50).WithMessage("Your given name cannot be longer then 50 characters");
            RuleFor(fb => fb.Surname).NotEmpty().WithMessage("You must enter your Surname");
            RuleFor(fb => fb.Surname).MaximumLength(50).WithMessage("Your Surname cannot be longer then 50 characters");
            RuleFor(fb => fb.Text).NotEmpty().WithMessage("You must enter your Surname");
            RuleFor(fb => fb.Text).MaximumLength(200).WithMessage("Your Surname cannot be longer then 50 characters");
            RuleFor(fb => fb.EmailAddress).EmailAddress().WithMessage("You must provide a valid email address");
        }
    }
    
}
