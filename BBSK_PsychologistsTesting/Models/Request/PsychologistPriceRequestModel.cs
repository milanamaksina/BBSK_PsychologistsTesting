using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class PsychologistPriceRequestModel
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
