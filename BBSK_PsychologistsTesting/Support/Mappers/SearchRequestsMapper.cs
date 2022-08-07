using AutoMapper;
using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;

namespace BBSK_PsychologistsTesting.Support.Mappers
{
    public class SearchRequestsMapper
    {
        public SearchRequestsResponseModel MappSearchRequestsRequestsModelToSearchRequestsResponseModel(SearchRequestsRequestsModel searchRequestsRequestsModel, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SearchRequestsResponseModel, SearchRequestsRequestsModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SearchRequestsResponseModel>(searchRequestsRequestsModel);
            responseModel.Id = id;
            return responseModel;
        }
    }
}
