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
                    ClientId = 243,
                    PsychologistId=55,
                    Cost=1000,
                    Duration=0,
                    Message="не убил бы и хорошо",
                    SessionDate= new DateTime(2022, 08, 31),
                    OrderDate= new DateTime(2022, 08, 05),
                    PayDate= new DateTime(2022, 08, 05),
                    OrderStatus= 0,
                    OrderPaymentStatus=0

                };
            }
        }
    }
}
