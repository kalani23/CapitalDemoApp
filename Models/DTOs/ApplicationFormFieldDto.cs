using CapitalPlacement.Models.Entities;

namespace CapitalPlacement.Models.DTOs
{
    public class ApplicationFormFieldDto
    {
        public string QuestionText { get; set; }
        public List<string> AnswerOptions { get; set; }
        public FieldType FieldType { get; set; }
        public bool IsRequired { get; set; }

    }
}
