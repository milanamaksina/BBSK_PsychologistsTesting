using System;
using System.Collections.Generic;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Options;
using System.ComponentModel.DataAnnotations;

namespace BBSK_PsychologistsTesting.Tests
{
    public class RegistrationTests
    {
        private string token;
        private int psychologistId;
        private ClientSteps _clientSteps;
        private PsychologistSteps _psychoSteps;
        private DataCleaning _dataCleaning;
        public RegistrationTests()
        {
            _clientSteps = new ClientSteps();
            _psychoSteps = new PsychologistSteps();
            _dataCleaning = new DataCleaning();
        }
        
        [Test]
        public void PsychologistCreation_WhenPsychologistModelIsCorrect_ShouldCreatePsychologist()
        {
            _dataCleaning.Clean();
            
            PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            {
                Name = "Валерий",
                LastName = "Александрович",
                Patronymic = "Нежный",
                Gender = 1,
                BirthDate = new DateTime(1990, 05, 01, 10, 00, 25) ,
                Phone = "89992314543",
                Password = "Azino777",
                Email = "valerauu@mail.ru",
                WorkExperience = 5,
                PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                Education = new List<string>(){ "Мгу" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "когнитивная терапия" },
                Problems = new List<string>() { "тревога" },
                Price = 1000
            };
            psychologistId = _psychoSteps.RegisterPsychologist(psychologistModel);           
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "valerauu@mail.ru",
                Password = "Azino777",
            };
            token = _clientSteps.AuthtorizeClientSystem(authModel);
            PsychologistResponseModel expectedPsychologist = new PsychologistResponseModel()
            {
                Id = psychologistId,
                Name = psychologistModel.Name,
                LastName = psychologistModel.LastName,
                Patronymic = psychologistModel.Patronymic,
                Gender = psychologistModel.Gender,
                BirthDate = psychologistModel.BirthDate,
                Phone = psychologistModel.Phone,
                Password = psychologistModel.Password,
                Email = psychologistModel.Password,
                WorkExperience = psychologistModel.WorkExperience,
                PasportData = psychologistModel.PasportData,
                Education = psychologistModel.Education,
                CheckStatus = psychologistModel.CheckStatus,
                TherapyMethods = psychologistModel.TherapyMethods,
                Problems = psychologistModel.Problems,
                Price = psychologistModel.Price,

            };
            _psychoSteps.GetPsychologistById(psychologistId, token, expectedPsychologist);
        }
        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }
        [Test]
        public void PsychologistCreation_WhenPasswordIsLessThan8Symbols_ShouldThrowCode422()
        {
            PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            {
                Name = "Валерий",
                LastName = "Александрович",
                Patronymic = "Нежный",
                Gender = 1,
                BirthDate = new DateTime(2022, 05, 01),
                Phone = "89992314543",
                Password = "123",
                Email = "valerapp@mail.ru",
                WorkExperience = 5,
                PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                Education = new List<string> { "Мгу" },
                CheckStatus = 1,
                TherapyMethods = new List<string> { "когнитивная терапия" },
                Problems = new List<string> { "тревога" },
                Price = 1000
            };

            psychologistId = _psychoSteps.RegisterPsychologist(psychologistModel);
        }

        [Test]
        public void ClientCreation_WhenPasswordIsLessThan8Symbols_ShouldThrowCode201()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Ляшка",
                LastName = "Какашка",
                Password = "12345678",
                Email = "vo@ooaaok.ru",
                PhoneNumber = "8888044617",
                BirthDate = new DateTime(1991, 06, 01)
            };
            int actualId = _clientSteps.RegistrateClient(clientModel);
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "vo@ooaaok.ru",
                Password = "12345678",
            };
            token = _clientSteps.AuthtorizeClientSystem(authModel);
        }
        [Test]
        public void ManagerAuth_WhenPasswordIsMoreOrEqualThan8Symbols_ShouldThrowCode200()
        {
            AuthRequestModel authManagerModel = new AuthRequestModel()
            {
                Email = "manager@p.ru",
                Password = "Manager777",
            };
             token = _clientSteps.AuthtorizeClientSystem(authManagerModel);
        }
    }
    
}
