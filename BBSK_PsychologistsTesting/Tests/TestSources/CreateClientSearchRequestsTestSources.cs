using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class CreateClientSearchRequestsTestSources
    {
        public class SearchRequests_WhenSearchRequestsIsCorrect_TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new SearchRequestsRequestsModel()
                {
                    Name = "Вася",
                    PhoneNumber = "8888888888",
                    Description = "Тот что не дурак, а дурак не нужен",
                    PsychologistGender = 0,
                    CostMin = 0,
                    CostMax = 5000,
                    Date = new DateTime(2022, 08, 05),
                    Time = 1                  
                };
            }
        }
    }
}
