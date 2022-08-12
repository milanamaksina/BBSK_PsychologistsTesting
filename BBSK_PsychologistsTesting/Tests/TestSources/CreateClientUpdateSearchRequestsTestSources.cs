using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class CreateClientUpdateSearchRequestsTestSources
    {
        public class SearchRequestsUpdateClients_WhenSearchRequestsIsCorrect_TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                    {
                   new SearchRequestsRequestsModel()
                   {
                    Name = "Васiiiiii",
                    PhoneNumber = "89817051890",
                    Description = "Тот что не дурак, а дурак не нужен",
                    PsychologistGender = 1,
                    CostMin = 2000,
                    CostMax = 6000,
                    Date = new DateTime(2001, 07, 01),
                    Time = 1
                   },

                    new SearchRequestsRequestsModel()

                {
                    Name = "Вася",
                    PhoneNumber = "89817051890",
                    Description = "Тот что не дурак, а дурак не нужен",
                    PsychologistGender = 1,
                    CostMin = 4000,
                    CostMax = 10000,
                    Date = new DateTime(2001, 07, 01),
                    Time = 1
                }
                    };


            }
        }
    }
}
