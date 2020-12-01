using Bliss.Recruitment.Simple.Core.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bliss.Recruitment.Simple.Core.BussinessRules
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(question => question.Choices)
                .NotNull()
                .Must(r => r.Count > 1)
                .WithMessage("Question should have more than 1 choice");
        }
    }
}