using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;

namespace BBSK_PsychologistsTesting.Support.Mappers
{
    public class ClientMapper
    {
        public ClientOrderResponsModel MappClientOrdersRequestModelToClientOrderResponsModel(ClientOrdersRequestModel clientOrdersRequestModel, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrderResponsModel, ClientOrdersRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientOrderResponsModel>(clientOrdersRequestModel);
            responseModel.Id = id;
            return responseModel;
        }
    }
}
