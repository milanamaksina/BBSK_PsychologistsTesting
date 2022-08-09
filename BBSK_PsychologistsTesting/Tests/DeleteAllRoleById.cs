using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static BBSK_PsychologistsTesting.Tests.TestSources.DeletePsychologistByIdTestSources;

namespace BBSK_PsychologistsTesting.Tests
{
    public class DeleteAllRoleById
    {    
        private ClientSteps _clientSteps = new ClientSteps();
        private PsychologistSteps _psychoSteps = new PsychologistSteps();
        private DataCleaning _dataCleaning = new DataCleaning();
        private PsychoMapper _psychoMapper = new PsychoMapper();
        int psychologistId;
        int actualpsychoId;
        string token;
        string psychoToken;

        [SetUp]
        public void SetUp()
        {

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
                Email = "manager@p.ru",
                Password = "Manager777",
            };
            psychoToken = _clientSteps.AuthtorizeClientSystem(authPsychoModel);
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

        [TestCaseSource(typeof(PsychologistDelete_WhenPsychologistModelIsDeleted_TestSource))]
        public void PsychologistDelete_WhenPsychologistModelIsCorrect_ShouldDeletePsychologist(int psychologistId, PsychologistRequestModel psychologistIsDeletedModel, List<PsychologistRequestModel> allPsychologistModels)
        {
            _psychoSteps.DeletePsychologistById(psychologistId, psychoToken);
            //GetById
            PsychologistResponseModel expectedPsychologist = _psychoMapper.MappPsychologistRequestModelToPsychologistResponseModel(psychologistIsDeletedModel, psychologistId);
            _psychoSteps.GetPsychologistById(psychologistId, psychoToken, expectedPsychologist);

            List<PsychologistResponseModel> expectedAllPsychologists = _psychoMapper.MappAllPsychologistsRequestModelToPsychologistResponseModel(allPsychologistModels);
            _psychoSteps.GetAllPsychologists(psychoToken, expectedAllPsychologists);
        }

        [Test]
        public void DeleteClient_WhenClientRegistrateAthtorize_ShouldThrowCode204()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Чудо",
                LastName = "Юдо",
                Password = "0000000000",
                Email = "новая почта@oksf.ru",
                PhoneNumber = "812345678",
                BirthDate = new DateTime(1980, 01, 01)
            };

            int actualId = _clientSteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "рп@oksf.ru",
                Password = "111111111",
            }; 

            string token = _clientSteps.AuthtorizeClientSystem(authModel);

            _clientSteps.DeleteClientById(actualId, token);

        }
    }
}
