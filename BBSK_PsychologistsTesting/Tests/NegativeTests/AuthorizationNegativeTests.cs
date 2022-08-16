using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Options;
using BBSK_PsychologistsTesting.Psychologist;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Tests.Steps;
using BBSK_PsychologistsTesting.Tests.TestSources.NegativeTestSources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.NegativeTests
{
    public class AuthorizationNegativeTests
    {
        private DataCleaning _dataCleaning;
        private ClientSteps _clientSteps;
        private AuthClient _authClient;
        private ClientNegativeSteps _clientNegativeSteps;
        public AuthorizationNegativeTests()
        {
            _dataCleaning = new DataCleaning();
            _clientSteps=new ClientSteps();
            _authClient = new AuthClient();
            _clientNegativeSteps = new ClientNegativeSteps();

        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dataCleaning.Clean();
        }

        [TearDown]
        public void TearDown()
        {
            _dataCleaning.Clean();
        }
        [TestCaseSource(typeof(ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsNotCorrect_TetsSource))]
        public void ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsNotCorrect_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRequestModel clientModel, AuthRequestModel authModel)
        {
            _clientSteps.RegistrateClient(clientModel);
            _clientNegativeSteps.AuthorizeWhenAuthenticationFailedNegativeTest(authModel);
        }
    }
}
