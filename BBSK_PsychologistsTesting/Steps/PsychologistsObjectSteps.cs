using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BBSK_PsychologistsTesting.Clients;
using BBSK_PsychologistsTesting.Models.Request;
using NUnit.Framework;

namespace BBSK_PsychologistsTesting.Steps
{
    public class PsychologistsObjectSteps
    {
        private PsychologistsObjectClient _psychologistsobjectclient = new PsychologistsObjectClient();

        public string UpdateClient(int id, ClientsUpdateRequestModel clientsupdatemodel, HttpStatusCode expectedCode)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;


            HttpResponseMessage respons = _psychologistsobjectclient.UpdatingClient(id, clientsupdatemodel,expectedCode);

            
        }
    }
}
