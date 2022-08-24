using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Tests.TestSources.PositiveTestSources
{
   public class GetAllOrdersManagerTestSources
    {
        public class GetAllOrdersManager_WhenAuthManagerIsCorrect_TestSource : IEnumerable
        {
            


            public IEnumerator GetEnumerator()
            {
                List<ClientOrdersRequestModel> clientOrdersRequestModel = new List<ClientOrdersRequestModel>()
                {
                    new ClientOrdersRequestModel()
                {
                    
                    Cost = 1000,
                    Duration=1,
                    Message="Все бесят",
                    SessionDate= new DateTime(2022, 08, 25),
                    OrderDate= new DateTime(2022,08,23),
                    PayDate= new DateTime(2022, 08, 23),
                    OrderStatus=1,
                    OrderPaymentStatus=2,
                },
                    new ClientOrdersRequestModel()
                {
                    Cost = 1000,
                    Duration = 1,
                    Message = "Психоз",
                    SessionDate = new DateTime(2022, 08, 27),
                    OrderDate = new DateTime(2022, 08, 23),
                    PayDate = new DateTime(2022, 08, 23),
                    OrderStatus = 2,
                    OrderPaymentStatus = 2,
                }
            };                             
                yield return clientOrdersRequestModel;
            }
        }
    }
}
