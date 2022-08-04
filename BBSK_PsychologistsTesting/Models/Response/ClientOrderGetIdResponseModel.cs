using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class ClientOrderGetIdResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
