﻿using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.Orders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace BBSK_PsychologistsTesting.Tests.Steps
{
    public class OrderSteps
    {
        private OrdersClient _ordersOrders= new OrdersClient();
        
        public int CreateClientOrder(string token, ClientOrdersRequestModel clientOrdersRequestModel)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;          
            HttpContent content = _ordersOrders.AddOrder(token, clientOrdersRequestModel, expectedRegistrationCode);           
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return (int)actualId;
        }

        public ClientOrderResponseModel GetClientClientById(int id, string token, ClientOrderResponseModel expectedOrderClientId)
        {
            HttpStatusCode expectedCod = HttpStatusCode.OK;
            HttpContent httpContent = _ordersOrders.GetOrdersById(id, token, expectedCod);
            string content = httpContent.ReadAsStringAsync().Result;
            ClientOrderResponseModel actualOrderClientId = JsonSerializer.Deserialize<ClientOrderResponseModel>(content);
            Assert.AreEqual(expectedOrderClientId, actualOrderClientId);
            return actualOrderClientId;
        }

        public void DeleteOrderById (int id,string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _ordersOrders.DeleteOrdersById(id, token,expectedDeleteCode);
        }

        public List<ClientOrderGetAllResponseModel> GetAllOrdersModeration(string token, List<ClientOrderGetAllResponseModel> expected)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            HttpContent httpContent = _ordersOrders.GetAllOrders(token, expectedCode);
            string content = httpContent.ReadAsStringAsync().Result;
            List<ClientOrderGetAllResponseModel> actual = JsonSerializer.Deserialize<List<ClientOrderGetAllResponseModel>>(content);
            CollectionAssert.AreEqual(expected, actual);
            return actual;
        }
    }
}
