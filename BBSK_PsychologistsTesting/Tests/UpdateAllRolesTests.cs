using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace BBSK_PsychologistsTesting.Tests
{
    public class UpdateAllRolesTests
    {      
        private ClientSteps _clientSteps = new ClientSteps();
        private PsychologistSteps _psychoSteps = new PsychologistSteps();
        private DataCleaning _dataCleaning = new DataCleaning();
        private ClientRequestModel clientModel = new ClientRequestModel();
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
        }

        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }

        [Test]
        public void PsychologistUpdate_WhenPsychologistModelIsCorrect_ShouldUpdatePsychologist()
        {
            //Регистрация - баг 2.7 
            //Given 
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
            int psychologistId = _psychoSteps.RegisterPsychologist(psychologistModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "valera@mail.ru",
                Password = "Azino777",
            };
            string token = _clientSteps.AuthtorizeClientSystem(authModel);


            //редактирование - баг 2.16 
            PsychologistRequestModel psychologistNewModel = new PsychologistRequestModel()
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
            _psychoSteps.UpdatePsychologistById(psychologistId, psychologistNewModel, token);

            //Гет по айди 
            PsychologistResponseModel expectedPsychologist = new PsychologistResponseModel()
            {
                Id = psychologistId,
                Name = psychologistNewModel.Name,
                LastName = psychologistNewModel.LastName,
                Patronymic = psychologistNewModel.Patronymic,
                Gender = psychologistNewModel.Gender,
                BirthDate = psychologistNewModel.BirthDate,
                Phone = psychologistNewModel.Phone,
                Password = psychologistNewModel.Password,
                Email = psychologistNewModel.Password,
                WorkExperience = psychologistNewModel.WorkExperience,
                PasportData = psychologistNewModel.PasportData,
                Education = psychologistNewModel.Education,
                CheckStatus = psychologistNewModel.CheckStatus,
                TherapyMethods = psychologistNewModel.TherapyMethods,
                Problems = psychologistNewModel.Problems,
                Price = psychologistNewModel.Price,

            };
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

            ClientGetIdResponsModel expectedClient = new ClientGetIdResponsModel()
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
