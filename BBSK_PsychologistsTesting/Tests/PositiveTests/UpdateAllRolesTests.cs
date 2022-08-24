using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using NUnit.Framework;
using System;
using static BBSK_PsychologistsTesting.Tests.TestSources.PositiveTestSources.UpdateClientTestSourses;
using static BBSK_PsychologistsTesting.Tests.TestSources.UpdatePsychologistTestSources;

namespace BBSK_PsychologistsTesting.Tests
{
    public class UpdateAllRolesTests
    {
        private ClientSteps _clientSteps; 
        private PsychologistSteps _psychoSteps; 
        private DataCleaning _dataCleaning; 
        private ClientRequestModel clientModel; 
        private PsychoMapper _psychoMapper;
        private ClientMapper _clientMapper;
        private int psychologistId;
        private int actualId;
        private string token;

        public UpdateAllRolesTests()
        {
            _clientSteps = new ClientSteps();   
            _psychoSteps = new PsychologistSteps();
            _dataCleaning = new DataCleaning();
            _psychoMapper = new PsychoMapper();
            _clientMapper = new ClientMapper();
        }
        [SetUp]
        public void SetUp()
        {
            _dataCleaning.Clean();

            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "0000000000",
                Email = "новаяппочта@oksf.ru",
                PhoneNumber = "88121691813",
                BirthDate = new DateTime(1980, 01, 01)
            };
            actualId = _clientSteps.RegistrateClient(clientModel);
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "новаяппочта@oksf.ru",
                Password = "0000000000",
            };
            token = _clientSteps.AuthtorizeClientSystem(authModel);
            //PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            //{
            //    Name = "Валерий",
            //    LastName = "Александрович",
            //    Patronymic = "Нежный",
            //    Gender = 1,
            //    BirthDate = new DateTime(2022, 05, 01),
            //    Phone = "89992314544",
            //    Password = "Azino777",
            //    Email = "valer@mail.ru",
            //    WorkExperience = 5,
            //    PasportData = "4015 2453443 ГУ МВД ПО СПБ",
            //    Education = new List<string> { "Мгу" },
            //    CheckStatus = 1,
            //    TherapyMethods = new List<string> { "когнитивная терапия" },
            //    Problems = new List<string> { "тревога" },
            //    Price = 1000
            //};
            //psychologistId = _psychoSteps.RegisterPsychologist(psychologistModel);

            //AuthRequestModel authPsychoModel = new AuthRequestModel()
            //{
            //    Email = "manager@p.ru",
            //    Password = "Manager777",
            //};
            //psychoToken = _clientSteps.AuthtorizeClientSystem(authPsychoModel);
        }
        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }

        [TestCaseSource(typeof(PsychologistUpdate_WhenPsychologistModelIsCorrect_TestSource))]
        public void PsychologistUpdate_WhenPsychologistModelIsCorrect_ShouldUpdatePsychologist(PsychologistRequestModel psychologistNewModel)
        {
            _psychoSteps.UpdatePsychologistById(psychologistId, psychologistNewModel, token);
            PsychologistResponseModel expectedPsychologist = _psychoMapper.MappPsychologistRequestModelToPsychologistResponseModel(psychologistNewModel, psychologistId);
            _psychoSteps.GetPsychologistById(psychologistId, token, expectedPsychologist);
        }

        [TestCaseSource(typeof(PersonalDataUpdateClients_WhenClientIsCorrect_TestSource))]
        public void DataСhanged_WhenClientLogged_ShouldThrowCode204(ClientRequestModel ClientRegistrationModel, ClientRequestModel newClientUpdateModel)
        {         
            _clientSteps.UpdateClient(actualId, newClientUpdateModel,token);
            var data=DateTime.Now.Date;
            ClientResponseModel expectedClientResponseModel=_clientMapper.MappClientRequestModelToClientResponsModel(data,newClientUpdateModel,actualId);
            _clientSteps.GetClientById(actualId, token, expectedClientResponseModel);
        }
    }
}
