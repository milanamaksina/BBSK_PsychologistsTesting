using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests
{
    public class CommentsTests
    {
        private ClientMapper _clientMapper = new ClientMapper();
        private DataCleaning _dataCleaning = new DataCleaning();
        private ClientSteps _clientSteps = new ClientSteps();

        int orderId;
        int actualId;
        int clientId;
        string token;

        [SetUp]
        public void SetUp()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Алексей",
                LastName = "Федорович",
                Password = "Fonbet123",
                Email = "Fonbet@gmail.com",
                PhoneNumber = "88121691833",
                BirthDate = new DateTime(1980, 01, 01)
            };
            actualId = _clientSteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "vanva@111",
                Password = "123456789",
            };

            token = _clientSteps.AuthtorizeClientSystem(authModel);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _dataCleaning.Clean();
        }

        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }

        public void AddCommentToPsychologist()
        {

        }
    }
}
