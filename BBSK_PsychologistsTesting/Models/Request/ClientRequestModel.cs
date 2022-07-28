using System;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class ClientRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ClientRequestModel model &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Password == model.Password &&
                   Email == model.Email &&
                   PhoneNumber == model.PhoneNumber &&
                   BirthDate == model.BirthDate;
        }
    }
}
