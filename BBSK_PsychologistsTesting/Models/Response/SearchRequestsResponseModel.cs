using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class SearchRequestsResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("psychologistGender")]
        public int PsychologistGender { get; set; }

        [JsonPropertyName("costMin")]
        public  double CostMin { get; set; }

        [JsonPropertyName("costMax")]
        public double CostMax { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SearchRequestsResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   PhoneNumber == model.PhoneNumber &&
                   Description == model.Description &&
                   PsychologistGender == model.PsychologistGender &&
                   CostMin == model.CostMin &&
                   CostMax == model.CostMax &&
                   Date == model.Date &&
                   Time == model.Time;
        }
    }
}
