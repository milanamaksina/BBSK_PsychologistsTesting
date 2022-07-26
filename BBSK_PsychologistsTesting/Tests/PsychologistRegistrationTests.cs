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
    public class PsychologistRegistrationTests
    {
        private PsychologistsPsychologist _psychologistsPsychologist = new PsychologistsPsychologist();
        private AuthPsychologist _authPsychologist = new AuthPsychologist();


        [Test]
        public void PsychologistCreation_WhenPsychologistModelIsCorrect_ShouldCreatePsychologist()
        {
            //Given
            //AuthRequestModel authModel = new AuthRequestModel()
            //{
            //    Email = "manager@p.ru",
            //    Password = "Manager777",
            //};
            //HttpStatusCode expectedAuthCode = HttpStatusCode.OK;
            //HttpClient psycho = new HttpClient();
            ////When
            //HttpResponseMessage authResponse = _authPsychologist.Authorize(authModel);
            //HttpStatusCode actualAuthCode = authResponse.StatusCode;
            //string actualToken = authResponse.Content.ReadAsStringAsync().Result;
            //psycho.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", actualToken);
            ////Then
            //Assert.AreEqual(expectedAuthCode, actualAuthCode);
            //Assert.NotNull(actualToken);

            //Регистрация
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

            int psychologistId = (int)actualId;

            //Авторизация
            //Given
            AuthRequestModel authModel = new AuthRequestModel()
            {
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
            HttpContent content = _psychologistsPsychologist.GetPsychologistById(psychologistId, token, HttpStatusCode.OK);
            PsychologistResponseModel actualPsychologist = JsonSerializer.Deserialize<PsychologistResponseModel>(content.ReadAsStringAsync().Result);
            Assert.AreEqual(expectedPsychologist, actualPsychologist);


        }
        
    }
}
