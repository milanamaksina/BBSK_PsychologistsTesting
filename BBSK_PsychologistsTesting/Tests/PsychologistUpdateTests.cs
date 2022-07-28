using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;
using System.Text.Json;
using BBSK_PsychologistsTesting.Models.Request;
using System.Net.Http.Headers;
using BBSK_PsychologistsTesting.Models.Response;

namespace BBSK_PsychologistsTesting.Tests
{
    public class PsychologistUpdateTests
    {
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
        private AuthPsychologist _authPsychologist = new AuthPsychologist();

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
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpResponseMessage response = _psychologistsPsychologist.RegisterPsychologist(psychologistModel);
            HttpStatusCode actualRegistrationCode = response.StatusCode;
            int? actualId = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
            //Then
            Assert.AreEqual(expectedRegistrationCode, actualRegistrationCode);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            int psychologistId = 39 /*(int)actualId*/;

            //Авторизация - баг 2.15
            //Given
            AuthRequestModel authModel = new AuthRequestModel()
            {
                //Email = "valera@mail.ru",
                //Password = "Azino777",
                Email = "valera@mail.ru",
                Password = "Azino777",
            };
            HttpStatusCode expectedAuthCode = HttpStatusCode.Created;
            //When
            HttpResponseMessage authResponse = _authPsychologist.Authorize(authModel);
            HttpStatusCode actualAuthCode = authResponse.StatusCode;
            string actualToken = authResponse.Content.ReadAsStringAsync().Result;
            //Then
            Assert.AreEqual(expectedAuthCode, actualAuthCode);
            Assert.NotNull(actualToken);

            string token = actualToken;

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
            HttpStatusCode expectedUpdateCode = HttpStatusCode.OK;
            //When
            HttpResponseMessage updateResponse = _psychologistsPsychologist.UpdatePsychologistById(psychologistNewModel, psychologistId, token, expectedUpdateCode);
            HttpStatusCode actualUpdateCode = updateResponse.StatusCode;
            string actualUpdateToken = updateResponse.Content.ReadAsStringAsync().Result;
            //Then
            Assert.AreEqual(expectedUpdateCode, actualUpdateCode);
            Assert.NotNull(actualToken);
        }



























    }


}

