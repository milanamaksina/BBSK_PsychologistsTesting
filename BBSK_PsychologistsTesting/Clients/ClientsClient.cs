using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;

namespace BBSK_PsychologistsTesting.Clients
{
    public class ClientsClient
    {
        public HttpResponseMessage RegistrationClient(ClientRequestModel model)
        {
            string json = JsonSerializer.Serialize(model);

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Clients),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return client.Send(message);
        }

        public HttpContent GetClientById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{Urls.Clients}/{id}"),
            };

            HttpResponseMessage httpResponsec=client.Send(message);
            HttpStatusCode actualCode=httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);// статусная проверка тут

            return httpResponsec.Content;
        }

    }

}
    

