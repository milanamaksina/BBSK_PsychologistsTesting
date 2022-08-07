﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class SearchRequestsRequestsModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("psychologistGender")]
        public int PsychologistGender { get; set; }

        [JsonPropertyName("costMin")]
        public int CostMin { get; set; }

        [JsonPropertyName("costMax")]
        public int CostMax { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}
