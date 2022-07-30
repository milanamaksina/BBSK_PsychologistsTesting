using NUnit.Framework;
using System;
using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;
using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Steps;
using BBSK_PsychologistsTesting.Psychologist;

namespace BBSK_PsychologistsTesting.Tests
{
    public class ClientDataChangesTests
    {
        [Test]
        public void DataСhanged_WhenClientLogged_ShouldThrowCode422()
        {
            ClientsUpdateRequestModel clientupdateModel = new ClientsUpdateRequestModel()
            {
                Name = "Кукумбер",
                LastName = "CанБаян",
                BirthDate = new DateTime(1991, 06, 01)
            };
        }
    }
}
