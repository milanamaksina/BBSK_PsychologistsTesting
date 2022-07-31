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
        
        public ClientSteps _authsteps = new ClientSteps();

        [Test]
         public void ClientCreation_WhenPasswordIsLessThan8Symbols_ShouldThrowCode422()
         {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Ляшка",
                LastName = "Какашка",
                Password= "12345678",
                Email= "жела@ooaaoks.ru",
                PhoneNumber = "8888044617",
                BirthDate= new DateTime(1991, 06, 01)
            };// я создал модельку

            int client=_authsteps.RegistrateClient(clientModel);
           
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "жела@ooaaoks.ru",
                Password = "12345678",
            };// я создал модельку 

            string avtorizeclient = _authsteps.AuthtorizeClientSystem(authModel);
          
            
         }
    }
}
