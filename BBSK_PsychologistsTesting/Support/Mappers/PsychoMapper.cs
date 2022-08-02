using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;

namespace BBSK_PsychologistsTesting.Support.Mappers
{
    public class PsychoMapper
    {
        public PsychologistResponseModel MappPsychologistRequestModelToPsychologistResponseModel(PsychologistRequestModel model, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PsychologistResponseModel, PsychologistRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<PsychologistResponseModel>(model);
            responseModel.Id = id;
            return responseModel;
        }
    }
}
