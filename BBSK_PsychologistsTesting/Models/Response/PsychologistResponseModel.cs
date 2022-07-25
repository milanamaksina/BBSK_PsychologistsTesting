using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class PsychologistResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("gender")]
        public int Gender { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("workExperience")]
        public int WorkExperience { get; set; }

        [JsonPropertyName("pasportData")]
        public string PasportData { get; set; }

        [JsonPropertyName("education")]
        public List<string> Education { get; set; }

        [JsonPropertyName("checkStatus")]
        public int CheckStatus { get; set; }

        [JsonPropertyName("therapyMethods")]
        public List<string> TherapyMethods { get; set; }

        [JsonPropertyName("problems")]
        public List<string> Problems { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PsychologistResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Patronymic == model.Patronymic &&
                   Gender == model.Gender &&
                   BirthDate == model.BirthDate &&
                   Phone == model.Phone &&
                   Password == model.Password &&
                   Email == model.Email &&
                   WorkExperience == model.WorkExperience &&
                   PasportData == model.PasportData &&
                   IsDeleted == model.IsDeleted;


        }
    }
}
