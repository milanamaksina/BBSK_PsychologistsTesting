using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;

namespace BBSK_PsychologistsTesting.Steps
{
    public class PsychologistsSteps
    {
        private ClientsClient _psychologistsObjectClient = new ClientsClient();

        public ClientGetIdResponsModel GetClientObjectById (int id, string token, ClientGetIdResponsModel expected )
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpContent httpContent = _psychologistsObjectClient.GetClientById(id, token, expectedCode);

            string content = httpContent.ReadAsStringAsync().Result;
            ClientGetIdResponsModel actual = JsonSerializer.Deserialize<ClientGetIdResponsModel>(content);

            Assert.AreEqual(expected, actual);

            return actual;
        }

        public ClientGetIdResponsModel GetAllClientById(int id, string token, List<ClientGetIdResponsModel> expected)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpContent httpContent = _psychologistsObjectClient.//модель будет!!! (id, token, expectedCode);

            string content = httpContent.ReadAsStringAsync().Result;
            List <ClientGetIdResponsModel> actual = JsonSerializer.Deserialize< List<ClientGetIdResponsModel>>(content);

            CollectionAssert.AreEquivalent(expected, actual);

            return actual;
        }

        //public string UpdateClient(int id, ClientsUpdateRequestModel clientsupdatemodel, HttpStatusCode expectedCode)
        //{
        //    HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;


        //    HttpResponseMessage respons = _psychologistsobjectclient.UpdatingClient(id, clientsupdatemodel,expectedCode);


        //}
    }


}
