using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Clients
{
    public class PsychologistsObjectClient
    {
        public HttpResponseMessage UpdatingClient(int id,ClientsUpdateRequestModel clientsupdatemodel, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(clientsupdatemodel);

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{Urls.Clients }/{id}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            //HttpResponseMessage httpResponsec = client.Send(message);
            //HttpStatusCode actualCode = httpResponsec.StatusCode;

            //Assert.AreEqual(expectedCode, actualCode);// статусная проверка тут

            
        }
    }
}
