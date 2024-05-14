using Newtonsoft.Json;

namespace CapitalPlacement.Models.DTOs
{
    public class FormSubmissionDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string NIC { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
