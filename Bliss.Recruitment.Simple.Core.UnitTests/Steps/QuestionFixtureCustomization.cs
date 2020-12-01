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
            fixture.Register<IValidator<Core.Models.Question>>(() =>
            {
                var validator = new QuestionValidator();
                return validator as IValidator<Core.Models.Question>;
            });
        }
    }

}
