using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api.Models.Request
{
    public class RegisterQuestionRequestModel
    {
        [JsonIgnore]
        public int? QuestionId { get; set; }
        [Required]
        [JsonPropertyName("question")]
        public string Description { get; set; }
        [Required]
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
        [Required]
        [JsonPropertyName("thumb_url")]
        public string ThumbUrl { get; set; }
        [Required]
        public ICollection<string> Choices { get; set; }

        public RegisterQuestionRequestModel()
        {
            this.Choices = new HashSet<string>();
        }
    }
}
