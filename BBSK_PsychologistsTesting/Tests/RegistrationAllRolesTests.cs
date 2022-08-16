using System;
using System.Collections.Generic;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Steps;

namespace BBSK_PsychologistsTesting.Tests
{
    public class RegistrationAllRolesTests
    {
        private ClientSteps _clientSteps= new ClientSteps();
        private PsychologistSteps _psychoSteps = new PsychologistSteps();
        

        [Test]
        public void PsychologistCreation_WhenPsychologistModelIsCorrect_ShouldCreatePsychologist()
        {
            //Регистрация 
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

            //Авторизация 
            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "valera@mail.ru",
                Password = "Azino777",
            };
            string token = _clientSteps.AuthtorizeClientSystem(authModel);

            //Гет по айди 
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
                Email = "valeraffffffffff@mail.ru",
                WorkExperience = 5,
                PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                Education = new List<string> { "Мгу" },
                CheckStatus = 1,
                TherapyMethods = new List<string> { "когнитивная терапия" },
                Problems = new List<string> { "тревога" },
                Price = 1000
            };

            _psychoSteps.RegisterPsychologist_WhenPsychoModelIsWrong_ShouldThrowException(psychologistModel);
        }

        [Test]
        public void PsychologistCreation_WhenBirthDateMoreThanCurrentDate_ShouldThrowCode422()
        {
            PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            {
                Name = "Валерий",
                LastName = "Александрович",
                Patronymic = "Нежный",
                Gender = 1,
                BirthDate = new DateTime(2040, 05, 01),
                Phone = "89992314543",
                Password = "1234567890230",
                Email = "valeraffffffffff@mail.ru",
                WorkExperience = 5,
                PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                Education = new List<string> { "Мгу" },
                CheckStatus = 1,
                TherapyMethods = new List<string> { "когнитивная терапия" },
                Problems = new List<string> { "тревога" },
                Price = 1000
            };

            _psychoSteps.RegisterPsychologist_WhenPsychoModelIsWrong_ShouldThrowException(psychologistModel);
        }

        [Test]
        public void PsychologistCreation_WhenDataIsEmpty_ShouldThrowCode422()
        {
            PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            {
                Name = "",
                LastName = "",
                Patronymic = "Нежный",
                Gender = 1,
                BirthDate = new DateTime(2040, 05, 01),
                Phone = "",
                Password = "",
                Email = "valeraffffffffff@mail.ru",
                WorkExperience = 5,
                PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                Education = new List<string> { "Мгу" },
                CheckStatus = 1,
                TherapyMethods = new List<string> { "когнитивная терапия" },
                Problems = new List<string> { "тревога" },
                Price = 1000
            };


            _psychoSteps.RegisterPsychologist_WhenPsychoModelIsWrong_ShouldThrowException(psychologistModel);
        }

        [Test]
        public void ClientCreation_WhenPasswordIsLessThan8Symbols_ShouldThrowCode422()
        {
            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Ляшка",
                LastName = "Какашка",
                Password = "12345678",
                Email = "vo@ooaaoks.ru",
                PhoneNumber = "8888044617",
                BirthDate = new DateTime(1991, 06, 01)
            };// я создал модельку

            int actualId = _clientSteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "vo@ooaaoks.ru",
                Password = "12345678",
            };// я создал модельку 

            string token = _clientSteps.AuthtorizeClientSystem(authModel);


        }


    }
    
}
