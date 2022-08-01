using System;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class ClientGetCommentsIdcs
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
