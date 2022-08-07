using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Tests
{
    public class DeleteAllRoleById
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
            _dataCleaning.Clean();
        }

        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
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
