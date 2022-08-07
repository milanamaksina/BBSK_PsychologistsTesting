using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class CommentAddingRequestModel
    {
        [JsonProperty("clientId")]
        int ClientId { get; set; }
        [JsonProperty("psychologistId")]
        int PsychologistId { get; set; }
        [JsonProperty("text")]
        string Text { get; set; }
        [JsonProperty("rating")]
        int Rating { get; set; }
        [JsonProperty("date")]
        DateTime Date { get; set; }
    }
}
