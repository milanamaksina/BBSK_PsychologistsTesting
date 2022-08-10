using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class GetAllInfoClientTestSources
    {
        public class GetAllInfoClient_WhenClientRequestIsCorrect_TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                    {
                   new ClientRequestModel()
                   {
                    Name = "Васiiiiii",
                    LastName= "Дурачок",
                    Password="123456789",
                    Email="vovo@vovo.com",
                    PhoneNumber = "89817051890",
                    BirthDate= new DateTime(2000, 05, 01)

                   },

                    new ClientRequestModel()
                   {
                    Name = "Пулька",
                    LastName= "Ляля",
                    Password="123456789",
                    Email="vorota@vovo.com",
                    PhoneNumber = "89817051880",
                    BirthDate= new DateTime(2000, 04, 01)

                   },
                    };


            }
        }
    }
}
