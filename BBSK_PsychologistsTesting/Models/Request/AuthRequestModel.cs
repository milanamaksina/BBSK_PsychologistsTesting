using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Psychologist
{
    public class AuthRequestModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}