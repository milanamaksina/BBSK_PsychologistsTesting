using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class PsychologistRequestModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("workExperience")]
        public int? WorkExperience { get; set; }

        [JsonProperty("pasportData")]
        public string PasportData { get; set; }

        [JsonProperty("education")]
        public List<string> Education { get; set; }

        [JsonProperty("checkStatus")]
        public int CheckStatus { get; set; }

        [JsonProperty("therapyMethods")]
        public List<string> TherapyMethods { get; set; }

        [JsonProperty("problems")]
        public List<string> Problems { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
