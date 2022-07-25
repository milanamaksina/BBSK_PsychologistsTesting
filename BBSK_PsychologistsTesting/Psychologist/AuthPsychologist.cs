using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Psychologist
{
    public class AuthPsychologist
    {
        public HttpResponseMessage Authorize(AuthRequestModel model)
        {
            string json = JsonSerializer.Serialize(model);

            HttpClient psychologist = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Auth),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return psychologist.Send(message);
        }
    }
}
