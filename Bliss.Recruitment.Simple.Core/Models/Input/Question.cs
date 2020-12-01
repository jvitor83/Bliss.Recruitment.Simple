using Bliss.Recruitment.Simple.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Bliss.Recruitment.Simple.Core.Models.Input
{
    public class Question
    {
        public int? QuestionId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public ICollection<string> Choices { get; set; }

        public Question()
        {
            this.Choices = new HashSet<string>();
        }
    }
}
