using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests
{
    public class PsychologistGetAvaragePriceTests
    {
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
        private AuthSteps _authPsychologist = new AuthSteps();
        private PsychologistsSteps _psychoSteps = new PsychologistsSteps();

        public void PsychologistGetAvaragePrice_WhenRequestIsCorrect_ShouldReturnAvaragePriceOfAllPsychologists()
        {
            //Регистрация 
            PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
            {
                Name = "Андрей",
                LastName = "Александрович",
                Patronymic = "Нежный",
                Gender = 1,
                BirthDate = new DateTime(1989, 05, 01),
                Phone = "89992314543",
                Password = "Azino777",
                Email = "bratValery@mail.ru",
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
                Email = "bratValery@mail.ru",
                Password = "Azino777",
            };
            string token = _authPsychologist.AuthtorizeClientSystem(authModel);

        }
    }
}
