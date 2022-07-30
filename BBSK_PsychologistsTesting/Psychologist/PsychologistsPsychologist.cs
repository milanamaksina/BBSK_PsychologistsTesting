using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Psychologist
{
    public class PsychologistsPsychologist
    {
        public HttpResponseMessage RegisterPsychologist(PsychologistRequestModel model)
        {
            string json = JsonSerializer.Serialize(model);

            HttpClient psychologist = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Psychologists),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return psychologist.Send(message);
        }

        public HttpContent GetPsychologistById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Psychologists}/{id}")
            };
            HttpResponseMessage httpResponse = client.Send(message);
            HttpStatusCode actualCode = httpResponse.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return httpResponse.Content;
        }

        public HttpResponseMessage UpdatePsychologistById(PsychologistRequestModel model, int id, string token, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(model);

            HttpClient psychologist = new HttpClient();
            psychologist.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{Urls.PsychologistsId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = psychologist.Send(message);
            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return psychologist.Send(message);
        }
    }
}
