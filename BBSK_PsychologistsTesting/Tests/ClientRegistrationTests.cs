using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Steps;

namespace BBSK_PsychologistsTesting.Tests
{
    public class ClientRegistrationTests
    {
        private ClientsClient _clientsClient = new ClientsClient(); // я создал клиента
        private AuthClient _authClient = new AuthClient(); // я создал клиента
        public AuthSteps authsteps = new AuthSteps();

        [Test]
         public void ClientCreation_WhenPasswordIsLessThan8Symbols_ShouldThrowCode422()
         {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Кукумбер",
                LastName = "Покусанный",
                Password= "12345678",
                Email= "955555@ooaaoksdf.ru",
                PhoneNumber = "8988051617",
                BirthDate= new DateTime(1991, 05, 01)
            };// я создал модельку

            int aaa=authsteps.RegistrateClient(clientModel);
             

            //HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created; // говорю код такой



            //HttpResponseMessage respons = _clientsClient.RegistrationClient(clientModel);// какое действие я сделал

            //HttpStatusCode actualRegistrationCode = respons.StatusCode; // реальный вот такой
            //string id = respons.Content.ReadAsStringAsync().Result;
            //int? actualId = Convert.ToInt32(respons.Content.ReadAsStringAsync().Result);//я прочитал ответ и сконвертил его

            //Assert.AreEqual(expectedRegistrationCode, actualRegistrationCode);// проверОчка
            //Assert.NotNull(actualId);
            //Assert.IsTrue(actualId>0);


            //int clientID = (int)actualId;



            //AuthRequestModel authModel = new AuthRequestModel()
            //{
            //    Email = "QQQ@eeee.ru",
            //    Password = "123456789",               
            //};// я создал модельку 
            //HttpStatusCode expectedAuthCode = HttpStatusCode.Created; // говорю код такой

            //HttpResponseMessage authrespons = _authClient.AutorializeClient(authModel);// какое действие я сделал

            //HttpStatusCode actualAuthCode = authrespons.StatusCode; // реальный вот такой
            //string actualToken = authrespons.Content.ReadAsStringAsync().Result;//я прочитал ответ и сконвертил его
            

            //Assert.AreEqual(expectedAuthCode, actualAuthCode);// проверОчка
            //Assert.NotNull(actualToken);

            //string token=actualToken;

            //ClientResponsModel expectedClient = new ClientResponsModel()
            //{
            //    Id = clientID,
            //    Name = clientModel.Name,
            //    LastName = clientModel.LastName,
            //    Email = clientModel.Email,
            //    PhoneNumber = clientModel.PhoneNumber,
            //    BirthDate = new DateTime(1990, 05, 01)
            //};// я создал модельку

            //HttpContent content = _clientsClient.GetClientById(clientID,token,HttpStatusCode.OK);// какое действие я сделал
            //ClientResponsModel actualClient = JsonSerializer.Deserialize< ClientResponsModel>( content.ReadAsStringAsync().Result);
            //Assert.AreEqual(expectedClient, actualClient);
        }
    }
}
