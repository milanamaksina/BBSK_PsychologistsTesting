using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;


namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class CreateClientSearchRequestsTestSources
    {
        public class SearchRequests_WhenSearchRequestsIsCorrect_TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {            
                yield return new object[]
                    {
                   new SearchRequestsRequestsModel()
                   {
                    Name = "Чудо",
                    PhoneNumber = "88121691837",
                    Description = "Тот что не дурак, а дурак не нужен",
                    PsychologistGender = 1,
                    CostMin = 2000,
                    CostMax = 6000,
                    Date = new DateTime(2001, 07, 01),
                    Time = 1
                   }              
                    };


            }
        }
    }
}
