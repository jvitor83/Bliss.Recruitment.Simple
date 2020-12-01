using AutoFixture;
using Bliss.Recruitment.Simple.Core.BussinessRules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Core.UnitTests.Steps
{
    public class QuestionFixtureCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<IValidator<Core.Models.Input.Question>>(() =>
            {
                var validator = new QuestionValidator();
                return validator as IValidator<Core.Models.Input.Question>;
            });

            fixture.Register<Core.Models.Input.Question>(() =>
            {
                var question = new Core.Models.Input.Question();
                question.Choices = new List<string>() { string.Empty };
                return question;
            });
        }
    }

}
