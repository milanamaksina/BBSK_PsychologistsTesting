using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Clients;
using System.Net.Http;
using System.Net;


namespace BBSK_PsychologistsTesting.Steps
{
    public class AuthSteps

    {
        private ClientsClient _clientsClient = new ClientsClient(); // я создал клиента

        public int RegistrateClient (ClientRequestModel clientModel)
        {

            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created; // говорю код такой


            HttpResponseMessage respons = _clientsClient.RegistrationClient(clientModel);// какое действие я сделал

            HttpStatusCode actualRegistrationCode = respons.StatusCode; // реальный вот такой
            string id = respons.Content.ReadAsStringAsync().Result;
            int? actualId = Convert.ToInt32(respons.Content.ReadAsStringAsync().Result);//я прочитал ответ и сконвертил его

            Assert.AreEqual(expectedRegistrationCode, actualRegistrationCode);// проверОчка
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }
    }
}
