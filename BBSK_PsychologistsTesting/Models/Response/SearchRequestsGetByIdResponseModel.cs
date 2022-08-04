using System;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class SearchRequestsGetByIdResponseModel
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
        public int CostMin { get; set; }

        [JsonPropertyName("costMax")]
        public int CostMax { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SearchRequestsGetByIdResponseModel model &&
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
