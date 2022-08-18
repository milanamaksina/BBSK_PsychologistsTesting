using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Psychologist;
using System;
using System.Collections;

namespace BBSK_PsychologistsTesting.Tests.TestSources.NegativeTestSources
{
    public class ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsNotCorrect_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ClientRequestModel()
                {
                    Name = "Орешек",
                    LastName = "Крепкий",
                    Password = "12345678",
                    Email = "vo",
                    PhoneNumber = "8981705890",
                    BirthDate = new DateTime(1990, 01, 01)
                },
                 new AuthRequestModel()
                 {
                    Email = "vo",
                    Password = "12345678",
                 }
             };

            yield return new object[]
                {
                new ClientRequestModel()
                {
                    Name = "Орешек2",
                    LastName = "Крепкий2",
                    Password = "12345678",
                    Email = "voVO@vovov.",
                    PhoneNumber = "8981705890",
                    BirthDate = new DateTime(1990, 01, 01)
                },
                new AuthRequestModel()
                {
                    Email = "voVO@vovov.",
                    Password = "12345678",
                }
                };
                 yield return new object[]
                 {
                new ClientRequestModel()
                 {
                    Name = "Орешек3",
                    LastName = "Крепкий3",
                    Password = "1234567",
                    Email = "voVO@vovov.ru",
                    PhoneNumber = "8981705890",
                    BirthDate = new DateTime(1990, 01, 01)
                 },
                 new AuthRequestModel()
                {
                    Email = "voVO@vovov.ru",
                    Password = "1234567",
                }
                 };
            yield return new object[]
               {
                new ClientRequestModel()
                {
                    Name = "Орешек4",
                    LastName = "Крепкий4",
                    Password = "12345678",
                    Email = "",
                    PhoneNumber = "8981705890",
                    BirthDate = new DateTime(1990, 01, 01)
                },
                 new AuthRequestModel()
                {
                    Email = "",
                    Password = "12345678",
                }
                };
            yield return new object[]
               {
                new ClientRequestModel()
                {
                    Name = "Орешек4",
                    LastName = "Крепкий4",
                    Password = "",
                    Email = "",
                    PhoneNumber = "8981705890",
                    BirthDate = new DateTime(1990, 01, 01)
                },
                 new AuthRequestModel()
                {
                    Email = "",
                    Password = "",
                }
                };
        }
        
    }
}
