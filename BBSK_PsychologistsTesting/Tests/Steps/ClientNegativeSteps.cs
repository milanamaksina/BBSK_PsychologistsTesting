using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Psychologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.Steps
{
    public class ClientNegativeSteps
    {
        private ClientsClient _clientsClient;
        private AuthClient _authClient;

        public ClientNegativeSteps()
        {
            _clientsClient= new ClientsClient();
            _authClient = new AuthClient();
        }
        public void RegisterClientNegativeTest(ClientRequestModel model)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.UnprocessableEntity;         
            _clientsClient.RegistrationClient(model, expectedRegistrationCode);
        }
        public void AuthorizeWhenAuthenticationFailedNegativeTest(AuthRequestModel authModel)
        {
            HttpStatusCode expectedAuthCode = HttpStatusCode.Unauthorized;
            _authClient.AutorializeClient(authModel, expectedAuthCode);
        }

    }
}
