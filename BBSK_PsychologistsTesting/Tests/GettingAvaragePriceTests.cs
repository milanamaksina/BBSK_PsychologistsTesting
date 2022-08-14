using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Support.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BBSK_PsychologistsTesting.Tests.TestSources.DeletePsychologistByIdTestSources;

namespace BBSK_PsychologistsTesting.Tests
{
    public class GettingAvaragePriceTests
    {
        private ClientSteps _clientSteps = new ClientSteps();
        private PsychologistSteps _psychoSteps = new PsychologistSteps();
        private DataCleaning _dataCleaning = new DataCleaning();

        int psychologistId;
        int actualId;
        string token;
        string psychoToken;

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
                Email = "valeriy@mail.ru",
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
                Email = "valeriy@mail.ru",
                Password = "Azino777",
            };
            psychoToken = _clientSteps.AuthtorizeClientSystem(authPsychoModel);

            ClientRequestModel clientModel = new ClientRequestModel()
            {
                Name = "Ляшка",
                LastName = "Какашка",
                Password = "12345678",
                Email = "жела@ooaaoks.ru",
                PhoneNumber = "8888044617",
                BirthDate = new DateTime(1991, 06, 01)
            };// я создал модельку

            actualId = _clientSteps.RegistrateClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = "жела@ooaaoks.ru",
                Password = "12345678",
            };// я создал модельку 

            token = _clientSteps.AuthtorizeClientSystem(authModel);

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

        [TestCaseSource(typeof(PsychologistDelete_WhenPsychologistModelIsDeleted_TestSource))]
        public void GetAvaragePriceTest_WhenPriceModelIsCorrect_ShouldReturnPsychologistsAvaragePrice(List<PsychologistResponseModel> expectedPsychologists)
        {
            AuthRequestModel authClientModel = new AuthRequestModel()
            {
                Email = "help@example.com",
                Password = "Azino777",
            };
            token = _clientSteps.AuthtorizeClientSystem(authClientModel);

            decimal avaragePrice = 0;
            int count = 0;

            List<PsychologistResponseModel> allPsychologists = _psychoSteps.GetAllPsychologists(token, expectedPsychologists);

            foreach (PsychologistResponseModel model in allPsychologists)
            {
                avaragePrice += model.Price;
                count++;
            }

            decimal total = avaragePrice / count;

            _psychoSteps.GetAvaragePricePsychologists(psychoToken, total);

        }
    }
}
