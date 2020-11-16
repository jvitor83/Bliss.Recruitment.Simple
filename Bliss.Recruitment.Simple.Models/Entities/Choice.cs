using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Recruitment.Simple.Models.Entities
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string Description { get; set; }
        public int Vote { get; set; }
        public int QuestionId { get; set; }
    }
}
