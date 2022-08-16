using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;

namespace BBSK_PsychologistsTesting.Clients
{
    public class AuthClient
    {
        public HttpContent AutorializeClient(AuthRequestModel model, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(model);

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Auth),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return response.Content;

        }

    }
}
