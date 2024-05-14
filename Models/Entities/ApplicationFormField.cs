using Newtonsoft.Json;

namespace CapitalPlacement.Models.Entities
{
    public class ApplicationFormField
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public List<string> AnswerOptions { get; set; }
        public FieldType FieldType { get; set; }
        public bool IsInternal { get; set; }
        public bool IsVisible { get; set; }
        public bool IsRequired { get; set; }

    }

    public enum FieldType
    {
        Paragraph,
        YesNo,
        Dropdown,
        MultipleChoice,
        Date,
        Number
    }
}
