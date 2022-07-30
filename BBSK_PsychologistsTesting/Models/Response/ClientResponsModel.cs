﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class ClientResponsModel
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
            return obj is ClientResponsModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   BirthDate == model.BirthDate &&
                  RegistrationDate == model.RegistrationDate;
        }
    }
}