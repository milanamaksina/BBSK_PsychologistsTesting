using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Clients;
using System.Net.Http;
using System.Net;
using BBSK_PsychologistsTesting.Psychologist;
using System.Collections.Generic;
using System.Text.Json;


namespace BBSK_PsychologistsTesting.Steps
{
    public class ClientSteps

    {
        private ClientsClient _clientsClient = new ClientsClient(); 
        private AuthClient _authClient = new AuthClient(); 
        

        public int RegistrateClient (ClientRequestModel clientModel)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created; 

            HttpResponseMessage respons = _clientsClient.RegistrationClient(clientModel);

            HttpStatusCode actualRegistrationCode = respons.StatusCode; 
            string id = respons.Content.ReadAsStringAsync().Result;
            int? actualId = Convert.ToInt32(respons.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(expectedRegistrationCode, actualRegistrationCode);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public string AuthtorizeClientSystem(AuthRequestModel authModel)
        {
            HttpStatusCode expectedAuthCode = HttpStatusCode.OK; 

            HttpResponseMessage authrespons = _authClient.AutorializeClient(authModel);

            HttpStatusCode actualAuthCode = authrespons.StatusCode; 
            string actualToken = authrespons.Content.ReadAsStringAsync().Result;


            Assert.AreEqual(expectedAuthCode, actualAuthCode);
            Assert.NotNull(actualToken);

            return actualToken;
            
        }
        public List<ClientGetIdResponseModel> GetAllClientById(int id, string token, List<ClientGetIdResponseModel> expected)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpContent httpContent = _clientsClient.GetAllClientById(id, token, expectedCode);

            string content = httpContent.ReadAsStringAsync().Result;
            List<ClientGetIdResponseModel> actual = JsonSerializer.Deserialize<List<ClientGetIdResponseModel>>(content);

            CollectionAssert.AreEquivalent(expected, actual);

            return actual;
        }

        public ClientGetIdResponseModel GetClientById(int id, string token, ClientGetIdResponseModel expectedClient)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpContent httpContent = _clientsClient.GetClientById(id, token, expectedCode);

            string content = httpContent.ReadAsStringAsync().Result;
            ClientGetIdResponseModel actualClient = JsonSerializer.Deserialize<ClientGetIdResponseModel>(content);

            Assert.AreEqual(expectedClient, actualClient);

            return actualClient;
        }

        public void UpdateClient(int id, ClientUpdateRequestModel newClientUpdateModel, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;

            HttpContent httpContent = _clientsClient.GetClientById(id, token, expectedUpdateCode);
            HttpResponseMessage updateResponse = _clientsClient.UpdateClientById(id, newClientUpdateModel, token, expectedUpdateCode);
            HttpStatusCode actualUpdateCode = updateResponse.StatusCode;
            string actualUpdateToken = updateResponse.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(expectedUpdateCode, actualUpdateCode);
            Assert.NotNull(actualUpdateToken);
        }

        public void DeleteClientById (int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;

            _clientsClient.DeleteClientById(id,token, expectedDeleteCode);           
        }

        //public void GetClientCommentsById(int id, string token)
        //{
        //    HttpStatusCode expectedCommentsCode = HttpStatusCode.OK;

        //    _clientsClient.GetClientCommentsById(id, token, expectedCommentsCode);
        //}
    }
}
