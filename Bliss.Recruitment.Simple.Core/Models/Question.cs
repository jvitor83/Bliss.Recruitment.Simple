using Bliss.Recruitment.Simple.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Bliss.Recruitment.Simple.Core.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public DateTime PublishedAt { get; set; }
        [Required]
        public string ThumbUrl { get; set; }
        [Required]
        public ICollection<Choice> Choices { get; set; }

        public Question()
        {
            this.Choices = new HashSet<Choice>();
        }
    }
}
