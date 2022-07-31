using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Psychologist;

namespace BBSK_PsychologistsTesting.Tests
{
    public class UpdateClientTests
    {
        private ClientSteps _clientSteps = new ClientSteps();
        public ClientSteps _authsteps = new ClientSteps();

        [Test]
        public void DataСhanged_WhenClientLogged_ShouldThrowCode422()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "0000000000",
                Email = "новая почта@oksf.ru",
                PhoneNumber = "812345678",
                BirthDate = new DateTime(1980, 01, 01)
            };// я создал модельку

            int client = _authsteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "рп@oksf.ru",
                Password = "111111111",
            };// я создал модельку 

            string avtorizeСlient = _authsteps.AuthtorizeClientSystem(authModel);

            ClientUpdateRequestModel clientUpdateModel = new ClientUpdateRequestModel()
            {
                Name = "Чудо",
                LastName = "БольшоеЮдооо",
                BirthDate = new DateTime(1991, 06, 01)
            };

            _clientSteps.UpdateClient(client, clientUpdateModel, avtorizeСlient);

            ClientGetIdResponsModel expectedClient = new ClientGetIdResponsModel()
            {
                Id = client,
                Name = clientUpdateModel.Name,
                LastName = clientUpdateModel.LastName,
                PhoneNumber = clientModel.PhoneNumber,              
                Email = clientModel.Email,
                BirthDate= clientUpdateModel.BirthDate,
                //RegistrationDate= ,


            };
            _clientSteps.GetClientById(client, avtorizeСlient, expectedClient);
        }
    }
}
