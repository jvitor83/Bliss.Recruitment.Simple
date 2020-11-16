using Bliss.Recruitment.Simple.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Recruitment.Simple.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedAt { get; set; }
        public string ThumbUrl { get; set; }
        public ICollection<Choice> Choices { get; set; }

        public Question()
        {
            this.Choices = new HashSet<Choice>();
        }
    }
}
