using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using NUnit.Framework;

namespace BBSK_PsychologistsTesting.SearchRequests
{
    public class SearchRequestsSearchClient
    {
        public HttpContent CreateSearchRequests(int id,string token, SearchRequestsRequestsModel searchRequestsRequestsModel, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string json = JsonSerializer.Serialize(searchRequestsRequestsModel);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Urls.SearchRequests),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);

            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return response.Content;
        }

        public HttpContent GetAllSearchRequests(int id, string token,HttpStatusCode expectedCode)
        {    
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.SearchRequests}"),
            };

            HttpResponseMessage httpResponsec = client.Send(message);
            HttpStatusCode actualCode = httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return httpResponsec.Content;
        }

        public HttpContent GetSearchRequestsById(int id, string token, HttpStatusCode expectedCode)
        {          
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.SearchRequests}/{id}"),
            };

            HttpResponseMessage httpResponsec = client.Send(message);
            HttpStatusCode actualCode = httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return httpResponsec.Content;
        }

        public HttpContent DeleteSearchRequestsById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri($"{Urls.SearchRequests}/{id}"),
            };

            HttpResponseMessage httpResponsec = client.Send(message);
            HttpStatusCode actualCode = httpResponsec.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return httpResponsec.Content;
        }

        public HttpContent PutSearchRequestsById(int id, string token, SearchRequestsGetByIdRequestModel searchRequestsGetByIdRequestModel, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(searchRequestsGetByIdRequestModel);

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{Urls.SearchRequests}/{id}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return response.Content;
        }
    }


}
