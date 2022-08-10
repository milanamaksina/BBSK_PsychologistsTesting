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

namespace BBSK_PsychologistsTesting.Tests
{
    public class SearchRequestsCreaterClientTest
    {
        private DataCleaning _dataCleaning = new DataCleaning();
        private ClientSteps _clientSteps = new ClientSteps();
        private SearchRequestsSteps _searchRequestsSteps = new SearchRequestsSteps();
        private SearchRequestsMapper _searchRequestsMapper = new SearchRequestsMapper();

        int id;
        int orderId;
        int actualId;
        int clientId;
        string token;
        int searchRequestsId;


       

        [SetUp]
        public void SetUp()

        {            
                _dataCleaning.Clean();           

            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "123456789",
                Email = "vaan@p",
                PhoneNumber = "88121691833",
                BirthDate = new DateTime(1980, 01, 01)
            };

            actualId = _clientSteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "vaan@p",
                Password = "123456789",
            };

            token = _clientSteps.AuthtorizeClientSystem(authModel);

        }

        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }


        [TestCaseSource(typeof(SearchRequests_WhenSearchRequestsIsCorrect_TestSource))]
        public void CreateSearchRequestsPhyhoforClient_WhenSearchRequestsIsCorrect_ShouldSearchRequests(SearchRequestsRequestsModel searchRequestsRequestsModel)
        {
            searchRequestsId=_searchRequestsSteps.CreateClientSearchRequests(token, searchRequestsRequestsModel);

            SearchRequestsResponseModel expectedSearchRequests = _searchRequestsMapper.MappSearchRequestsRequestsModelToSearchRequestsResponseModel(searchRequestsRequestsModel, searchRequestsId);
            
            _searchRequestsSteps.GetSearchRequestsById(searchRequestsId, token, expectedSearchRequests);
           
            _searchRequestsSteps.DeleteClientSearchRequests(searchRequestsId, token);

        }

        [TestCaseSource(typeof(SearchRequests_WhenSearchRequestsIsCorrect_TestSource))]
        public void UpdateSearchRequestsPhyhoforClient_WhenSearchRequestsIsCorrect_ShouldSearchRequests(SearchRequestsRequestsModel searchRegistrationModel, SearchRequestsRequestsModel searchUpdateModel)
        {
            searchRequestsId = _searchRequestsSteps.CreateClientSearchRequests(token, searchRegistrationModel);


            _searchRequestsSteps.UpdateClientSearchRequests(searchRequestsId, token, searchUpdateModel);
            SearchRequestsResponseModel expectedSearchRequests = _searchRequestsMapper.MappSearchRequestsRequestsModelToSearchRequestsResponseModel(searchUpdateModel, searchRequestsId);

            _searchRequestsSteps.GetSearchRequestsById(searchRequestsId, token, expectedSearchRequests);

        }


    }
}
