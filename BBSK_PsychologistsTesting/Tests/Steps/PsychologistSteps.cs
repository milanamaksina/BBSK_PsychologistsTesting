using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;

namespace BBSK_PsychologistsTesting.Steps
{
    public class PsychologistSteps
    {

        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
     

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

        public List<PsychologistResponseModel> GetAllPsychologists(string token, List<PsychologistResponseModel> expected)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            HttpContent httpContent = _psychologistsPsychologist.GetAllPsychologists(token, expectedCode);

            string content = httpContent.ReadAsStringAsync().Result;
            List<PsychologistResponseModel> actual = JsonSerializer.Deserialize<List<PsychologistResponseModel>>(content);

            CollectionAssert.AreEquivalent(expected, actual);

            return actual;
        }

        public void DeletePsychologistById(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;

            _psychologistsPsychologist.DeletePsychologistById(id, token, expectedDeleteCode);
        }
    }
}



