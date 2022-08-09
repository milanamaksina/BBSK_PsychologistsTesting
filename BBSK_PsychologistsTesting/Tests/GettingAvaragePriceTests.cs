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
        int actualpsychoId;
        string token;
        string psychoToken;

        //[SetUp]
        //public void SetUp()
        //{

        //    PsychologistRequestModel psychologistModel = new PsychologistRequestModel()
        //    {
        //        Name = "Валерий",
        //        LastName = "Александрович",
        //        Patronymic = "Нежный",
        //        Gender = 1,
        //        BirthDate = new DateTime(2022, 05, 01),
        //        Phone = "89992314543",
        //        Password = "Azino777",
        //        Email = "valera@mail.ru",
        //        WorkExperience = 5,
        //        PasportData = "4015 2453443 ГУ МВД ПО СПБ",
        //        Education = new List<string> { "Мгу" },
        //        CheckStatus = 1,
        //        TherapyMethods = new List<string> { "когнитивная терапия" },
        //        Problems = new List<string> { "тревога" },
        //        Price = 1000
        //    };
        //    psychologistId = _psychoSteps.RegisterPsychologist(psychologistModel);

        //    AuthRequestModel authPsychoModel = new AuthRequestModel()
        //    {
        //        Email = "manager@p.ru",
        //        Password = "Manager777",
        //    };
        //    psychoToken = _clientSteps.AuthtorizeClientSystem(authPsychoModel);
        //}
        //[OneTimeTearDown]
        //public void OneTimeTearDown()
        //{
        //    _dataCleaning.Clean();
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    _dataCleaning.Clean();
        //}

        [TestCaseSource(typeof(PsychologistDelete_WhenPsychologistModelIsDeleted_TestSource))]
        public void GetAvaragePriceTest_WhenPriceModelIsCorrect_ShouldReturnPsychologistsAvaragePrice(List<PsychologistResponseModel> expectedPsychologists)
        {
            AuthRequestModel authPsychoModel = new AuthRequestModel()
            {
                Email = "psycho@p.ru",
                Password = "Helper000",
            };
            string token = _clientSteps.AuthtorizeClientSystem(authPsychoModel);

            decimal avaragePrice = 0;
            int count = 0;

            //List<PsychologistResponseModel> expectedPsychologists = new List<PsychologistResponseModel>();
            List<PsychologistResponseModel> allPsychologists = _psychoSteps.GetAllPsychologists(token, expectedPsychologists);

            foreach (PsychologistResponseModel model in allPsychologists)
            {
                avaragePrice += model.Price;
                count++;
            }

            decimal total = avaragePrice / count;

            PsychologistPriceRequestModel expectedTotal = new PsychologistPriceRequestModel
            {
                Price = total
            };

            _psychoSteps.GetAvaragePricePsychologists(token, expectedTotal);

        }
    }
}
