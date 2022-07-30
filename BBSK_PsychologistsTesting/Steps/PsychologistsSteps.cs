using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Steps
{
    public class PsychologistsSteps
    {
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
        private AuthPsychologist _authPsychologist = new AuthPsychologist();

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

        public string AuthPsychologist(AuthRequestModel authModel)
        {
            HttpStatusCode expectedAuthCode = HttpStatusCode.OK;
            //When
            HttpResponseMessage authResponse = _authPsychologist.Authorize(authModel);
            HttpStatusCode actualAuthCode = authResponse.StatusCode;
            string actualToken = authResponse.Content.ReadAsStringAsync().Result;
            //Then
            Assert.AreEqual(expectedAuthCode, actualAuthCode);
            Assert.NotNull(actualToken);

            return actualToken;
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
            //When
            HttpResponseMessage updateResponse = _psychologistsPsychologist.UpdatePsychologistById(newPsychologistData, id, token, expectedUpdateCode);
            HttpStatusCode actualUpdateCode = updateResponse.StatusCode;
            string actualUpdateToken = updateResponse.Content.ReadAsStringAsync().Result;
            //Then
            Assert.AreEqual(expectedUpdateCode, actualUpdateCode);
            Assert.NotNull(actualUpdateToken);
        }
    }
}
