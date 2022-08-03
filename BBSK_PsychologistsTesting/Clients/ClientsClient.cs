using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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
        
        public HttpContent GetAllClientById(int id, string token, HttpStatusCode expectedCode)
        {
             ClientGetAllIdRequestModel model = new ClientGetAllIdRequestModel()
            {
                Id = id
            };
            string json = JsonSerializer.Serialize(model);

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Urls.Clients),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            return response.Content;
        }

        public HttpContent GetClientById(int id, string token, HttpStatusCode expectedCode)
        {
            ClientRequestModel model = new ClientRequestModel();
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Clients}/{id}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage httpResponsec=client.Send(message);
            HttpStatusCode actualCode=httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return httpResponsec.Content;
        }

        public HttpResponseMessage UpdateClientById(int id, ClientUpdateRequestModel clientsUpdateModel, string token, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(clientsUpdateModel);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{Urls.Clients}/{id}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return client.Send(message);

        }
        
        public void DeleteClientById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri($"{Urls.Clients}/{id}"),
            };

            HttpResponseMessage httpResponsec = client.Send(message);
            HttpStatusCode actualCode = httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);           
        }

        public HttpContent GetClientCommentsById(int id, string token, HttpStatusCode expectedCode)
        {          

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Clients}/{id}/comments"),              
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return response.Content;
        }
    }

}
    

