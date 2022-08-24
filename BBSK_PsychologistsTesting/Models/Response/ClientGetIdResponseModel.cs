using System;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class ClientGetIdResponseModel
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
            return obj is ClientGetIdResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Email == model.Email &&
                   PhoneNumber == model.PhoneNumber &&
                   BirthDate.Date == model.BirthDate.Date &&
                   RegistrationDate.Date == model.RegistrationDate.Date;
        }
    }
}
