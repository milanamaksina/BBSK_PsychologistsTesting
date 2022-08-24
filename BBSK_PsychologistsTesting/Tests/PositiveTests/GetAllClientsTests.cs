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
using BBSK_PsychologistsTesting.Tests.Steps;
using static BBSK_PsychologistsTesting.Tests.TestSources.CreateClientSearchRequestsTestSources;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class GetAllClientsTests
    {
        private DataCleaning _dataCleaning;
        private ClientSteps _clientSteps;
        private SearchRequestsMapper _searchRequestsMapper;
        private SearchRequestsSteps _searchRequestsSteps;
        private ClientMapper _clientMapper;
        private string tokenClientOne;
        private string tokenClientTwo;
        private int actualIdOne;
        private int actualIdTwo;
        private string token;
        List<SearchRequestsRequestsModel> _search;
        List<int> _clientsId;
        private List<int> _searchId;
        private int searchId;
        ClientRequestModel clientModelOne;
        ClientRequestModel clientModelTwo;
        public GetAllClientsTests()
        {
            _dataCleaning = new DataCleaning();
            _clientSteps = new ClientSteps();
            _searchRequestsMapper = new SearchRequestsMapper();
            _searchRequestsSteps = new SearchRequestsSteps();
            _clientMapper = new ClientMapper();
        }
        [SetUp]
        public void SetUp()
        {
            _dataCleaning.Clean();
            List<ClientRequestModel> clientRequestModels = new List<ClientRequestModel>();
            clientModelOne = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "123456789",
                Email = "vaan@pщ",
                PhoneNumber = "88121691837",
                BirthDate = new DateTime(1970, 01, 01)
            };
            actualIdOne = _clientSteps.RegistrateClient(clientModelOne);
            clientModelTwo = new ClientRequestModel()
            {
                Name = "Колбаса",
                LastName = "Делавая",
                Password = "123456789",
                Email = "vaan@деловая",
                PhoneNumber = "88121691844",
                BirthDate = new DateTime(1970, 01, 01)
            };
            actualIdTwo = _clientSteps.RegistrateClient(clientModelTwo);
            _clientsId = new List<int> { actualIdOne, actualIdTwo };
            //_clients = new List<ClientRequestModel> { clientModelOne, clientModelTwo };
            AuthRequestModel authModelOne = new AuthRequestModel()
            {
                Email = "vaan@pщ",
                Password = "123456789",
            };
            tokenClientOne = _clientSteps.AuthtorizeClientSystem(authModelOne);
            AuthRequestModel authModelTwo = new AuthRequestModel()
            {
                Email = "vaan@деловая",
                Password = "123456789",
            };
            tokenClientTwo = _clientSteps.AuthtorizeClientSystem(authModelTwo);
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
        [TestCaseSource(typeof(SearchRequests_WhenSearchRequestsIsCorrect_TestSource))]
        public void GetAllClientHaveSeachRequetsOfManager_SearchRequestsIsCorrect_ShouldGetAllClients(List<SearchRequestsRequestsModel> searchRequestsRequestsModel)
        {

            foreach (var clientSearch in searchRequestsRequestsModel)
            {
                searchId = _searchRequestsSteps.CreateClientSearchRequests(tokenClientOne, clientSearch);
                _searchId.Add(searchId);
            }
            List<SearchRequestsResponseModel> searchRequestsResponseModel = new List<SearchRequestsResponseModel>();
            for (int i = 0; i < searchRequestsResponseModel.Count; i++)
            {
                searchRequestsResponseModel.Add(_searchRequestsMapper.MappSearchRequestsRequestsModelToSearchRequestsResponseModel(searchRequestsRequestsModel[i], _searchId[i]));
            }
           _searchRequestsSteps.GetAllSearchRequestModeration(token, searchRequestsResponseModel);
        }       
    }
}
