﻿using BBSK_PsychologistsTesting.Models.Request;
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
            ClientRequestModel clientRequestModelOne;
            ClientRequestModel clientRequestModelTwo;
            ClientRequestModel clientRequestModelTree;

            public IEnumerator GetEnumerator()
            {
                List<ClientRequestModel> clientRequestModels = new List<ClientRequestModel>();
                


                  clientRequestModelOne = new ClientRequestModel()
                {
                    Name = "Васiiiiii",
                    LastName = "Дурачок",
                    Password = "123456789",
                    Email = "vovo@vo.com",
                    PhoneNumber = "89817051890",
                    BirthDate = new DateTime(2000, 05, 01)

                };

                    clientRequestModelTwo= new ClientRequestModel()
                    {
                        Name = "Пулька",
                        LastName = "Ляля",
                        Password = "123456789",
                        Email = "vorota@vovo.com",
                        PhoneNumber = "89817051880",
                        BirthDate = new DateTime(2000, 04, 01)

                    };

                    clientRequestModelTree= new ClientRequestModel()
                    {
                        Name = "Сосулька",
                        LastName = "Новогодняя",
                        Password = "123456789",
                        Email = "vorona@vo.com",
                        PhoneNumber = "89817051889",
                        BirthDate = new DateTime(2000, 04, 01)


                    };
                clientRequestModels.Add(clientRequestModelOne);
                clientRequestModels.Add(clientRequestModelTwo);
                clientRequestModels.Add(clientRequestModelTree);
                yield return clientRequestModels;


            }
        }
    }
}
