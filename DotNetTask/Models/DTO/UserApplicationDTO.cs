namespace DotNetTask.Models.DTO
{
    public class UserApplicationDTO:ClassCommonProperties
    {
        public string FormID { get; set; }
        public List<NumericResponseDTO> NumericResponses { get; set; }
        public List<ParagraphResponseDTO> ParagraphResponses { get; set; }
        public List<MultipleChoiceResponseDTO> MultipleChoiceResponses { get; set; }
        public List<YesOrNoResponseDTO> YesOrNoResponses { get; set; }
        public List<DateResponseDTO> DateResponses { get; set; }
    }

    public abstract class ResponseDTO
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
    }

    public class NumericResponseDTO : ResponseDTO
    {
        public int NumResponse { get; set; }
    }

    public class MultipleChoiceResponseDTO : ResponseDTO
    {
        public List<string> Choices { get; set; }
    }

    public class YesOrNoResponseDTO : ResponseDTO
    {
        public string Response { get; set; }
    }

    public class ParagraphResponseDTO : ResponseDTO
    {
        public string ParagraphResponse { get; set; }
    }

    public class DateResponseDTO : ResponseDTO
    {
        public DateTime DateResponse { get; set; }
    }

}
