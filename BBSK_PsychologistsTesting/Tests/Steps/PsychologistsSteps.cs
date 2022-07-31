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
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;

namespace BBSK_PsychologistsTesting.Steps
{
    public class PsychologistsSteps
    {
        private ClientsClient _psychologistsClient = new ClientsClient();
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
 
       
        public ClientGetIdResponsModel GetClientById (int id, string token, ClientGetIdResponsModel expectedClient)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpContent httpContent = _psychologistsClient.GetClientById(id, token, expectedCode);

            string content = httpContent.ReadAsStringAsync().Result;
            ClientGetIdResponsModel actualClient = JsonSerializer.Deserialize<ClientGetIdResponsModel>(content);

            Assert.AreEqual(expectedClient, actualClient);

            return actualClient;
        }

        public List<ClientGetIdResponsModel> GetAllClientById(int id, string token, List<ClientGetIdResponsModel> expected)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpContent httpContent = _psychologistsClient.GetAllClientById(id, token, expectedCode);

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

        public int RegisterPsychologist(PsychologistRequestModel psychologistModel)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;

            HttpResponseMessage response = _psychologistsPsychologist.RegisterPsychologist(psychologistModel);
            HttpStatusCode actualRegistrationCode = response.StatusCode;
            int? actualId = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(expectedRegistrationCode, actualRegistrationCode);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;

        }

        public PsychologistResponseModel GetPsychologistById(int id, string token, PsychologistResponseModel expectedPsychologist)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            HttpContent httpContent = _psychologistsPsychologist.GetPsychologistById(id, token, HttpStatusCode.OK);

            string content = httpContent.ReadAsStringAsync().Result;
            PsychologistResponseModel actualPsychologist = JsonSerializer.Deserialize<PsychologistResponseModel>(content);

            Assert.AreEqual(expectedPsychologist, actualPsychologist);

            return actualPsychologist;
        }

        public void UpdatePsychologistById(int id, PsychologistRequestModel newPsychologistData, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
           
            HttpResponseMessage updateResponse = _psychologistsPsychologist.UpdatePsychologistById(newPsychologistData, id, token, expectedUpdateCode);
            HttpStatusCode actualUpdateCode = updateResponse.StatusCode;
            string actualUpdateToken = updateResponse.Content.ReadAsStringAsync().Result;
           
            Assert.AreEqual(expectedUpdateCode, actualUpdateCode);
            Assert.NotNull(actualUpdateToken);
        }
    }
}



