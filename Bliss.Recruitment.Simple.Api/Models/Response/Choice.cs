using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bliss.Recruitment.Simple.Api.Models.Response
{
    public class Choice
    {
        [JsonPropertyName("choice")]
        public string Description { get; set; }
        [JsonPropertyName("votes")]
        public int Vote { get; set; }
    }
}
