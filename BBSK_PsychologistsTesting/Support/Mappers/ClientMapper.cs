using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using System;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Support.Mappers
{
    public class ClientMapper
    {
        public ClientOrderResponseModel MappClientOrdersRequestModelToClientOrderResponsModel(ClientOrdersRequestModel clientOrdersRequestModel, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrdersRequestModel, ClientOrderResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientOrderResponseModel>(clientOrdersRequestModel);
            responseModel.Id = id;
            return responseModel;
        }

        public  ClientResponseModel MappClientRequestModelToClientResponsModel(DateTime date, ClientRequestModel clientRequest, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientRequestModel,ClientResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseClientModel = mapper.Map<ClientResponseModel>(clientRequest);
            responseClientModel.Id = id;
            responseClientModel.RegistrationDate = date;
            return responseClientModel;
        }
    }
}
