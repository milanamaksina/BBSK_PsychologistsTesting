using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Orders;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using BBSK_PsychologistsTesting.Tests.Steps;
using NUnit.Framework;
using System;
using static BBSK_PsychologistsTesting.Tests.TestSources.CreateClientOrderTestSources;

namespace BBSK_PsychologistsTesting.Tests
{
    public class OrderingServicesTests
    {
        private OrderSteps _orderSteps;
        private ClientMapper _clientMapper;
        private DataCleaning _dataCleaning; 
        private ClientSteps _clientSteps; 
        public OrderingServicesTests()
        {
            _orderSteps = new OrderSteps();
            _clientMapper = new ClientMapper();
            _dataCleaning = new DataCleaning();
            _clientSteps = new ClientSteps();
        }
        int orderId;
        string token;
        int actualId;
        string tokenManager;
        [SetUp]
        public void SetUp()
        {
            _dataCleaning.Clean();

            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "123456789",
                Email = "van@vyanya",
                PhoneNumber = "88121691833",
                BirthDate = new DateTime(1980, 01, 01)
            };
            actualId = _clientSteps.RegistrateClient(clientModel);
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "van@vyanya",
                Password = "123456789",
            };
            token = _clientSteps.AuthtorizeClientSystem(authModel);

            AuthRequestModel authModelbyManager = new AuthRequestModel()
            {
                Email = "manager@p.ru",
                Password = "Manager777",
            };
            tokenManager = _clientSteps.AuthtorizeClientSystem(authModel);
        }
        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }
        [TestCaseSource(typeof(OrderAdd_WhenOrderModelIsCorrect_TestSource))]
        public void OrderClientCreate_WhenOrderModelIsCorrect_ShouldCreateOrder(ClientOrdersRequestModel clientOrdersRequestModel)
        {
            _orderSteps.CreateClientOrder(token, clientOrdersRequestModel);
            ClientOrderResponseModel expectedOrderClient = _clientMapper.MappClientOrdersRequestModelToClientOrderResponsModel(clientOrdersRequestModel, orderId);
            _orderSteps.GetClientClientById(orderId, token, expectedOrderClient);
        }

        [TestCaseSource(typeof(OrderAdd_WhenOrderModelIsCorrect_TestSource))]
        public void DeleteOrder_WhenClientAthtorize_ShouldThrowCode204(ClientOrdersRequestModel clientOrdersRequestModel)
        {
            _orderSteps.CreateClientOrder(token, clientOrdersRequestModel);
            ClientOrderResponseModel expectedOrderClient = _clientMapper.MappClientOrdersRequestModelToClientOrderResponsModel(clientOrdersRequestModel, orderId);
            _orderSteps.DeleteOrderById(orderId, token);
        }

        [Test]
        public void DeleteOrder_WhenManagerAthtorize_ShouldThrowCode204()
        {
            _orderSteps.DeleteOrderById(orderId, tokenManager);
        }
    }
}
