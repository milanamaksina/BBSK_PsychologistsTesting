using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using System;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Support.Mappers
{
    public class OrderMapper
    {
        public ClientOrderGetAllResponseModel MappClientOrdersRequestModelToClientOrderGetAllResponsModel(ClientOrdersRequestModel clientOrdersRequestModel,int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrdersRequestModel, ClientOrderGetAllResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientOrderGetAllResponseModel>(clientOrdersRequestModel);
            responseModel.Id = id;
            return responseModel;
        }
    }
}
