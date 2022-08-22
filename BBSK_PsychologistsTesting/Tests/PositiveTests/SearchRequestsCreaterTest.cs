using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Support.Mappers;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Psychologist;
using static BBSK_PsychologistsTesting.Tests.TestSources.CreateClientSearchRequestsTestSources;
using BBSK_PsychologistsTesting.Tests.Steps;
using BBSK_PsychologistsTesting.Models.Response;
using static BBSK_PsychologistsTesting.Tests.TestSources.UpdateClientSearchRequestsTestSources;

namespace BBSK_PsychologistsTesting.Tests
{
    public class SearchRequestsCreaterTest
    {
        private string token;
        private int searchRequestsId;
        private DataCleaning _dataCleaning;
        private ClientSteps _clientSteps; 
        private SearchRequestsSteps _searchRequestsSteps; 
        private SearchRequestsMapper _searchRequestsMapper; 

        public SearchRequestsCreaterTest()
        {
            _dataCleaning = new DataCleaning();
            _clientSteps = new ClientSteps();
            _searchRequestsSteps = new SearchRequestsSteps();
            _searchRequestsMapper = new SearchRequestsMapper();
        }
        
        [SetUp]
        public void SetUp()
        {            
                _dataCleaning.Clean();           
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "123456789",
                Email = "vaan@pщ",
                PhoneNumber = "88121691837",
                BirthDate = new DateTime(1970, 01, 01)
            };
            int actualId = _clientSteps.RegistrateClient(clientModel);
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "vaan@pщ",
                Password = "123456789",
            };
            token = _clientSteps.AuthtorizeClientSystem(authModel);         
        }
        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }
        [TestCaseSource(typeof(SearchRequestsUpdateClients_WhenSearchRequestsIsCorrect_TestSource))]
        public void UpdateSearchRequestsPsychoforClient_WhenSearchRequestsIsCorrect_ShouldSearchRequests(SearchRequestsRequestsModel searchRegistrationModel, SearchRequestsRequestsModel searchUpdateModel)
        {
            searchRequestsId = _searchRequestsSteps.CreateClientSearchRequests(token, searchRegistrationModel);
            _searchRequestsSteps.UpdateClientSearchRequests(searchRequestsId, token, searchUpdateModel);
            SearchRequestsResponseModel expectedSearchRequests = _searchRequestsMapper.MappSearchRequestsRequestsModelToSearchRequestsResponseModel(searchUpdateModel, searchRequestsId);
            _searchRequestsSteps.GetSearchRequestsById(searchRequestsId, token, expectedSearchRequests);
        }
        [TestCaseSource(typeof(SearchRequests_WhenSearchRequestsIsCorrect_TestSource))]
        public void CreateSearchRequestsPsychoforClient_WhenSearchRequestsIsCorrect_ShouldSearchRequests(SearchRequestsRequestsModel searchRequestsRequestsModel)
        {
            searchRequestsId=_searchRequestsSteps.CreateClientSearchRequests(token, searchRequestsRequestsModel);
            SearchRequestsResponseModel expectedSearchRequests = _searchRequestsMapper.MappSearchRequestsRequestsModelToSearchRequestsResponseModel(searchRequestsRequestsModel, searchRequestsId);
            _searchRequestsSteps.GetSearchRequestsById(searchRequestsId, token, expectedSearchRequests);
            _searchRequestsSteps.DeleteClientSearchRequests(searchRequestsId, token);                   
        }
        
    }
}
