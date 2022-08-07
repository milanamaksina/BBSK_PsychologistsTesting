using System;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class ClientOrdersRequestModel
    {
        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }

        [JsonPropertyName("psychologistId")]
        public int PsychologistId { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("sessionDate")]
        public DateTime SessionDate { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("payDate")]
        public DateTime PayDate { get; set; }

        [JsonPropertyName("orderStatus")]
        public int OrderStatus { get; set; }

        [JsonPropertyName("orderPaymentStatus")]
        public int OrderPaymentStatus { get; set; }
    }
}
