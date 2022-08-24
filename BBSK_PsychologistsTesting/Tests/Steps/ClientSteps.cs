using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Clients;
using System.Net.Http;
using System.Net;
using BBSK_PsychologistsTesting.Psychologist;
using System.Collections.Generic;
using System.Text.Json;
using BBSK_PsychologistsTesting.Models.Response;

namespace BBSK_PsychologistsTesting.Steps
{
    public class ClientSteps

    {
        private ClientsClient _clientsClient = new ClientsClient(); 
        private AuthClient _authClient = new AuthClient(); 
        

        public int RegistrateClient (ClientRequestModel clientModel)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _clientsClient.RegistrationClient(clientModel, expectedRegistrationCode);    
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return (int)actualId;
        }

        public string AuthtorizeClientSystem(AuthRequestModel authModel)
        {
            HttpStatusCode expectedAuthCode = HttpStatusCode.OK;
            HttpContent content = _authClient.AutorializeClient(authModel, expectedAuthCode);
            string actualToken = content.ReadAsStringAsync().Result;
            Assert.NotNull(actualToken);
            return actualToken;           
        }

        public List<ClientResponseModel> GetAllClient(string token, List<ClientResponseModel> expected)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            HttpContent httpContent = _clientsClient.GetAllClient( token, expectedCode);
            string content = httpContent.ReadAsStringAsync().Result;
            List<ClientResponseModel> actual = JsonSerializer.Deserialize<List<ClientResponseModel>>(content);
            CollectionAssert.AreEqual(expected, actual);
            return actual;
        }

        public ClientResponseModel GetClientById(int id, string token, ClientResponseModel expectedClient)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            HttpContent httpContent = _clientsClient.GetClientById(id, token, expectedCode);
            string content = httpContent.ReadAsStringAsync().Result;
            ClientResponseModel actualClient = JsonSerializer.Deserialize<ClientResponseModel>(content);
            Assert.AreEqual(expectedClient, actualClient);
            return actualClient;
        }

        public void UpdateClient(int id, ClientRequestModel newClientUpdateModel, string token)
        {            
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _clientsClient.UpdateClientById(id, newClientUpdateModel, token, expectedUpdateCode);
        }

        public void DeleteClientById (int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _clientsClient.DeleteClientById(id,token, expectedDeleteCode);           
        }

    }
}
