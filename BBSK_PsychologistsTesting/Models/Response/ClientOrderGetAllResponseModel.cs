using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class ClientOrderGetAllResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cost")]
        public double Cost { get; set; }

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

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ClientOrderGetAllResponseModel model &&
                   Id == model.Id &&
                   Cost == model.Cost &&
                   Duration == model.Duration &&
                   Message == model.Message &&
                   SessionDate.Date == model.SessionDate.Date &&
                   OrderDate.Date == model.OrderDate.Date &&
                   PayDate.Date  == model.PayDate.Date &&
                   OrderStatus == model.OrderStatus &&
                   OrderPaymentStatus == model.OrderPaymentStatus &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
