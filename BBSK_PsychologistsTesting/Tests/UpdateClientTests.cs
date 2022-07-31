using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Psychologist;

namespace BBSK_PsychologistsTesting.Tests
{
    public class UpdateClientTests
    {
        private PsychologistsSteps _psychoSteps = new PsychologistsSteps();
        public AuthSteps authsteps = new AuthSteps();

        [Test]
        public void DataСhanged_WhenClientLogged_ShouldThrowCode422()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "111111111",
                Email = "рпно@oksdf.ru",
                PhoneNumber = "8917051116",
                BirthDate = new DateTime(1991, 01, 01)
            };// я создал модельку

            int client = authsteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "рпно@oksdf.ru",
                Password = "111111111",
            };// я создал модельку 

            string avtorizeclient = authsteps.AuthtorizeClientSystem(authModel);

            ClientUpdateRequestModel clientUpdateModel = new ClientUpdateRequestModel()
            {
                Name = "Чудо",
                LastName = "БольшоеЮдооо",
                BirthDate = new DateTime(1991, 06, 01)
            };

            _psychoSteps.UpdateClient(client, clientUpdateModel, avtorizeclient);
        }
    }
}
