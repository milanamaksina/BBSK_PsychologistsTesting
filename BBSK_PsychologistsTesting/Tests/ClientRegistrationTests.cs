using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Psychologist;
using System.Net;
using System.Net.Http;

namespace BBSK_PsychologistsTesting.Tests
{
    public class ClientRegistrationTests
    {       
        
        public AuthSteps authsteps = new AuthSteps();

        [Test]
         public void ClientCreation_WhenPasswordIsLessThan8Symbols_ShouldThrowCode422()
         {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Кукумбер",
                LastName = "Cанный",
                Password= "12345678",
                Email= "122555@ooaaoksdf.ru",
                PhoneNumber = "8788044617",
                BirthDate= new DateTime(1991, 06, 01)
            };// я создал модельку

            int client=authsteps.RegistrateClient(clientModel);
           
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "122555@ooaaoksdf.ru",
                Password = "12345678",
            };// я создал модельку 

            string avtorizeclient = authsteps.AuthtorizeClientSystem(authModel);
          
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
