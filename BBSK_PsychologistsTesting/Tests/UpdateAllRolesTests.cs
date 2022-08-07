using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static BBSK_PsychologistsTesting.Tests.TestSources.UpdatePsychologistTestSources;

namespace BBSK_PsychologistsTesting.Tests
{
    public class UpdateAllRolesTests
    {      
        private ClientSteps _clientSteps = new ClientSteps();
        private PsychologistSteps _psychoSteps = new PsychologistSteps();
        private DataCleaning _dataCleaning = new DataCleaning();
        private ClientRequestModel clientModel = new ClientRequestModel();
        private PsychoMapper _psychoMapper = new PsychoMapper();
        int psychologistId;
        int actualId;
        string token;

        [SetUp]
        public void SetUp()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "0000000000",
                Email = "новаяппочта@oksf.ru",
                PhoneNumber = "88121691813",
                BirthDate = new DateTime(1980, 01, 01)
            };

            int actualId = _clientSteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "новаяппочта@oksf.ru",
                Password = "0000000000",
            };

            string token = _clientSteps.AuthtorizeClientSystem(authModel);

            PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            {
                Name = "Валерий",
                LastName = "Александрович",
                Patronymic = "Нежный",
                Gender = 1,
                BirthDate = new DateTime(2022, 05, 01),
                Phone = "89992314543",
                Password = "Azino777",
                Email = "valera@mail.ru",
                WorkExperience = 5,
                PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                Education = new List<string> { "Мгу" },
                CheckStatus = 1,
                TherapyMethods = new List<string> { "когнитивная терапия" },
                Problems = new List<string> { "тревога" },
                Price = 1000
            };
            psychologistId = _psychoSteps.RegisterPsychologist(psychologistModel);

            AuthRequestModel authPsychoModel = new AuthRequestModel()
            {
                Email = "valera@mail.ru",
                Password = "Azino777",
            };
            token = _clientSteps.AuthtorizeClientSystem(authPsychoModel);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

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
            //GetById
            PsychologistResponseModel expectedPsychologist = _psychoMapper.MappPsychologistRequestModelToPsychologistResponseModel(psychologistNewModel, psychologistId);
            _psychoSteps.GetPsychologistById(psychologistId, token, expectedPsychologist);
        }
        
        [Test]
        public void DataСhanged_WhenClientLogged_ShouldThrowCode422()
        {
            

            ClientUpdateRequestModel clientUpdateModel = new ClientUpdateRequestModel()
            {
                Name = "Чудо",
                LastName = "БольшоеЮдооо",
                BirthDate = new DateTime(1991, 06, 01)
            };

            _clientSteps.UpdateClient(actualId, clientUpdateModel, token);

            ClientGetIdResponseModel expectedClient = new ClientGetIdResponseModel()
            {
                Id = actualId,
                Name = clientUpdateModel.Name,
                LastName = clientUpdateModel.LastName,
                PhoneNumber = clientModel.PhoneNumber,
                Email = clientModel.Email,
                BirthDate = clientUpdateModel.BirthDate,
                RegistrationDate = DateTime.Now.Date,


            };
            _clientSteps.GetClientById(actualId, token, expectedClient);
        }
    }
}
