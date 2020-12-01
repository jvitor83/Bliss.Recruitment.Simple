using System.ComponentModel.DataAnnotations;

namespace Bliss.Recruitment.Simple.Api
{
    public class GetQuestionsWithParamsRequestModel
    {
        [Required]
        public int Limit { get; set; }

        [Required]
        public int Offset { get; set; }

        public string Filter { get; set; }

    }
}