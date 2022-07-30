using BBSK_PsychologistsTesting.Models.Request;
using System.Text.Json.Serialization;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class PsychologistPriceResponseModel
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PsychologistPriceRequestModel model &&
                   Price == model.Price;   
        }
    }
}
