using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotNetTask.Models
{
    public class ProgramInformation:ClassCommonProperties
    {
        [JsonInclude]
        public NumericQuestion[] NumericQuestions { get; set; }
        public ParagraghQuestion[] ParagraghQuestions { get; set; }
        public MultipleChoiceQuestion[] MChoiceQuestions { get; set; }
        public YesOrNoQuestion[] YesOrNoQuestion { get; set; }
        public DateQuestion[] DateQuestion { get; set; }
    }

    public abstract class Question
    {
        public Question() { }
        //public string id { get; set; }
        //public string QuestionTypeId { get; set; }
        public string QuestionText { get; set; }
    }

    public class NumericQuestion : Question
    {
        [JsonProperty("qid")]
        internal string qid { get; set; } = Guid.NewGuid().ToString();
        public int numericAnswer { get; set; }
    }

    public class ParagraghQuestion
    {
        [JsonProperty("qid")]
        internal string qid { get; set; } = Guid.NewGuid().ToString();
        [Length(0, 500)]
        public string paragraphText { get; set; }
    }

    public class MultipleChoiceQuestion:Question
    {
        [JsonProperty("qid")]
        internal string qid { get; set; } = Guid.NewGuid().ToString();
        public int maxChoiceAlllowed { get; set; }
        public bool otherOptions { get; set; }
        public string[] questionChoice { get; set; }
    }

    public class YesOrNoQuestion : Question
    {
        [JsonProperty("qid")]
        internal string qid { get; set; } = Guid.NewGuid().ToString();
        public string[] questionOptions { get; set; }
    }
    public class DateQuestion : Question
    {
        [JsonProperty("qid")]
        internal string qid { get; set; } = Guid.NewGuid().ToString();
    }



}
