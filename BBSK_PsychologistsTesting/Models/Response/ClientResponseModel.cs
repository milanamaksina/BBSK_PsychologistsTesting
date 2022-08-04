using System;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class ClientResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("registrationDate")]
        public DateTime RegistrationDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ClientResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   BirthDate == model.BirthDate &&
                  RegistrationDate == model.RegistrationDate;
        }
    }
}
