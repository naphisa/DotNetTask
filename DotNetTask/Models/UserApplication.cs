using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DotNetTask.Models
{

    public class UserApplication:ClassCommonProperties
    {
        public string formID { get; set; }
        [JsonInclude]
        public NumericResponse[] NumericResponse { get; set; }
        public ParagraphResponse[] ParagraghResponse{ get; set; }
        public MultipleChoiceResponse[] MultipleChoiceResponse { get; set; }
        public YesOrNoResponse[] YesOrNoResponse { get; set; }
        public DateResponse[] DateResponse { get; set; }
    }

    public abstract class Response
    {
        //static Guid myGuid = Guid.NewGuid();
        //[JsonProperty("responseId")]
        //public string responseId { get; set; } = myGuid.ToString();
        public string questionId { get; set; }
        public string questionText { get; set; }

    }

    public class NumericResponse:Response
    {
        public int numResponse { get; set; }
    }

    public class MultipleChoiceResponse:Response
    {
        public string[] choices { get; set; }
    }

    public class YesOrNoResponse:Response
    {
        public string response { get; set; }
    }

    public class ParagraphResponse:Response
    {
        public string paragraphResponse { get; set; }
    }
    public class DateResponse:Response
    {
        public DateTime dateResponse { get; set; }
    }

}
