using Bliss.Recruitment.Simple.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Bliss.Recruitment.Simple.Api.Models.Response
{
    public class Question
    {
        [JsonPropertyName("id")]
        public int QuestionId { get; set; }
        [Required]
        [JsonPropertyName("question")]
        public string Description { get; set; }
        [Required]
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }
        [Required]
        [JsonPropertyName("thumb_url")]
        public string ThumbUrl { get; set; }
        [Required]
        public ICollection<Choice> Choices { get; set; }

        public Question()
        {
            this.Choices = new HashSet<Choice>();
        }
    }
}
