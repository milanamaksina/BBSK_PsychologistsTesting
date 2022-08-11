using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Support.Mappers
{
    public class ClientMapper
    {
        public ClientOrderResponseModel MappClientOrdersRequestModelToClientOrderResponsModel(ClientOrdersRequestModel clientOrdersRequestModel, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrderResponseModel, ClientOrdersRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientOrderResponseModel>(clientOrdersRequestModel);
            responseModel.Id = id;
            return responseModel;
        }

        public  ClientResponseModel MappClientRequestModelToClientResponsModel(ClientRequestModel clientRequest, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientResponseModel, ClientRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseClientModel = mapper.Map<ClientResponseModel>(clientRequest);
            responseClientModel.Id = id;
            return responseClientModel;
        }
    }
}
