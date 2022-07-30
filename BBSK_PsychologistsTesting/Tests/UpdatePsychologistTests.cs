using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests
{
    public class UpdatePsychologistTests
    {
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
        private AuthSteps _authPsychologist = new AuthSteps();
        private PsychologistsSteps _psychoSteps = new PsychologistsSteps();

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
            string token = _authPsychologist.AuthtorizeClientSystem(authModel);


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
    }
}
