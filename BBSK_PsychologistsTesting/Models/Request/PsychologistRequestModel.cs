﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class PsychologistRequestModel
    {
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
        public int? WorkExperience { get; set; }

        [JsonPropertyName("pasportData")]
        public string PasportData { get; set; }

        [JsonPropertyName("educations")]
        public List<string> Education { get; set; }

        [JsonPropertyName("checkStatus")]
        public int CheckStatus { get; set; }

        [JsonPropertyName("therapyMethods")]
        public List<string> TherapyMethods { get; set; }

        [JsonPropertyName("problems")]
        public List<string> Problems { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

    //    [JsonProperty("isDeleted")]
    //    public bool IsDeleted { get; set; }
    }
}
