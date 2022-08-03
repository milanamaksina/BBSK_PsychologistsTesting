using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Orders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.Steps
{
    public class OrderSteps
    {
        private OrdersOrders _ordersOrders= new OrdersOrders();

        public int RegistrateOrder(string token, ClientOrdersRequestModel clientOrdersRequestModel)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            
            HttpContent content = _ordersOrders.AddOrder(token, clientOrdersRequestModel, expectedRegistrationCode);
            
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);

            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);


            return (int)actualId;
        }

        //public ClientOrderGetIdResponsModel GetClientClientById(string token, ClientOrderGetIdResponsModel clientOrderGetIdResponsModel)
        //{

        //}
    }
}
