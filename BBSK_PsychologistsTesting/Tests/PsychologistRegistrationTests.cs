using System;
using System.Collections.Generic;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Steps;

namespace BBSK_PsychologistsTesting.Tests
{
    public class PsychologistRegistrationTests
    {
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
        private ClientSteps _authPsychologist = new ClientSteps();
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
            string token = _authPsychologist.AuthtorizeClientSystem(authModel);

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
        }   
    }
}
