using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class CreateClientOrderTestSources
    {
        public class OrderAdd_WhenOrderModelIsCorrect_TestSource : IEnumerable
        {


            public IEnumerator GetEnumerator()
            {
                yield return new ClientOrdersRequestModel()
                {                
                    PsychologistId=55,                  
                    Duration=1,
                    Message="не убил бы и хорошо",
                    SessionDate= new DateTime(2022, 08, 31),
                    OrderDate= new DateTime(2022, 08, 23),
                    PayDate= new DateTime(2022, 08, 23),
                    OrderStatus= 1,
                    OrderPaymentStatus=1
                };
            }
        }
    }
}
