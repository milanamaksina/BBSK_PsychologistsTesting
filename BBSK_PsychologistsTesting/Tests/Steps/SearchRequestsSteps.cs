using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using BBSK_PsychologistsTesting.SearchRequests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.Steps
{
    public class SearchRequestsSteps
    {
        private SearchRequestsClient _searchRequestsClient=new SearchRequestsClient();

        public int CreateClientSearchRequests(int id, string token, SearchRequestsRequestsModel searchRequestsRequestsModel )
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;

            HttpContent content = _searchRequestsClient.CreateSearchRequests(id, token, searchRequestsRequestsModel, expectedRegistrationCode);

            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);

            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public List<SearchRequestsResponseModel> GetInfoClientSearchRequests (int id, string token, List<SearchRequestsResponseModel> expected)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpContent httpContent = _searchRequestsClient.GetSearchRequestsById(id, token, expectedCode);

            string content = httpContent.ReadAsStringAsync().Result;
            List<SearchRequestsResponseModel> actual = JsonSerializer.Deserialize<List<SearchRequestsResponseModel>>(content);

            CollectionAssert.AreEquivalent(expected, actual);

            return actual;
        }

        public void DeleteClientSearchRequests(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;

            _searchRequestsClient.DeleteSearchRequestsById(id, token, expectedDeleteCode);
        }

        public void UpdateClientSearchRequests(int id, string token, SearchRequestsRequestsModel searchRequestsRequestsModel)
        {
           
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            
            _searchRequestsClient.PutSearchRequestsById(id, token, searchRequestsRequestsModel, expectedUpdateCode);
        }
    }
}
