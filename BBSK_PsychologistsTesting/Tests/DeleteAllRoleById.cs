using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using NUnit.Framework;
using System;

namespace BBSK_PsychologistsTesting.Tests
{
    public class DeleteAllRoleById
    {    
        private ClientSteps _clientSteps = new ClientSteps();

        [Test]
        public void DeleteClient_WhenClientRegistrateAthtorize_ShouldThrowCode204()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "0000000000",
                Email = "новая почта@oksf.ru",
                PhoneNumber = "812345678",
                BirthDate = new DateTime(1980, 01, 01)
            };

            int actualId = _clientSteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "рп@oksf.ru",
                Password = "111111111",
            }; 

            string token = _clientSteps.AuthtorizeClientSystem(authModel);

            _clientSteps.DeleteClientById(actualId, token);

        }
    }
}
