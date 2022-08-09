using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using System.Collections.Generic;

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

        public List<PsychologistResponseModel> MappAllPsychologistsRequestModelToPsychologistResponseModel(List<PsychologistRequestModel> model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<List<PsychologistResponseModel>, List<PsychologistRequestModel>>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<List<PsychologistResponseModel>>(model);
            return responseModel;
        }
    }
}
