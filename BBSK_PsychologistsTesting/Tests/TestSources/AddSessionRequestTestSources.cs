using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class AddSessionRequestTestSources
    {
        public class OrderAdd_WhenOrderModelIsCorrect_TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new ClientOrdersRequestModel()
                {
                    ClientId = 1,
                    PsychologistId=1,
                    Cost=1000,
                    Duration=0,
                    Message="не убил бы и хорошо",
                    SessionDate= new DateTime(1990, 06, 01),
                    OrderDate= new DateTime(1990, 06, 01),
                    PayDate= new DateTime(1990, 06, 01),
                    OrderStatus= 0,
                    OrderPaymentStatus=0

                };
            }
        }
    }
}
