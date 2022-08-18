using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using System;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Tests
{
    public class DeletePsychologistsTests
    {
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
        private ClientSteps _clientSteps = new ClientSteps();
        private PsychologistSteps _psychoSteps = new PsychologistSteps();

        public void PsychologistDelete_WhenPsychologistModelIsCorrect_ShouldDeletePsychologist()
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

            _psychoSteps.DeletePsychologistById(psychologistId, token);

        }
    }
}
