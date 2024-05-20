using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DotNetTask.Models
{
    public class ClassCommonProperties
    {
        static Guid myGuid = Guid.NewGuid();
        [JsonProperty("id")]
        public string id { get; set; } = myGuid.ToString();
        [JsonProperty("ProgramTitle")]
        public string ProgramTitle { get; set; }
        [JsonProperty("ProgramDescription")]
        public string ProgramDescription { get; set; }
        [Required]
        [JsonProperty("FirstName")]
        public string firstName { get; set; }
        [Required]
        [JsonProperty("LastName")]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        [JsonProperty("Email")]
        internal string email { get; set; }
        [RegularExpression(@"^(?!\+)\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Invalid phone number format, do not include dial code")]
        internal string phone { get; set; }
        internal string nationality { get; set; }
        internal string currentResidence { get; set; }
        internal string IDNumber { get; set; }
        internal DateTime DateOfBirth { get; set; }
        internal string gender { get; set; } = string.Empty;
    }
}
