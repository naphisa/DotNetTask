using System.ComponentModel.DataAnnotations;

namespace DotNetTask.Models.DTO
{
    public class ProgramInformationDTO
    {

        public string Id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //[RegularExpression(@"^(?!\+)\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Invalid phone number format, do not include dial code")]
        //public string Phone { get; set; }
        //public string Nationality { get; set; }
        //public string CurrentResidence { get; set; }
        //public string IDNumber { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string Gender { get; set; } = string.Empty;
        public NumericQuestionDTO[] NumericQuestions { get; set; }
        public ParagraghQuestionDTO[] ParagraghQuestions { get; set; }
        public MultipleChoiceQuestionDTO[] MChoiceQuestions { get; set; }
        public YesOrNoQuestionDTO[] YesOrNoQuestion { get; set; }
        public DateQuestionDTO[] DateQuestion { get; set; }
    }

    public abstract class QuestionDTO
    {
        public string Id { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
    }

    public class NumericQuestionDTO : QuestionDTO
    {
        public int NumericAnswer { get; set; }
    }

    public class ParagraghQuestionDTO
    {
        [StringLength(500)]
        public string ParagraphText { get; set; }
    }

    public class MultipleChoiceQuestionDTO
    {
        public int MaxChoiceAlllowed { get; set; }
        public bool OtherOptions { get; set; }
        public string[] QuestionChoice { get; set; }
    }

    public class YesOrNoQuestionDTO : QuestionDTO
    {
        public bool YesOrNoAnswer { get; set; }
    }

    public class DateQuestionDTO : QuestionDTO
    {
        public DateTime DateAnswer { get; set; }
    }

}
