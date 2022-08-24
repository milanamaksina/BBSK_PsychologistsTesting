using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;

namespace BBSK_PsychologistsTesting.Tests.TestSources.PositiveTestSources
{
    public class UpdateClientTestSourses
    {
        public class PersonalDataUpdateClients_WhenClientIsCorrect_TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]

                {
                    new ClientRequestModel ()
                    {
                        Name="Чудо",
                        LastName="Юдо",
                        Password = "0000000000",
                        Email = "новаяппочта@oksf.ru",
                        PhoneNumber = "88121691813",
                        BirthDate = new DateTime(1980, 01, 01)
                    },

                    new ClientRequestModel ()
                    {
                        Name="Чуд",
                        LastName="БольшоеЮдоооААА",
                        Password = "0000000000",
                        Email = "новаяппочта@oksf.ru",
                        PhoneNumber = "88121691813",
                        BirthDate = new DateTime(1980, 01, 01)
                    }
                };

            }
                
                

                
        }
                

    }
}
