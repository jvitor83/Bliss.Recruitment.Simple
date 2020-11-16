namespace Bliss.Recruitment.Simple.Api
{
    public class GetQuestionsWithParamsRequestModel
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public string Filter { get; set; }

    }
}