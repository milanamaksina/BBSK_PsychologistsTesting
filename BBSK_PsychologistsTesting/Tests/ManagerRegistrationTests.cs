using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Psychologist;
using NUnit.Framework;
using System.Net;
using System.Net.Http;

namespace BBSK_PsychologistsTesting.Tests
{
    public class ManagerRegistrationTests
    {
        private AuthClient _authManager = new AuthClient();

        [Test]
        public void ClientCreation_WhenClientModelIsCorrect_ShouldCreateClient()
        {
            //Given
            AuthRequestModel authManagerModel = new AuthRequestModel()
            {
                Email = "king@p.ru",
                Password = "Manager666",
            };
            HttpStatusCode expectedAuthCode = HttpStatusCode.OK;
            //When
            HttpResponseMessage authResponse = _authManager.AutorializeClient(authManagerModel);
            HttpStatusCode actualAuthCode = authResponse.StatusCode;
            string actualToken = authResponse.Content.ReadAsStringAsync().Result;
            //Then
            Assert.AreEqual(expectedAuthCode, actualAuthCode);
            Assert.NotNull(actualToken);
        }
    }
}
