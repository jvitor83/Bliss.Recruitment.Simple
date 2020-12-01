using Bliss.Recruitment.Simple.Core.Models;
using Bliss.Recruitment.Simple.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<Core.Models.Output.Question> RegisterQuestion(Core.Models.Input.Question questionToRegister);
        Task<Core.Models.Output.Question> GetQuestion(int id);
        Task<IEnumerable<Core.Models.Output.Question>> GetQuestions(int offset, int limit, string filter = null);
        Task<Core.Models.Output.Question> ChangeQuestion(Core.Models.Input.Question questionToChange);
    }
}
