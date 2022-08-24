using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using BBSK_PsychologistsTesting.Tests.Steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static BBSK_PsychologistsTesting.Tests.TestSources.CreateClientOrderTestSources;
using static BBSK_PsychologistsTesting.Tests.TestSources.PositiveTestSources.GetAllOrdersManagerTestSources;

namespace BBSK_PsychologistsTesting.Tests
{
    public class OrderingServicesTests
    {
        private OrderSteps _orderSteps;
        private ClientMapper _clientMapper;
        private DataCleaning _dataCleaning; 
        private ClientSteps _clientSteps;
        private OrderMapper _orderMapper;
        private PsychologistSteps _psychoSteps;
        List<int> _ordersId;
        private int orderId;
        private string token;
        private int clientlId;
        private string tokenManager;
        private int _psychologistId;
        public OrderingServicesTests()
        {
            _orderSteps = new OrderSteps();
            _clientMapper = new ClientMapper();
            _dataCleaning = new DataCleaning();
            _clientSteps = new ClientSteps();
            _orderMapper = new OrderMapper();
            _psychoSteps = new PsychologistSteps();
            _ordersId = new List<int>();
        }
        [SetUp]
        public void SetUp()
        {
            _dataCleaning.Clean();

            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "stringst",
                Email = "user@example.com",
                PhoneNumber = "88121691833",
                BirthDate = new DateTime(1980, 01, 01)
            };
            clientlId = _clientSteps.RegistrateClient(clientModel);
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst",
            };
            token = _clientSteps.AuthtorizeClientSystem(authModel);
            PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            { 
                Name = "Валерий",
                LastName = "Александрович",
                Patronymic = "Нежный",
                Gender = 1,
                BirthDate = new DateTime(1990, 05, 01, 10, 00, 25) ,
                Phone = "89992314543",
                Password = "Azino777",
                Email = "mhhpe@mail.ru",
                WorkExperience = 5,
                PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                Education = new List<string>() { "Мгу" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "когнитивная терапия" },
                Problems = new List<string>() { "тревога" },
                Price = 1000
            };
            _psychologistId = _psychoSteps.RegisterPsychologist(psychologistModel);           
            

            AuthRequestModel authModelbyManager = new AuthRequestModel()
            {
                Email = "manager@p.ru",
                Password = "Manager777",
            };
            tokenManager = _clientSteps.AuthtorizeClientSystem(authModelbyManager);
        }
        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }
        [TestCaseSource(typeof(OrderAdd_WhenOrderModelIsCorrect_TestSource))]
        public void OrderClientCreate_WhenOrderModelIsCorrect_ShouldCreateOrder( ClientOrdersRequestModel clientOrdersRequestModel)
        {

            orderId =_orderSteps.CreateClientOrder(token, clientOrdersRequestModel);
            ClientOrderResponseModel expectedOrderClient = _clientMapper.MappClientOrdersRequestModelToClientOrderResponsModel(clientOrdersRequestModel, orderId);
            //_orderSteps.GetClientClientById(orderId, token, expectedOrderClient);
        }
        
        [TestCaseSource(typeof(OrderAdd_WhenOrderModelIsCorrect_TestSource))]
        public void DeleteOrder_WhenManagerAthtorize_ShouldThrowCode204(ClientOrdersRequestModel clientOrdersRequestModel)
        {
            orderId = _orderSteps.CreateClientOrder(token, clientOrdersRequestModel);
            ClientOrderResponseModel expectedOrderClient = _clientMapper.MappClientOrdersRequestModelToClientOrderResponsModel(clientOrdersRequestModel, orderId);
            _orderSteps.DeleteOrderById(orderId, tokenManager);       
        }
        
        [TestCaseSource(typeof(GetAllOrdersManager_WhenAuthManagerIsCorrect_TestSource))]
        public void GetAllOrders_WhenManagerAthtorize_ShouldThrowCode204(List <ClientOrdersRequestModel> clientOrdersRequestModel)
        {
            foreach(var clientOrder in clientOrdersRequestModel)
            {
              clientOrder.PsychologistId = _psychologistId;
              orderId = _orderSteps.CreateClientOrder(token, clientOrder);
              _ordersId.Add(orderId);
            }
            List<ClientOrderGetAllResponseModel> clientOrderGetAllResponseModel = new List<ClientOrderGetAllResponseModel>();         
            for (int i = 0; i < clientOrdersRequestModel.Count; i++)
            {   
                clientOrderGetAllResponseModel.Add(_orderMapper.MappClientOrdersRequestModelToClientOrderGetAllResponsModel(clientOrdersRequestModel[i], _ordersId[i]));             
            }
            _orderSteps.GetAllOrdersModeration(tokenManager, clientOrderGetAllResponseModel);

        }
    }
}
