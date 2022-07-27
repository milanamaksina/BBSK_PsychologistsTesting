using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Psychologist;

namespace BBSK_PsychologistsTesting.Clients
{
    public class AuthClient
    {
        public HttpResponseMessage AutorializeClient(AuthRequestModel model)
        {
            string json = JsonSerializer.Serialize(model);

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Auth),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            return client.Send(message);

        }
    }
}
