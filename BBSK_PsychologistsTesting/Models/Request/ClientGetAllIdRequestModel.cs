using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Request
{
    public class ClientGetAllIdRequestModel
    {             
            [JsonPropertyName("id")]
            public int Id { get; set; }

            public override bool Equals(object? obj)
            {
                return obj is ClientGetAllIdRequestModel model &&
                       Id == model.Id;
            }
        
    }
}
