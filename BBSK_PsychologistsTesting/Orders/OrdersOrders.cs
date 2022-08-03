using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BBSK_PsychologistsTesting.Orders
{
    public class OrdersOrders
    {
        public HttpContent GetAllOrdersById(int id, string token,  HttpStatusCode expectedCode)
        {          

          HttpClient client = new HttpClient();

          client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpRequestMessage message = new HttpRequestMessage()
         {
            Method = HttpMethod.Get,
            RequestUri = new Uri(Urls.Orders),          
         };
          HttpResponseMessage response = client.Send(message);

          HttpStatusCode actualCode = response.StatusCode;

          Assert.AreEqual(expectedCode, actualCode);

            return response.Content;
        }

        public HttpContent AddOrder(string token, ClientOrdersRequestModel clientOrdersRequestModel, HttpStatusCode expectedCode)
        {

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string json = JsonSerializer.Serialize(clientOrdersRequestModel);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Orders),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return response.Content;
        }

        public HttpContent GetOrdersById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Orders}/{id}"),
            };

            HttpResponseMessage httpResponsec = client.Send(message);
            HttpStatusCode actualCode = httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return httpResponsec.Content;
        }

        public void DeleteOrdersById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri($"{Urls.Orders}/{id}"),
            };

            HttpResponseMessage httpResponsec = client.Send(message);
            HttpStatusCode actualCode = httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);
        }

        
    }
}
