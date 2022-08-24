using NUnit.Framework;
using BBSK_PsychologistsTesting.Support.Mappers;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Models.Response;
using System.Collections.Generic;
using static BBSK_PsychologistsTesting.Tests.TestSources.GetAllInfoClientTestSources;
using System;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class GetAllClientsOfManagerTests
    {
        private DataCleaning _dataCleaning;
        private ClientSteps _clientSteps;
        private ClientMapper _clientMapper;
        private string token;
        private GetAllClientsOfManagerTests()
        {
            _dataCleaning = new DataCleaning();
            _clientSteps = new ClientSteps();
            _clientMapper = new ClientMapper();
        }
        [SetUp]
        public void SetUp()
        {
            _dataCleaning.Clean();

            AuthRequestModel authManager = new AuthRequestModel()
            {
                Email = "manager@p.ru",
                Password = "Manager777",
            };
            token = _clientSteps.AuthtorizeClientSystem(authManager);
        }
        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }
        [TestCaseSource(typeof(GetAllClientsofManager_WhenAuthManagerIsCorrect_TestSource))]
        public void GetAllClientsofManager_WhenAuthManagerIsCorrect_ShouldGetAllClients(List<ClientRequestModel> clientRequestModel)
        {
            List<ClientResponseModel> clientResponseModel = new List<ClientResponseModel>();
            foreach (var client in clientRequestModel)
            {
                var clientId = _clientSteps.RegistrateClient(client);
                var data = DateTime.Now.Date;
                clientResponseModel.Add(_clientMapper.MappClientRequestModelToClientResponsModel(data, client, clientId));
            }
            _clientSteps.GetAllClient(token, clientResponseModel);
        }
    }
}
