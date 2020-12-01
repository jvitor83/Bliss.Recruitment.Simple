using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bliss.Recruitment.Simple.Core.Models.Output
{
    public class Choice
    {
        public string Description { get; set; }
        public int Vote { get; set; }
    }
}
