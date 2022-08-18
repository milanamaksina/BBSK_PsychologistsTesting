using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;

namespace BBSK_PsychologistsTesting.Support.Mappers
{
    public class PriceMapper
    {
        public PsychologistPriceResponseModel MappClientOrdersRequestModelToClientOrderResponsModel(PsychologistPriceRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PsychologistPriceRequestModel, PsychologistPriceResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<PsychologistPriceResponseModel>(model);
            return responseModel;
        }
    }
}
