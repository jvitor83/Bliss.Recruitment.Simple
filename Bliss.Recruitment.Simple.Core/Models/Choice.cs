using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bliss.Recruitment.Simple.Core.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string Description { get; set; }
        public int Vote { get; set; }
        public int QuestionId { get; set; }
    }
}
